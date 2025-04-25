using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarGets
{
    public partial class FormActividades: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        private int idActividadSeleccionada = -1;

        public FormActividades()
        {
            InitializeComponent();

            CargarProyectos();
            CargarColaboradores();
            CargarActividades();

            cbEstado.Items.AddRange(new string[] {"en proceso", "finalizado" });
        }

        private void CargarProyectos()
        {
            cbProyecto.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select id_proyecto, nombre_proyecto from proyectos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbProyecto.Items.Add(new
                    {
                        Text = reader["nombre_proyecto"].ToString(),
                        Value = reader["id_proyecto"]
                    });
                }
            }

            cbProyecto.DisplayMember = "Text";
            cbProyecto.ValueMember = "Value";
        }

        private void CargarColaboradores()
        {
            cbColaborador.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    select id_empleado, nombre + ' ' + ap as nombre_completo
                    from empleados
                    where id_rol = 2"; // solo colaboradores
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbColaborador.Items.Add(new
                    {
                        Text = reader["nombre_completo"].ToString(),
                        Value = reader["id_empleado"]
                    });
                }
            }

            cbColaborador.DisplayMember = "Text";
            cbColaborador.ValueMember = "Value";
        }

        private void CargarActividades()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT 
                        a.id_actividad,
                        p.nombre_proyecto,
                        e.nombre + ' ' + e.ap AS colaborador,
                        a.nombre_actividad,
                        a.fecha_inicio,
                        a.fecha_entrega,
                        a.estado,
                        a.descripcion,
                        a.url_archivo
                    FROM actividades a
                    JOIN proyectos p ON a.id_proyecto = p.id_proyecto
                    JOIN empleados e ON a.id_empleado = e.id_empleado
                    WHERE a.estado <> 'cancelada'", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvActividades.DataSource = dt;
            }

            if (dgvActividades.Columns.Contains("id_actividad"))
                dgvActividades.Columns["id_actividad"].Visible = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreActividad.Clear();
            txtDescripcion.Clear();
            cbProyecto.SelectedIndex = -1;
            cbColaborador.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now;
            dtpEntrega.Value = DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (cbProyecto.SelectedItem == null || cbColaborador.SelectedItem == null || cbEstado.SelectedItem == null)
            {
                MessageBox.Show("Completa todos los campos.");
                return;
            }

            int idProyecto = (int)((dynamic)cbProyecto.SelectedItem).Value;
            int idColaborador = (int)((dynamic)cbColaborador.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    insert into actividades (id_proyecto, id_empleado, nombre_actividad, fecha_inicio, fecha_entrega, descripcion, estado)
                    values (@id_proyecto, @id_empleado, @nombre, @inicio, @entrega, @descripcion, @estado)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);
                cmd.Parameters.AddWithValue("@id_empleado", idColaborador);
                cmd.Parameters.AddWithValue("@nombre", txtNombreActividad.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Actividad agregada.");
            CargarActividades();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una actividad para cancelar.");
                return;
            }

            int idActividad = Convert.ToInt32(dgvActividades.CurrentRow.Cells[0].Value);

            DialogResult r = MessageBox.Show("¿Cancelar esta actividad?", "Confirmar", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE actividades SET estado = 'cancelada' WHERE id_actividad = @id", conn);
                    cmd.Parameters.AddWithValue("@id", idActividad);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Actividad cancelada.");
                CargarActividades();
                LimpiarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (dgvActividades.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una actividad para actualizar.");
                return;
            }

            int idActividad = Convert.ToInt32(dgvActividades.CurrentRow.Cells[0].Value);
            int idProyecto = (int)((dynamic)cbProyecto.SelectedItem).Value;
            int idColaborador = (int)((dynamic)cbColaborador.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    update actividades
                    set id_proyecto = @id_proyecto,
                        id_empleado = @id_empleado,
                        nombre_actividad = @nombre,
                        fecha_inicio = @inicio,
                        fecha_entrega = @entrega,
                        descripcion = @descripcion,
                        estado = @estado
                    where id_actividad = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);
                cmd.Parameters.AddWithValue("@id_empleado", idColaborador);
                cmd.Parameters.AddWithValue("@nombre", txtNombreActividad.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@id", idActividad);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Actividad actualizada.");
            CargarActividades();
            LimpiarCampos();
        }

        private void dgvActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvActividades.Rows[e.RowIndex];
                txtNombreActividad.Text = row.Cells[3].Value.ToString();
                txtDescripcion.Text = row.Cells[7].Value.ToString();
                dtpInicio.Value = Convert.ToDateTime(row.Cells[4].Value);
                dtpEntrega.Value = Convert.ToDateTime(row.Cells[5].Value);
                cbEstado.SelectedItem = row.Cells[6].Value.ToString();

                string nombreProyecto = row.Cells[1].Value.ToString();
                string nombreColaborador = row.Cells[2].Value.ToString();

                foreach (var item in cbProyecto.Items)
                {
                    if (((dynamic)item).Text == nombreProyecto)
                    {
                        cbProyecto.SelectedItem = item;
                        break;
                    }
                }

                foreach (var item in cbColaborador.Items)
                {
                    if (((dynamic)item).Text == nombreColaborador)
                    {
                        cbColaborador.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensaje = "Corrige lo siguiente:\n";

            // Nombre de actividad
            if (!Regex.IsMatch(txtNombreActividad.Text.Trim(), @"^[\w\sáéíóúÁÉÍÓÚñÑ.,-]{3,50}$"))
            {
                txtNombreActividad.BackColor = Color.LightPink;
                mensaje += "\n- Nombre de actividad inválido. Usa solo letras, números y espacios.";
                esValido = false;
            }
            else txtNombreActividad.BackColor = Color.White;

            // Descripción
            if (!Regex.IsMatch(txtDescripcion.Text.Trim(), @"^.{5,}$"))
            {
                txtDescripcion.BackColor = Color.LightPink;
                mensaje += "\n- Descripción mínima de 5 caracteres.";
                esValido = false;
            }
            else txtDescripcion.BackColor = Color.White;

            // Proyecto
            if (cbProyecto.SelectedItem == null)
            {
                cbProyecto.BackColor = Color.LightPink;
                mensaje += "\n- Selecciona un proyecto.";
                esValido = false;
            }
            else cbProyecto.BackColor = Color.White;

            // Colaborador
            if (cbColaborador.SelectedItem == null)
            {
                cbColaborador.BackColor = Color.LightPink;
                mensaje += "\n- Selecciona un colaborador.";
                esValido = false;
            }
            else cbColaborador.BackColor = Color.White;

            // Estado
            if (cbEstado.SelectedItem == null)
            {
                cbEstado.BackColor = Color.LightPink;
                mensaje += "\n- Selecciona un estado de la actividad.";
                esValido = false;
            }
            else cbEstado.BackColor = Color.White;

            // Fecha de entrega posterior a inicio
            if (dtpEntrega.Value <= dtpInicio.Value)
            {
                dtpInicio.CalendarMonthBackground = Color.LightPink;
                dtpEntrega.CalendarMonthBackground = Color.LightPink;
                mensaje += "\n- La fecha de entrega debe ser posterior a la de inicio.";
                esValido = false;
            }
            else
            {
                dtpInicio.CalendarMonthBackground = Color.White;
                dtpEntrega.CalendarMonthBackground = Color.White;
            }

            // Si hay errores, mostrar todo junto
            if (!esValido)
            {
                MessageBox.Show(mensaje, "Validación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return esValido;
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            this.Close();
            FormDashboard dashboard = Application.OpenForms["FormDashboard"] as FormDashboard;
            if (dashboard != null)
            {
                dashboard.Show();
            }
        }
    }
}
