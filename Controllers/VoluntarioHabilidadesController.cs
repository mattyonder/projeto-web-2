using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWeb2.Data;
using ProjetoWeb2.Models;

namespace ProjetoWeb2.Controllers
{
    public class VoluntarioHabilidadesController : Controller
    {
        private readonly AppDbContext _context;

        public VoluntarioHabilidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: VoluntarioHabilidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.VoluntarioHabilidades.ToListAsync());
        }

        // GET: VoluntarioHabilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioHabilidades = await _context.VoluntarioHabilidades
                .FirstOrDefaultAsync(m => m.VoluntarioHabilidadesNrId == id);
            if (voluntarioHabilidades == null)
            {
                return NotFound();
            }

            return View(voluntarioHabilidades);
        }

        // GET: VoluntarioHabilidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VoluntarioHabilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoluntarioHabilidadesNrId,VoluntarioNrId,VabilidadeNrId")] VoluntarioHabilidades voluntarioHabilidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntarioHabilidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voluntarioHabilidades);
        }

        // GET: VoluntarioHabilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioHabilidades = await _context.VoluntarioHabilidades.FindAsync(id);
            if (voluntarioHabilidades == null)
            {
                return NotFound();
            }
            return View(voluntarioHabilidades);
        }

        // POST: VoluntarioHabilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoluntarioHabilidadesNrId,VoluntarioNrId,VabilidadeNrId")] VoluntarioHabilidades voluntarioHabilidades)
        {
            if (id != voluntarioHabilidades.VoluntarioHabilidadesNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntarioHabilidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntarioHabilidadesExists(voluntarioHabilidades.VoluntarioHabilidadesNrId))
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
            return View(voluntarioHabilidades);
        }

        // GET: VoluntarioHabilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarioHabilidades = await _context.VoluntarioHabilidades
                .FirstOrDefaultAsync(m => m.VoluntarioHabilidadesNrId == id);
            if (voluntarioHabilidades == null)
            {
                return NotFound();
            }

            return View(voluntarioHabilidades);
        }

        // POST: VoluntarioHabilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntarioHabilidades = await _context.VoluntarioHabilidades.FindAsync(id);
            if (voluntarioHabilidades != null)
            {
                _context.VoluntarioHabilidades.Remove(voluntarioHabilidades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntarioHabilidadesExists(int id)
        {
            return _context.VoluntarioHabilidades.Any(e => e.VoluntarioHabilidadesNrId == id);
        }
    }
}
