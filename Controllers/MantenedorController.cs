using Microsoft.AspNetCore.Mvc;

using WebApplication1.Datos;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MantenedorController : Controller
    {

        ClienteDatos _ClienteDatos = new ClienteDatos();

        public IActionResult Listar()
        {
            //LA VISTA MOSTRARÁ UNA LISTA DE CONTACTOS
            var oLista = _ClienteDatos.Listar();

            return View(oLista);
        }

        public IActionResult Guardar()
        {
            //METODO SOLO DEVUELVE LA VISTA
            return View();
        }

        [HttpPost]
        public IActionResult Guardar(ClienteModel oCliente)
        {
            //METODO RECIBE EL OBJETO PARA GUARDARLO EN BD
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ClienteDatos.Guardar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else 
                return View();
        }

        public IActionResult Editar(int Id_c)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var ocontacto = _ClienteDatos.Obtener(Id_c);
            return View(ocontacto);
        }

        [HttpPost]
        public IActionResult Editar(ClienteModel oCliente)
        {
            if (!ModelState.IsValid)
                return View();


            var respuesta = _ClienteDatos.Editar(oCliente);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }


        public IActionResult Eliminar(int Id_c)
        {
            //METODO SOLO DEVUELVE LA VISTA
            var oContacto = _ClienteDatos.Obtener(Id_c);
            return View(oContacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ClienteModel oCliente)
        {
  
            var respuesta = _ClienteDatos.Eliminar(oCliente.Id_c);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
