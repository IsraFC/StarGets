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

// Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False

namespace StarGets
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Por favor, llena todos los campos.");
                return;
            }

            if (!Regex.IsMatch(usuario, @"^[a-zA-Z0-9_]+$"))
            {
                MessageBox.Show("El nombre de usuario no es válido. Solo letras, números y guiones bajos (mínimo 4 caracteres).");
                return;
            }

            if (!Regex.IsMatch(contraseña, @"^.{6,}$"))
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.");
                return;
            }

            if (ValidarCredenciales(usuario, contraseña, out string rol))
            {
                MessageBox.Show("Bienvenido. Rol: " + rol);
                FormDashboard dashboard = new FormDashboard(usuario, rol);
                this.Hide();
                dashboard.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        private bool ValidarCredenciales(string usuario, string contraseña, out string rol)
        {
            rol = "";
            bool valido = false;

            string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = @"
                        select r.nombre_rol 
                        from empleados e
                        join roles r on e.id_rol = r.id_rol
                        where e.usuario = @usuario and e.contraseña = @contraseña";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                rol = reader["nombre_rol"].ToString();
                                valido = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                }
            }

            return valido;
        }
    }
}
