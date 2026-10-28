using FinalWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace FinalWeb.Controllers
{
    public class ReportePDFController : Controller
    {
        private readonly BDVETERINARIACORECONTEXT contexto;
        public ReportePDFController(BDVETERINARIACORECONTEXT contexto)
        {
            this.contexto = contexto;
        }
        // GET: ReportePDFController
        public IActionResult BuscarId()
        {
            return View();
        }

        // POST: ReportePDFController/GenerateReport
        [HttpPost]
        public async Task<IActionResult> GenerateReport(int mascotaNiup)
        {
            var mascotas = await contexto.Mascotas
                .Where(m => m.Niup == mascotaNiup)
                .Include(m => m.ClienteNavigation)
                .Include(m => m.TratamientoNavigation)
                .Include(m => m.VeterinarioNavigation)
                .ToListAsync();

            if (mascotas == null || !mascotas.Any())
            {
                return PartialView("~/Views/ReportePDF/Error.cshtml");
            }

            return new ViewAsPdf("~/Views/ReportePDF/IndexR.cshtml", mascotas)
            {
                PageSize = Rotativa.AspNetCore.Options.Size.Letter,
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Portrait
            };
        }
    }
}
