using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio.UI.Consulta
{
    public partial class cEmpleados : Form
    {
        RepositorioBase<Empleados> repositorio;
        public cEmpleados()
        {
            InitializeComponent();
        }

        private int getID()
        {
            int id = 0;
            try
            {
                id = Convert.ToInt32(CriteriotextBox.Text);
                return id;
            }
            catch (Exception)
            {
                MessageBox.Show("El criterio debe ser un dato numerico de tipo entero", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }

        private void Consultabutton_Click(object sender, EventArgs e)
        {
            repositorio = new RepositorioBase<Empleados>();
            List<Empleados> lista = new List<Empleados>();
            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrocomboBox.SelectedIndex)
                {
                    case 0: //todo
                        lista = repositorio.GetList(p => true);
                        break;
                    case 1: //ID
                        int id = getID();
                        lista = repositorio.GetList(p => p.EmpleadoID == id);
                        break;
                    case 2: //Nombre
                        lista = repositorio.GetList(p => p.Nombre.Contains(CriteriotextBox.Text));
                        break;
                    case 3: //Direccion
                        lista = repositorio.GetList(p => p.Direccion.Contains(CriteriotextBox.Text));
                        break;
                    case 4: //Cedula
                        lista = repositorio.GetList(p => p.Cedula.Contains(CriteriotextBox.Text));
                        break;
                    case 5: //Telefono
                        lista = repositorio.GetList(p => p.Telefono.Contains(CriteriotextBox.Text));
                        break;
                    case 6: //Celular
                        lista = repositorio.GetList(p => p.Celular.Contains(CriteriotextBox.Text));
                        break;
                    default:
                        MessageBox.Show("No existe este filtro", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }
                lista = lista.Where(p => p.Fecha >= DesdedateTimePicker.Value.Date && p.Fecha <= HastadateTimePicker.Value.Date).ToList();
            }
            else
            {
                lista = repositorio.GetList(p => true);
            }

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = lista;
        }
    }
}
