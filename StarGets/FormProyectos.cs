﻿using System;
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
    public partial class FormProyectos: Form
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=FalseData Source=localhost\\SQLEXPRESS;Initial Catalog=StarGets;Integrated Security=True;Encrypt=False";

        public FormProyectos()
        {
            InitializeComponent();

            CargarDepartamentos();
            CargarProyectos();
            cbEstado.Items.AddRange(new string[] {"en proceso", "activo" });
        }

        private void CargarProyectos()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
            SELECT 
                p.id_proyecto,
                d.nombre_departamento,
                p.nombre_proyecto,
                p.observacion,
                p.fecha_inicial,
                p.fecha_entrega,
                p.estado_proyecto,
                p.descripcion
            FROM proyectos p
            INNER JOIN departamentos d ON p.id_departamento = d.id_departamento
            WHERE p.estado_proyecto <> 'baja'", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvProyectos.DataSource = dt;
            }

            if (dgvProyectos.Columns.Contains("id_proyecto"))
                dgvProyectos.Columns["id_proyecto"].Visible = false;
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
            if (!ValidarCampos()) return;

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
                cmd.Parameters.AddWithValue("@estado", cbEstado.Text);
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

            if (!ValidarCampos()) return;

            int idProyecto = Convert.ToInt32(dgvProyectos.CurrentRow.Cells[0].Value);
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
                cmd.Parameters.AddWithValue("@estado", cbEstado.Text);
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
                MessageBox.Show("Selecciona un proyecto para dar de baja.");
                return;
            }

            int idProyecto = Convert.ToInt32(dgvProyectos.CurrentRow.Cells[0].Value);

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de dar de baja este proyecto?",
                "Confirmar baja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "UPDATE proyectos SET estado_proyecto = 'baja' WHERE id_proyecto = @id", conn);
                    cmd.Parameters.AddWithValue("@id", idProyecto);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Proyecto dado de baja.");
                CargarProyectos();
                LimpiarCampos();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            cbEstado.SelectedIndex = -1;
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

                txtNombre.Text = row.Cells[2].Value.ToString();
                txtObservacion.Text = row.Cells[3].Value.ToString();
                dtpInicio.Value = Convert.ToDateTime(row.Cells[4].Value);
                dtpEntrega.Value = Convert.ToDateTime(row.Cells[5].Value);
                cbEstado.Text = row.Cells[6].Value.ToString();
                txtDescripcion.Text = row.Cells[7].Value.ToString();

                string nombreDepto = row.Cells[1].Value.ToString(); // columna con nombre del departamento
                int idDepartamento = ObtenerIdDepartamentoPorNombre(nombreDepto);
                foreach (var item in cbDepartamento.Items)
                {
                    if (((dynamic)item).Value == idDepartamento)
                    {
                        cbDepartamento.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private bool ValidarCampos()
        {
            bool esValido = true;
            string mensaje = "Corrige lo siguiente:\n";

            // Nombre del proyecto
            if (!Regex.IsMatch(txtNombre.Text.Trim(), @"^[\w\sáéíóúÁÉÍÓÚñÑ.,-]{3,50}$"))
            {
                txtNombre.BackColor = Color.LightPink;
                mensaje += "\n- Nombre del proyecto inválido. Solo letras, números y espacios.";
                esValido = false;
            }
            else txtNombre.BackColor = Color.White;

            // Observación (opcional, mínimo si se escribe)
            if (!string.IsNullOrWhiteSpace(txtObservacion.Text) && txtObservacion.Text.Trim().Length < 5)
            {
                txtObservacion.BackColor = Color.LightPink;
                mensaje += "\n- Observación demasiado corta (mínimo 5 caracteres).";
                esValido = false;
            }
            else txtObservacion.BackColor = Color.White;

            // Estado del proyecto
            if (!Regex.IsMatch(cbEstado.Text.Trim(), @"^(en proceso|activo)$"))
            {
                cbEstado.BackColor = Color.LightPink;
                mensaje += "\n- Estado inválido. Usa: en proceso o finalizado.";
                esValido = false;
            }
            else cbEstado.BackColor = Color.White;

            // Descripción
            if (!Regex.IsMatch(txtDescripcion.Text.Trim(), @"^.{5,}$"))
            {
                txtDescripcion.BackColor = Color.LightPink;
                mensaje += "\n- Descripción demasiado corta. Mínimo 5 caracteres.";
                esValido = false;
            }
            else txtDescripcion.BackColor = Color.White;

            // Departamento
            if (cbDepartamento.SelectedItem == null)
            {
                cbDepartamento.BackColor = Color.LightPink;
                mensaje += "\n- Selecciona un departamento.";
                esValido = false;
            }
            else cbDepartamento.BackColor = Color.White;

            // Fechas
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

        private int ObtenerIdDepartamentoPorNombre(string nombre)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "SELECT id_departamento FROM departamentos WHERE nombre_departamento = @nombre", conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                return (int)cmd.ExecuteScalar();
            }
        }

    }
}
