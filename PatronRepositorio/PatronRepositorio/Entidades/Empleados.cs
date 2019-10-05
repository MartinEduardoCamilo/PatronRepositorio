using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades
{
    public class Empleados
    {
        [Key]
        public int EmpleadoID { get; set; }
        public DateTime Fecha { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Cedula { get; set; }
        public decimal sueldo { get; set; }
        public decimal Incentivo { get; set; }

        public Empleados() 
        {
            EmpleadoID = 0;
            Fecha = DateTime.Now;
            Nombre = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            Celular = string.Empty;
            Cedula = string.Empty;
            sueldo = 0;
            Incentivo = 0;
        }
    }
}
