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
    public class AtividadesController : Controller
    {
        private readonly AppDbContext _context;

        public AtividadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Atividades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Atividades.ToListAsync());
        }

        // GET: Atividades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades
                .FirstOrDefaultAsync(m => m.AtividadeNrId == id);
            if (atividades == null)
            {
                return NotFound();
            }

            return View(atividades);
        }

        // GET: Atividades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Atividades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AtividadeNrId,VoluntarioNrId,InstituicaoNrId,OportunidadeNrId,AtividadeDtDataInicio,AtividadeDtDataFim,AtividadeNrHorasTrabalhadas")] Atividades atividades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atividades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(atividades);
        }

        // GET: Atividades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades.FindAsync(id);
            if (atividades == null)
            {
                return NotFound();
            }
            return View(atividades);
        }

        // POST: Atividades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AtividadeNrId,VoluntarioNrId,InstituicaoNrId,OportunidadeNrId,AtividadeDtDataInicio,AtividadeDtDataFim,AtividadeNrHorasTrabalhadas")] Atividades atividades)
        {
            if (id != atividades.AtividadeNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atividades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtividadesExists(atividades.AtividadeNrId))
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
            return View(atividades);
        }

        // GET: Atividades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var atividades = await _context.Atividades
                .FirstOrDefaultAsync(m => m.AtividadeNrId == id);
            if (atividades == null)
            {
                return NotFound();
            }

            return View(atividades);
        }

        // POST: Atividades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atividades = await _context.Atividades.FindAsync(id);
            if (atividades != null)
            {
                _context.Atividades.Remove(atividades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtividadesExists(int id)
        {
            return _context.Atividades.Any(e => e.AtividadeNrId == id);
        }
    }
}
