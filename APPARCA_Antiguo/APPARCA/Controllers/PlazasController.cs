using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using APPARCA.Data;
using APPARCA.Models;

namespace APPARCA.Controllers
{
    public class PlazasController : Controller
    {
        private readonly ApparcaContexto _context;

        public PlazasController(ApparcaContexto context)
        {
            _context = context;
        }

        // GET: Plazas
        public async Task<IActionResult> Index()
        {
            var apparcaContexto = _context.Plazas.Include(p => p.Arrendador);
            return View(await apparcaContexto.ToListAsync());
        }

        // GET: Plazas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plazas == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas
                .Include(p => p.Arrendador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plaza == null)
            {
                return NotFound();
            }

            return View(plaza);
        }

        // GET: Plazas/Create
        public IActionResult Create()
        {
            ViewData["ArrendadorId"] = new SelectList(_context.Usuarios, "Id", "Id");
            return View();
        }

        // POST: Plazas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ArrendadorId,Latitud,Longitud,Direccion,Ancho,Largo,PrecioHora,Imagen,HoraInicio,HoraFinal,FechaInicio,FechaFinal,formatoImagen,PrecioMando,EsVerificada,PrecioMes")] Plaza plaza, string latitud, string longitud)
        {
            IFormFile file = Request.Form.Files[0];
            plaza.formatoImagen = file.ContentType;

            plaza.Imagen = ConvertToBytes(file);
            plaza.EsVerificada=false;

            _context.Add(plaza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        private byte[] ConvertToBytes(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.OpenReadStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        // GET: Plazas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Plazas == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas.FindAsync(id);
            if (plaza == null)
            {
                return NotFound();
            }
            ViewData["ArrendadorId"] = new SelectList(_context.Usuarios, "Id", "Id", plaza.ArrendadorId);
            return View(plaza);
        }

        // POST: Plazas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ArrendadorId,Latitud,Longitud,Direccion,Ancho,Largo,PrecioHora,Imagen,HoraInicio,HoraFinal,FechaInicio,FechaFinal,formatoImagen,PrecioMando,EsVerificada")] Plaza plaza)
        {
            if (id != plaza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlazaExists(plaza.Id))
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
            ViewData["ArrendadorId"] = new SelectList(_context.Usuarios, "Id", "Id", plaza.ArrendadorId);
            return View(plaza);
        }

        // GET: Plazas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plazas == null)
            {
                return NotFound();
            }

            var plaza = await _context.Plazas
                .Include(p => p.Arrendador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plaza == null)
            {
                return NotFound();
            }

            return View(plaza);
        }

        // POST: Plazas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plazas == null)
            {
                return Problem("Entity set 'ApparcaContexto.Plazas'  is null.");
            }
            var plaza = await _context.Plazas.FindAsync(id);
            if (plaza != null)
            {
                _context.Plazas.Remove(plaza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlazaExists(int id)
        {
          return _context.Plazas.Any(e => e.Id == id);
        }

        public ActionResult getImage(int idPlaza)
        {
            Plaza plaza = _context.Plazas.Find(idPlaza);
            byte[] byteImage = plaza.Imagen;

            /*MemoryStream memoryStream = new MemoryStream(byteImage);

            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();

            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position=0;

            return File(memoryStream, "image/jpg");*/

            return File(byteImage, plaza.formatoImagen.ToString());
        }
    }
}
