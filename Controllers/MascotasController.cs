using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalWeb.Models;

namespace FinalWeb.Controllers
{
    public class MascotasController : Controller
    {
        private readonly BDVETERINARIACORECONTEXT _context;

        public MascotasController(BDVETERINARIACORECONTEXT context)
        {
            _context = context;
        }

        // GET: Mascotas
        public async Task<IActionResult> Index()
        {
            var bDVETERINARIACORECONTEXT = _context.Mascotas.
                Include(m => m.ClienteNavigation).
                Include(m => m.TratamientoNavigation).
                Include(m => m.VeterinarioNavigation);
            return View(await bDVETERINARIACORECONTEXT.ToListAsync());
        }
        public async Task<IActionResult> IndexE()
        {
            var bDVETERINARIACORECONTEXT = _context.Mascotas.Include(m => m.ClienteNavigation).Include(m => m.TratamientoNavigation).Include(m => m.VeterinarioNavigation);
            return View(await bDVETERINARIACORECONTEXT.ToListAsync());
        }

        // GET: Mascotas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.ClienteNavigation)
                .Include(m => m.TratamientoNavigation)
                .Include(m => m.VeterinarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }

            return View(mascota);
        }

        // GET: Mascotas/Create
        public IActionResult Create()
        {
            var Genero = new List<string> { "Femenino", "Masculino" };
            ViewBag.Genero = new SelectList(Genero);
            var Animal = new List<string> { "Perro", "Gato", "Conejo", "Ave", "Hamster" };
            ViewBag.Animal = new SelectList(Animal);
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Id", "Nombre");
            ViewData["Tratamiento"] = new SelectList(_context.Tratamientos, "Id", "Nombre");
            ViewData["Veterinario"] = new SelectList(_context.Empleados.Where(e => e.Cargo == "Veterinario"), "Id", "Nombre");
            return View();
        }

        // POST: Mascotas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Niup,Nombre,Raza,Animal,Cliente,Genero,Peso,Tratamiento,Fecha,Veterinario")] Mascota mascota)
        {
            if (ModelState.IsValid)
            {
                var tratamiento = await _context.Tratamientos.FindAsync(mascota.Tratamiento);

                // Disminuir la cantidad del tratamiento
                tratamiento.Cantidad -= 1;
                _context.Add(mascota);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Id", "Nombre", mascota.Cliente);
            ViewData["Tratamiento"] = new SelectList(_context.Tratamientos, "Id", "Nombre", mascota.Tratamiento);
            ViewData["Veterinario"] = new SelectList(_context.Empleados.Where(e => e.Cargo == "Veterinario"), "Id", "Nombre", mascota.Veterinario);
            return View(mascota);
        }

        // GET: Mascotas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota == null)
            {
                return NotFound();
            }
            
            var Genero = new List<string> { "Femenino", "Masculino" };
            ViewBag.Genero = new SelectList(Genero);
            var Animal = new List<string> { "Perro", "Gato", "Conejo", "Ave", "Hamster" };
            ViewBag.Animal = new SelectList(Animal);
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Id", "Nombre", mascota.Cliente);
            ViewData["Tratamiento"] = new SelectList(_context.Tratamientos, "Id", "Nombre", mascota.Tratamiento);
            ViewData["Veterinario"] = new SelectList(_context.Empleados.Where(e => e.Cargo == "Veterinario"), "Id", "Nombre", mascota.Veterinario);
            return View(mascota);
        }

        // POST: Mascotas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Niup,Nombre,Raza,Animal,Cliente,Genero,Peso,Tratamiento,Fecha,Veterinario")] Mascota mascota, int tratamientoAnterior)
        {
            if (id != mascota.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Verificar si el tratamiento ha cambiado
                    if (mascota.Tratamiento != tratamientoAnterior)
                    {
                        // Disminuir la cantidad del nuevo tratamiento
                        var nuevoTratamiento = await _context.Tratamientos.FindAsync(mascota.Tratamiento);
                        nuevoTratamiento.Cantidad -= 1;
                        _context.Update(nuevoTratamiento);

                        // Aumentar la cantidad del tratamiento anterior
                        var anteriorTratamiento = await _context.Tratamientos.FindAsync(tratamientoAnterior);
                        if (anteriorTratamiento != null)
                        {
                            anteriorTratamiento.Cantidad += 1;
                            _context.Update(anteriorTratamiento);
                        }
                    }

                    _context.Update(mascota);
                    await _context.SaveChangesAsync();
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!MascotaExists(mascota.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Cliente"] = new SelectList(_context.Clientes, "Id", "Nombre", mascota.Cliente);
            ViewData["Tratamiento"] = new SelectList(_context.Tratamientos, "Id", "Nombre", mascota.Tratamiento);
            ViewData["Veterinario"] = new SelectList(_context.Empleados, "Id", "Nombre", mascota.Veterinario);
            return View(mascota);
        }

        // GET: Mascotas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mascota = await _context.Mascotas
                .Include(m => m.ClienteNavigation)
                .Include(m => m.TratamientoNavigation)
                .Include(m => m.VeterinarioNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mascota == null)
            {
                return NotFound();
            }
            var tratamiento = await _context.Tratamientos.FindAsync(mascota.Tratamiento);

            // Disminuir la cantidad del tratamiento
            tratamiento.Cantidad += 1;

            // Actualizar la base de datos
            _context.Update(tratamiento);
            await _context.SaveChangesAsync();

            return View(mascota);
        }

        // POST: Mascotas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mascota = await _context.Mascotas.FindAsync(id);
            if (mascota != null)
            {
                _context.Mascotas.Remove(mascota);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexE));
        }

        private bool MascotaExists(int id)
        {
            return _context.Mascotas.Any(e => e.Id == id);
        }
    }
}
