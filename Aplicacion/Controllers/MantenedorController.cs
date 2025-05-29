using Microsoft.AspNetCore.Mvc;
using crudcore.Datos;
using crudcore.Models;
namespace crudcore.Controllers
{
    public class MantenedorController : Controller
    {
        ContactoDatos contactoDatos=new ContactoDatos();
        public IActionResult Listar()
        {
            var lista=contactoDatos.Listar();
            return View(lista);
        }
        public IActionResult Guardar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            if(ModelState.IsValid==false)
            {
                return View();
            }

            if (contactoDatos.Guardar(contacto))
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Editar(int IdContacto)
        {
            var contacto=contactoDatos.Obtener(IdContacto);
            return View(contacto);
        }
        [HttpPost]
        public IActionResult Actualizar(ContactoModel contacto)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            if (contactoDatos.Actualizar(contacto))
                return RedirectToAction("Listar");
            else
                return View();
        }
        public IActionResult Eliminar(int IdContacto)
        {
            var contacto = contactoDatos.Obtener(IdContacto);
            return View(contacto);
        }
        [HttpPost]
        public IActionResult Eliminar(ContactoModel contacto)
        {
            if (contactoDatos.Eliminar(contacto.IdContacto))
                return RedirectToAction("Listar");
            else
                return View();
        }

    }
}
