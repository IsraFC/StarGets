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
    public partial class FormMisActividades: Form
    {

        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        private string usuario; // correo o nombre de usuario

        private int idActividadSeleccionada = -1;
        public FormMisActividades(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;

            cbEstadoNuevo.Items.AddRange(new string[] { "inicio", "en proceso", "finalizado" });
            CargarActividadesDelColaborador();
        }

        private void CargarActividadesDelColaborador()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    select a.id_actividad, a.nombre_actividad, a.fecha_inicio, a.fecha_entrega,
                           a.descripcion, a.estado, a.url_archivo
                    from actividades a
                    join empleados e on a.id_empleado = e.id_empleado
                    where e.usuario = @usuario";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvMisActividades.DataSource = dt;
            }

            if (dgvMisActividades.Columns.Contains("id_actividad"))
            {
                dgvMisActividades.Columns["id_actividad"].Visible = false;
            }
        }

        private void btnSubirArchivo_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (idActividadSeleccionada == -1)
            {
                MessageBox.Show("Selecciona una actividad primero.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
                    update actividades
                    set estado = @estado,
                        url_archivo = @archivo
                    where id_actividad = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@estado", cbEstadoNuevo.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@archivo", txtArchivoNuevo.Text);
                cmd.Parameters.AddWithValue("@id", idActividadSeleccionada);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Actividad actualizada.");
            CargarActividadesDelColaborador();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvMisActividades_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvMisActividades.Rows[e.RowIndex];

                idActividadSeleccionada = Convert.ToInt32(row.Cells[0].Value);
                cbEstadoNuevo.SelectedItem = row.Cells["estado"].Value.ToString();
                txtArchivoNuevo.Text = row.Cells["url_archivo"].Value?.ToString();
            }
        }

        private void LimpiarCampos()
        {
            cbEstadoNuevo.SelectedIndex = -1;
            txtArchivoNuevo.Clear();
            idActividadSeleccionada = -1;
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensaje = "Corrige lo siguiente:\n";

            // Estado
            if (cbEstadoNuevo.SelectedItem == null)
            {
                cbEstadoNuevo.BackColor = Color.LightPink;
                mensaje += "\n- Selecciona un estado.";
                esValido = false;
            }
            else
            {
                cbEstadoNuevo.BackColor = Color.White;
            }

            // Ruta de archivo (opcional)
            if (!string.IsNullOrWhiteSpace(txtArchivoNuevo.Text) &&
                !Regex.IsMatch(txtArchivoNuevo.Text.Trim(), @"^.+\\?.+\..+$"))
            {
                txtArchivoNuevo.BackColor = Color.LightPink;
                mensaje += "\n- Ruta de archivo inválida. Asegúrate de tener formato válido (ej. carpeta\\archivo.pdf).";
                esValido = false;
            }
            else
            {
                txtArchivoNuevo.BackColor = Color.White;
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
