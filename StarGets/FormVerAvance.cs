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
    public partial class FormVerAvance: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        public FormVerAvance()
        {
            InitializeComponent();
            cbFiltro.Items.AddRange(new string[] { "Proyecto", "Colaborador" });
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbOpciones.Items.Clear();

            if (cbFiltro.SelectedItem.ToString() == "Proyecto")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("select id_proyecto, nombre_proyecto from proyectos", conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbOpciones.Items.Add(new
                        {
                            Text = reader["nombre_proyecto"].ToString(),
                            Value = reader["id_proyecto"]
                        });
                    }
                }
            }
            else if (cbFiltro.SelectedItem.ToString() == "Colaborador")
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(@"
                        select id_empleado, nombre + ' ' + ap as nombre_completo
                        from empleados
                        where id_rol = 2", conn); // solo colaboradores
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cbOpciones.Items.Add(new
                        {
                            Text = reader["nombre_completo"].ToString(),
                            Value = reader["id_empleado"]
                        });
                    }
                }
            }

            cbOpciones.DisplayMember = "Text";
            cbOpciones.ValueMember = "Value";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cbFiltro.SelectedItem == null || cbOpciones.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un filtro y una opción válida.");
                return;
            }

            string filtro = cbFiltro.SelectedItem?.ToString();
            int id = (int)((dynamic)cbOpciones.SelectedItem).Value;

            string query = @"
                select a.nombre_actividad, p.nombre_proyecto, 
                        e.nombre + ' ' + e.ap as colaborador,
                        a.fecha_inicio, a.fecha_entrega, 
                        a.estado, a.url_archivo
                from actividades a
                join proyectos p on a.id_proyecto = p.id_proyecto
                join empleados e on a.id_empleado = e.id_empleado
                where ";

            if (filtro == "Proyecto")
                query += "a.id_proyecto = @id";
            else
                query += "a.id_empleado = @id";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAvance.DataSource = dt;

                MostrarResumen(dt);
            }
        }

        private void MostrarResumen(DataTable tabla)
        {
            int total = tabla.Rows.Count;
            int inicio = 0, proceso = 0, finalizado = 0;

            foreach (DataRow row in tabla.Rows)
            {
                string estado = row["estado"].ToString().ToLower();
                if (estado == "inicio") inicio++;
                else if (estado == "en proceso") proceso++;
                else if (estado == "finalizado") finalizado++;
            }

            lblResumen.Text = $"Total: {total} | Inicio: {inicio} | En proceso: {proceso} | Finalizado: {finalizado}";
        }
    }
}
