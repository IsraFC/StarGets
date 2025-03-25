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
    public partial class FormDepartamentos: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        int idDepartamentoSeleccionado = -1;

        public FormDepartamentos()
        {
            InitializeComponent();
            CargarDepartamentos();
        }

        private void CargarDepartamentos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from departamentos", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvDepartamentos.DataSource = dt;
            }

            if (dgvDepartamentos.Columns.Contains("id_departamento"))
            {
                dgvDepartamentos.Columns["id_departamento"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtNombreDepto.Text.Trim() == "")
            {
                MessageBox.Show("Escribe un nombre para el departamento.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into departamentos (nombre_departamento) values (@nombre)", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombreDepto.Text);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Departamento agregado.");
            CargarDepartamentos();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (idDepartamentoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un departamento para actualizar.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("update departamentos set nombre_departamento = @nombre where id_departamento = @id", conn);
                cmd.Parameters.AddWithValue("@nombre", txtNombreDepto.Text);
                cmd.Parameters.AddWithValue("@id", idDepartamentoSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Departamento actualizado.");
            CargarDepartamentos();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idDepartamentoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un departamento para eliminar.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from departamentos where id_departamento = @id", conn);
                cmd.Parameters.AddWithValue("@id", idDepartamentoSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Departamento eliminado.");
            CargarDepartamentos();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDepartamentos.Rows[e.RowIndex];
                idDepartamentoSeleccionado = Convert.ToInt32(row.Cells[0].Value);
                txtNombreDepto.Text = row.Cells[1].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNombreDepto.Clear();
            idDepartamentoSeleccionado = -1;
        }
    }
}
