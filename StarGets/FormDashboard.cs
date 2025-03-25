using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarGets
{
    public partial class FormDashboard : Form
    {
        private string usuario;
        private string rol;
        public FormDashboard(string usuario, string rol)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.rol = rol;

            lblBienvenida.Text = "Bienvenido, " + usuario;
            lblRol.Text = "Rol: " + rol;

            if (rol == "colaborador")
            {
                // Oculta opciones exclusivas de líderes
                btnDepartamentos.Visible = false;
                btnEmpleados.Visible = false;
                btnProyectos.Visible = false;
                btnActividades.Visible = false;
                btnVerAvance.Visible = false;
            }
            else if (rol == "líder")
            {
                // Oculta lo que no necesita un líder
                btnMisActividades.Visible = false;
            }
        }

        private void btnDepartamentos_Click(object sender, EventArgs e)
        {
            FormDepartamentos form = new FormDepartamentos();
            form.ShowDialog();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            FormEmpleados form = new FormEmpleados();
            form.ShowDialog();
        }

        private void btnProyectos_Click(object sender, EventArgs e)
        {
            FormProyectos form = new FormProyectos();
            form.ShowDialog();
        }

        private void btnActividades_Click(object sender, EventArgs e)
        {
            FormActividades form = new FormActividades();
            form.ShowDialog();
        }

        private void btnVerAvance_Click(object sender, EventArgs e)
        {
            FormVerAvance form = new FormVerAvance();
            form.ShowDialog();
        }

        private void btnMisActividades_Click(object sender, EventArgs e)
        {
            FormMisActividades form = new FormMisActividades(usuario);
            form.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }
    }
}
