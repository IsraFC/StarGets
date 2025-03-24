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
    public partial class FormMisActividades: Form
    {
        private string usuario;
        public FormMisActividades(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
    }
}
