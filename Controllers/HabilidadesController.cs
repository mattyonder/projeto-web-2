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
    public class HabilidadesController : Controller
    {
        private readonly AppDbContext _context;

        public HabilidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Habilidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Habilidades.ToListAsync());
        }

        // GET: Habilidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidades = await _context.Habilidades
                .FirstOrDefaultAsync(m => m.HabilidadeNrId == id);
            if (habilidades == null)
            {
                return NotFound();
            }

            return View(habilidades);
        }

        // GET: Habilidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Habilidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HabilidadeNrId,HabilidadeTxDescricao")] Habilidades habilidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(habilidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(habilidades);
        }

        // GET: Habilidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidades = await _context.Habilidades.FindAsync(id);
            if (habilidades == null)
            {
                return NotFound();
            }
            return View(habilidades);
        }

        // POST: Habilidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HabilidadeNrId,HabilidadeTxDescricao")] Habilidades habilidades)
        {
            if (id != habilidades.HabilidadeNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(habilidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HabilidadesExists(habilidades.HabilidadeNrId))
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
            return View(habilidades);
        }

        // GET: Habilidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var habilidades = await _context.Habilidades
                .FirstOrDefaultAsync(m => m.HabilidadeNrId == id);
            if (habilidades == null)
            {
                return NotFound();
            }

            return View(habilidades);
        }

        // POST: Habilidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var habilidades = await _context.Habilidades.FindAsync(id);
            if (habilidades != null)
            {
                _context.Habilidades.Remove(habilidades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HabilidadesExists(int id)
        {
            return _context.Habilidades.Any(e => e.HabilidadeNrId == id);
        }
    }
}
