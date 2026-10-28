using FinalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FinalWeb.Controllers
{
    public class GraficaPController : Controller
    {
        private readonly BDVETERINARIACORECONTEXT _contexto;

        public GraficaPController(BDVETERINARIACORECONTEXT contexto)
        {
            _contexto = contexto;
        }

        public ActionResult BuscarId()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MostrarGrafica(int idVeterinario)
        {
            var mascotas = _contexto.Mascotas
                .Include(m => m.TratamientoNavigation) // Asegúrate de incluir la navegación de tratamiento
                .Where(m => m.Veterinario == idVeterinario)
                .ToList();

            // Obtener todos los tratamientos realizados en estas mascotas
            var tratamientos = mascotas
                .Where(m => m.TratamientoNavigation != null)
                .Select(m => m.TratamientoNavigation.Nombre)
                .ToList();

            // Contar la cantidad de cada tipo de tratamiento
            var conteoTratamientos = tratamientos
                .GroupBy(t => t)
                .ToDictionary(g => g.Key, g => g.Count());

            // Crear una lista de ProcedimientoViewModel con el nombre del tratamiento y su cantidad
            var procedimientos = conteoTratamientos
                .Select(pair => new ProcedimientoViewModel { Nombre = pair.Key, Cantidad = pair.Value })
                .ToList();

            // Agregar una línea para imprimir en la consola del servidor para depuración
            foreach (var procedimiento in procedimientos)
            {
                Console.WriteLine($" Controladorrr Nombre: {procedimiento.Nombre}, Cantidad: {procedimiento.Cantidad}");
            }

            return View("MostrarGrafica", procedimientos);
        }
    }
}