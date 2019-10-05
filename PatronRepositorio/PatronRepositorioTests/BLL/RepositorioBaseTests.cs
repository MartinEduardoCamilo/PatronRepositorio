using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
          
        }

        [TestMethod()]
        public void GuardarTest()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados e = new Empleados();
            e.EmpleadoID = 0;
            e.Fecha = DateTime.Now;
            e.Direccion = "Grullo #23";
            e.Nombre = "Jose";
            e.Telefono = "809-902-2398";
            e.Celular = "829-902-2398";
            e.Cedula = "402-1291299-7";
            e.sueldo = 2890;
            e.Incentivo = 89;
            Assert.IsTrue(repositorio.Guardar(e));
        }

        [TestMethod()]
        public void ModificarTest()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Empleados e = new Empleados();
            e.EmpleadoID = 2;
            e.Fecha = DateTime.Now;
            e.Direccion = "Grullo #23";
            e.Nombre = "Jose Martin";
            e.Telefono = "809-902-2398";
            e.Celular = "829-902-2398";
            e.Cedula = "402-1291299-7";
            e.sueldo = 2890;
            e.Incentivo = 89;
            Assert.IsTrue(repositorio.Modificar(e));
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Empleados> Base = new RepositorioBase<Empleados>();
            Empleados e = new Empleados();
            e = Base.Buscar(2);
            Assert.IsNotNull(e);
        }

        [TestMethod()]
        public void GetListTest()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            List<Empleados> lista = new List<Empleados>();
            lista = repositorio.GetList(p => true);
            Assert.IsNotNull(lista);
        }

        [TestMethod()]
        public void DisposeTest()
        {
           
        }

        [TestMethod()]
        public void EliminarTest()
        {
            RepositorioBase<Empleados> repositorio = new RepositorioBase<Empleados>();
            Assert.IsTrue(repositorio.Eliminar(2));
        }
    }
}