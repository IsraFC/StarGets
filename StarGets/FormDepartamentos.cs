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
            if (!ValidarCampos()) return;

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
            if (!ValidarCampos()) return;

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

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensaje = "Corrige lo siguiente:\n";

            if (!Regex.IsMatch(txtNombreDepto.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{3,50}$"))
            {
                txtNombreDepto.BackColor = Color.LightPink;
                mensaje += "\n- Nombre inválido. Usa solo letras y mínimo 3 caracteres.";
                esValido = false;
            }
            else
            {
                txtNombreDepto.BackColor = Color.White;
            }

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
