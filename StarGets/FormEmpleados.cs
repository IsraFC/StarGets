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
    public partial class FormEmpleados: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";
        private int idEmpleadoSeleccionado = -1;
        public FormEmpleados()
        {
            InitializeComponent();

            CargarDepartamentos();
            CargarRoles();
            CargarEmpleados();
        }

        private void CargarDepartamentos()
        {
            cbDepartamento.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select id_departamento, nombre_departamento from departamentos", conn);
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

        private void CargarRoles()
        {
            cbRol.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("select id_rol, nombre_rol from roles", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cbRol.Items.Add(new
                    {
                        Text = reader["nombre_rol"].ToString(),
                        Value = reader["id_rol"]
                    });
                }
            }
            cbRol.DisplayMember = "Text";
            cbRol.ValueMember = "Value";
        }

        private void CargarEmpleados()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from empleados", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmpleados.DataSource = dt;
            }

            if (dgvEmpleados.Columns.Contains("id_empleado"))
            {
                dgvEmpleados.Columns["id_empleado"].Visible = false;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (cbDepartamento.SelectedItem == null || cbRol.SelectedItem == null)
            {
                MessageBox.Show("Selecciona un rol y un departamento.");
                return;
            }

            int idDepartamento = (int)((dynamic)cbDepartamento.SelectedItem).Value;
            int idRol = (int)((dynamic)cbRol.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    insert into empleados (id_departamento, nombre, ap, am, correo, telefono, usuario, contraseña, id_rol)
                    values (@id_departamento, @nombre, @ap, @am, @correo, @telefono, @usuario, @contraseña, @id_rol)", conn);

                cmd.Parameters.AddWithValue("@id_departamento", idDepartamento);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ap", txtAp.Text);
                cmd.Parameters.AddWithValue("@am", txtAm.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                cmd.Parameters.AddWithValue("@id_rol", idRol);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Empleado agregado.");
            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            if (idEmpleadoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un empleado para actualizar.");
                return;
            }

            int idDepartamento = (int)((dynamic)cbDepartamento.SelectedItem).Value;
            int idRol = (int)((dynamic)cbRol.SelectedItem).Value;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
                    update empleados
                    set id_departamento = @id_departamento,
                        nombre = @nombre,
                        ap = @ap,
                        am = @am,
                        correo = @correo,
                        telefono = @telefono,
                        usuario = @usuario,
                        contraseña = @contraseña,
                        id_rol = @id_rol
                    where id_empleado = @id", conn);

                cmd.Parameters.AddWithValue("@id_departamento", idDepartamento);
                cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                cmd.Parameters.AddWithValue("@ap", txtAp.Text);
                cmd.Parameters.AddWithValue("@am", txtAm.Text);
                cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@contraseña", txtContraseña.Text);
                cmd.Parameters.AddWithValue("@id_rol", idRol);
                cmd.Parameters.AddWithValue("@id", idEmpleadoSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Empleado actualizado.");
            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idEmpleadoSeleccionado == -1)
            {
                MessageBox.Show("Selecciona un empleado para eliminar.");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from empleados where id_empleado = @id", conn);
                cmd.Parameters.AddWithValue("@id", idEmpleadoSeleccionado);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Empleado eliminado.");
            CargarEmpleados();
            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvEmpleados.Rows[e.RowIndex];
                idEmpleadoSeleccionado = Convert.ToInt32(row.Cells[0].Value);

                txtNombre.Text = row.Cells[2].Value.ToString();
                txtAp.Text = row.Cells[3].Value.ToString();
                txtAm.Text = row.Cells[4].Value.ToString();
                txtCorreo.Text = row.Cells[5].Value.ToString();
                txtTelefono.Text = row.Cells[6].Value.ToString();
                txtUsuario.Text = row.Cells[7].Value.ToString();
                txtContraseña.Text = row.Cells[8].Value.ToString();

                int idDepartamento = Convert.ToInt32(row.Cells[1].Value);
                int idRol = Convert.ToInt32(row.Cells[9].Value);

                foreach (var item in cbDepartamento.Items)
                {
                    if (((dynamic)item).Value == idDepartamento)
                    {
                        cbDepartamento.SelectedItem = item;
                        break;
                    }
                }

                foreach (var item in cbRol.Items)
                {
                    if (((dynamic)item).Value == idRol)
                    {
                        cbRol.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtAp.Clear();
            txtAm.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtUsuario.Clear();
            txtContraseña.Clear();
            cbDepartamento.SelectedIndex = -1;
            cbRol.SelectedIndex = -1;
            idEmpleadoSeleccionado = -1;
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensaje = "Corrija lo siguiente:\n";

            // Nombre
            if (!Regex.IsMatch(txtNombre.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                txtNombre.BackColor = Color.LightPink;
                mensaje = mensaje + "\nNombre inválido. Solo letras y espacios.";
                esValido = false;
            }
            else txtNombre.BackColor = Color.White;

            // Apellido paterno
            if (!Regex.IsMatch(txtAp.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                txtAp.BackColor = Color.LightPink;
                mensaje = mensaje + "\nApellido paterno inválido.";
                esValido = false;
            }
            else txtAp.BackColor = Color.White;

            // Apellido materno
            if (!Regex.IsMatch(txtAm.Text.Trim(), @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,50}$"))
            {
                txtAm.BackColor = Color.LightPink;
                mensaje =  mensaje + "\nApellido materno inválido.";
                esValido = false;
            }
            else txtAm.BackColor = Color.White;

            // Correo
            if (!Regex.IsMatch(txtCorreo.Text.Trim(), @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                txtCorreo.BackColor = Color.LightPink;
                mensaje = mensaje + "\nCorreo electrónico inválido.";
                esValido = false;
            }
            else txtCorreo.BackColor = Color.White;

            // Teléfono
            if (!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{10}$"))
            {
                txtTelefono.BackColor = Color.LightPink;
                mensaje = mensaje + "\nTeléfono inválido. Debe contener 10 dígitos.";
                esValido = false;
            }
            else txtTelefono.BackColor = Color.White;

            // Usuario
            if (!Regex.IsMatch(txtUsuario.Text.Trim(), @"^[a-zA-Z0-9_]{4,}$"))
            {
                txtUsuario.BackColor = Color.LightPink;
                mensaje = mensaje + "\nUsuario inválido. Usa solo letras, números y guiones bajos.";
                esValido = false;
            }
            else txtUsuario.BackColor = Color.White;

            // Contraseña
            if (!Regex.IsMatch(txtContraseña.Text.Trim(), @"^.{6,}$"))
            {
                txtContraseña.BackColor = Color.LightPink;
                mensaje = mensaje + "\nContraseña inválida. Mínimo 6 caracteres.";
                esValido = false;
            }
            else txtContraseña.BackColor = Color.White;

            // Departamento
            if (cbDepartamento.SelectedItem == null)
            {
                cbDepartamento.BackColor = Color.LightPink;
                mensaje = mensaje + "\nSelecciona un departamento.";
                esValido = false;
            }
            else cbDepartamento.BackColor = Color.White;

            // Rol
            if (cbRol.SelectedItem == null)
            {
                cbRol.BackColor = Color.LightPink;
                mensaje = mensaje + "\nSelecciona un rol.";
                esValido = false;
            }
            else cbRol.BackColor = Color.White;

            if (!esValido)
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return esValido;
        }
    }
}
