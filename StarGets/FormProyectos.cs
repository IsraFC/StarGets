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

namespace StarGets
{
    public partial class FormProyectos: Form
    {
        string connectionString = "Server=localhost;Database=nombre_de_tu_bd;Trusted_Connection=True;";

        public FormProyectos()
        {
            InitializeComponent();
        }

        private void FormProyectos_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarProyectos();
        }

        private void CargarProyectos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from proyectos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProyectos.DataSource = dt;
            }
        }

        private void CargarDepartamentos()
        {
            cbDepartamento.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "select id_departamento, nombre_departamento from departamentos";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cbDepartamento.Items.Add(new
                    {
                        Text = reader["nombre_departamento"].ToString(),
                        Value = reader["id_departamento"]
                    });
                }
            }

            cbDepartamento.DisplayMember = "Text";
            cbDepartamento.ValueMember = "Value";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbDepartamento.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un departamento.");
                return;
            }

            int idDepartamento = (int)((dynamic)cbDepartamento.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    insert into proyectos (id_departamento, nombre_proyecto, observacion, fecha_inicial, fecha_entrega, estado_proyecto, descripcion)
                    values (@id_departamento, @nombre, @observacion, @inicio, @entrega, @estado, @descripcion)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_departamento", idDepartamento);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@observacion", txtObservacion.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proyecto agregado.");
            CargarProyectos();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proyecto.");
                return;
            }

            int idProyecto = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["id_proyecto"].Value);
            int idDepartamento = (int)((dynamic)cbDepartamento.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    update proyectos
                    set id_departamento = @id_departamento,
                        nombre_proyecto = @nombre,
                        observacion = @observacion,
                        fecha_inicial = @inicio,
                        fecha_entrega = @entrega,
                        estado_proyecto = @estado,
                        descripcion = @descripcion
                    where id_proyecto = @id_proyecto";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id_departamento", idDepartamento);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@observacion", txtObservacion.Text);
                cmd.Parameters.AddWithValue("@inicio", dtpInicio.Value);
                cmd.Parameters.AddWithValue("@entrega", dtpEntrega.Value);
                cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                cmd.Parameters.AddWithValue("@id_proyecto", idProyecto);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proyecto actualizado.");
            CargarProyectos();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProyectos.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un proyecto para eliminar.");
                return;
            }

            int idProyecto = Convert.ToInt32(dgvProyectos.CurrentRow.Cells["id_proyecto"].Value);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from proyectos where id_proyecto = @id", conn);
                cmd.Parameters.AddWithValue("@id", idProyecto);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Proyecto eliminado.");
            CargarProyectos();
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtEstado.Clear();
            txtDescripcion.Clear();
            txtObservacion.Clear();
            cbDepartamento.SelectedIndex = -1;
            dtpInicio.Value = DateTime.Now;
            dtpEntrega.Value = DateTime.Now;
        }


        private void dgvProyectos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvProyectos.Rows[e.RowIndex];

                txtNombre.Text = row.Cells["nombre_proyecto"].Value.ToString();
                txtObservacion.Text = row.Cells["observacion"].Value.ToString();
                dtpInicio.Value = Convert.ToDateTime(row.Cells["fecha_inicial"].Value);
                dtpEntrega.Value = Convert.ToDateTime(row.Cells["fecha_entrega"].Value);
                txtEstado.Text = row.Cells["estado_proyecto"].Value.ToString();
                txtDescripcion.Text = row.Cells["descripcion"].Value.ToString();

                // Puedes buscar el departamento en cbDepartamento si deseas
            }
        }
    }
}
