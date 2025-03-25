using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False
namespace StarGets
{
    public partial class FormActividades: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        public FormActividades()
        {
            InitializeComponent();

            CargarProyectos();
            CargarColaboradores();
            CargarActividades();

            cbEstado.Items.AddRange(new string[] { "inicio", "en proceso", "finalizado" });
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
                SqlDataAdapter da = new SqlDataAdapter("select * from actividades", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvActividades.DataSource = dt;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombreActividad.Clear();
            txtDescripcion.Clear();
            txtArchivo.Clear();
            cbProyecto.SelectedIndex = -1;
            cbColaborador.SelectedIndex = -1;
            cbEstado.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now;
            dtpEntrega.Value = DateTime.Now;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
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
                    insert into actividades (id_proyecto, id_empleado, nombre_actividad, fecha_inicio, fecha_entrega, descripcion, estado, url_archivo)
                    values (@id_proyecto, @id_empleado, @nombre, @inicio, @entrega, @descripcion, @estado, @archivo)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);
                cmd.Parameters.AddWithValue("@id_empleado", idColaborador);
                cmd.Parameters.AddWithValue("@nombre", txtNombreActividad.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@archivo", txtArchivo.Text);
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
                MessageBox.Show("Selecciona una actividad para eliminar.");
                return;
            }

            int idActividad = Convert.ToInt32(dgvActividades.CurrentRow.Cells[0].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from actividades where id_actividad = @id", conn);
                cmd.Parameters.AddWithValue("@id", idActividad);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Actividad eliminada.");
            CargarActividades();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
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
                        estado = @estado,
                        url_archivo = @archivo
                    where id_actividad = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);
                cmd.Parameters.AddWithValue("@id_empleado", idColaborador);
                cmd.Parameters.AddWithValue("@nombre", txtNombreActividad.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@estado", cbEstado.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@archivo", txtArchivo.Text);
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
                txtDescripcion.Text = row.Cells[6].Value.ToString();
                txtArchivo.Text = row.Cells[8].Value.ToString();
                dtpInicio.Value = Convert.ToDateTime(row.Cells[4].Value);
                dtpEntrega.Value = Convert.ToDateTime(row.Cells[5].Value);
                cbEstado.SelectedItem = row.Cells[7].Value.ToString();

                int idProyecto = Convert.ToInt32(row.Cells[1].Value);
                int idColaborador = Convert.ToInt32(row.Cells[2].Value);

                foreach (var item in cbProyecto.Items)
                {
                    if (((dynamic)item).Value == idProyecto)
                    {
                        cbProyecto.SelectedItem = item;
                        break;
                    }
                }

                foreach (var item in cbColaborador.Items)
                {
                    if (((dynamic)item).Value == idColaborador)
                    {
                        cbColaborador.SelectedItem = item;
                        break;
                    }
                }
            }
        }
    }
}
