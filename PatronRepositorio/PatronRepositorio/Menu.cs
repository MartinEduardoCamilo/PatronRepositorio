using PatronRepositorio.UI.Consulta;
using PatronRepositorio.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void registroEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEmpleados empleados = new rEmpleados();
            empleados.MdiParent = this;
            empleados.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cEmpleados empleados = new cEmpleados();
            empleados.MdiParent = this;
            empleados.Show();
        }
    }
}
