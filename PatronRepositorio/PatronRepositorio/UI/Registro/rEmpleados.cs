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

namespace PatronRepositorio.UI.Registro
{
    public partial class rEmpleados : Form
    {
        public rEmpleados()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            EmpleadoIDnumericUpDown.Value = 0;
            FechadateTimePicker.Value = DateTime.Now;
            NombretextBox.Text = string.Empty;
            DirecciontextBox.Text = string.Empty;
            TelefonomaskedTextBox.Text = string.Empty;
            CelularmaskedTextBox.Text = string.Empty;
            CedulamaskedTextBox.Text = string.Empty;
            SueldotextBox.Text = string.Empty;
            IncentivotextBox.Text = string.Empty;
            errorProvider.Clear();
        }

        private Empleados LlenaClase()
        {
            Empleados empleados = new Empleados();
            empleados.EmpleadoID = (int)(EmpleadoIDnumericUpDown.Value);
            empleados.Fecha = FechadateTimePicker.Value;
            empleados.Nombre = NombretextBox.Text;
            empleados.Direccion = DirecciontextBox.Text;
            empleados.Telefono = TelefonomaskedTextBox.Text;
            empleados.Celular = CelularmaskedTextBox.Text;
            empleados.Cedula = CedulamaskedTextBox.Text;
            empleados.sueldo = Convert.ToDecimal(SueldotextBox.Text);
            empleados.Incentivo = Convert.ToDecimal(IncentivotextBox.Text);
            return empleados;
        }

        private void LlenaCampo(Empleados empleados)
        {
            EmpleadoIDnumericUpDown.Value = empleados.EmpleadoID;
            FechadateTimePicker.Value = empleados.Fecha;
            NombretextBox.Text = empleados.Nombre;
            DirecciontextBox.Text = empleados.Direccion;
            TelefonomaskedTextBox.Text = empleados.Telefono;
            CelularmaskedTextBox.Text = empleados.Celular;
            CedulamaskedTextBox.Text = empleados.Cedula;
            SueldotextBox.Text = empleados.sueldo.ToString();
            IncentivotextBox.Text = empleados.Incentivo.ToString();
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider.Clear();

            if (string.IsNullOrWhiteSpace(NombretextBox.Text))
            {
                errorProvider.SetError(NombretextBox, "El campo nombre no puede estar vacio ");
                NombretextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DirecciontextBox.Text))
            {
                errorProvider.SetError(DirecciontextBox, "El campo direccion no puede estar vacio ");
                DirecciontextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TelefonomaskedTextBox.Text.Replace("-","")))
            {
                errorProvider.SetError(TelefonomaskedTextBox, "El campo telefono no puede estar vacio ");
                TelefonomaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CedulamaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider.SetError(CedulamaskedTextBox, "El campo cedula no puede estar vacio ");
                CedulamaskedTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(CelularmaskedTextBox.Text.Replace("-", "")))
            {
                errorProvider.SetError(CelularmaskedTextBox, "El campo celular no puede estar vacio ");
                CelularmaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(SueldotextBox.Text))
            {
                errorProvider.SetError(SueldotextBox, "El campo sueldo no puede estar vacio");
                SueldotextBox.Focus();
                paso = false;
            }
            else
            {
                if(Convert.ToDecimal(SueldotextBox.Text) < 0)
                {
                    errorProvider.SetError(SueldotextBox, "El campo sueldo tiene que ser mayo que cero");
                    SueldotextBox.Focus();
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(IncentivotextBox.Text))
            {
                errorProvider.SetError(IncentivotextBox, "El campo incentivo no puede estar vacio");
                IncentivotextBox.Focus();
                paso = false;
            }
            else
            {
                if (Convert.ToDecimal(IncentivotextBox.Text) < 0)
                {
                    errorProvider.SetError(IncentivotextBox, "El campo incentivo tiene que ser mayo que cero");
                    IncentivotextBox.Focus();
                    paso = false;
                }
            }

            return paso;
        }

        private bool Existe()
        {
            var repositorio = new RepositorioBase<Empleados>();
            Empleados empleado = repositorio.Buscar((int)(EmpleadoIDnumericUpDown.Value));
            return (empleado != null);
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            bool paso = false;
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();

            if (!Validar())
                return;

            empleados = LlenaClase();

            if (EmpleadoIDnumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(empleados);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No existe este empleado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = repositorio.Modificar(empleados);
            }

            if (paso)
            {
                MessageBox.Show("!!Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("No se Guardo", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            var repositorio = new RepositorioBase<Empleados>();
            int id = (int)(EmpleadoIDnumericUpDown.Value);
            Empleados empleados = new Empleados();

            empleados = repositorio.Buscar(id);

            if (empleados != null)
            {
                Limpiar();
                LlenaCampo(empleados);
            }
            else
            {
                MessageBox.Show("Empleado no encontrado", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            bool paso;
            int id = (int)(EmpleadoIDnumericUpDown.Value);
            var repositorio = new RepositorioBase<Empleados>();

            if (!Existe())
            {
                MessageBox.Show("No se elimino porque este empleado no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                paso = repositorio.Eliminar(id);

                if (paso)
                {
                   Limpiar(); 
                   MessageBox.Show("Se elimino", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se elimino", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //validacion solo para datos de tipo decimal
        private void SueldotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < SueldotextBox.Text.Length; i++)
            {
                if (SueldotextBox.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }

        private void IncentivotextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }

            bool paso = false;
            decimal numero = 0;

            for (int i = 0; i < IncentivotextBox.Text.Length; i++)
            {
                if (IncentivotextBox.Text[i] == '.')
                    paso = true;
                if (paso && numero++ >= 2)
                {
                    e.Handled = true;
                    return;
                }
            }

            if (e.KeyChar >= 48 && e.KeyChar <= 57)
                e.Handled = false;
            else if (e.KeyChar == 46)
                e.Handled = (paso) ? true : false;
            else
                e.Handled = true;
        }
    }
}
