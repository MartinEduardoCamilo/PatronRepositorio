using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL
{
    public class EmpleadoBLL : RepositorioBase<Empleados>
    {
        public override bool Guardar(Empleados empleados)
        {
            bool paso = base.Guardar(empleados);
            return paso;
        }

        public override bool Modificar(Empleados empleados)
        {
            bool paso = base.Modificar(empleados);
            return paso;
        }

        public override bool Eliminar(int id)
        {
            bool paso = base.Eliminar(id);
            return paso;
        }

        public override Empleados Buscar(int id)
        {
            Empleados empleados = base.Buscar(id);
            return empleados;
        }
    }
}
