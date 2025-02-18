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
    public class CandidaturasController : Controller
    {
        private readonly AppDbContext _context;

        public CandidaturasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Candidaturas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Candidaturas.ToListAsync());
        }

        // GET: Candidaturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturas = await _context.Candidaturas
                .FirstOrDefaultAsync(m => m.CandidaturaNrId == id);
            if (candidaturas == null)
            {
                return NotFound();
            }

            return View(candidaturas);
        }

        // GET: Candidaturas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidaturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidaturaNrId,VoluntarioNrId,OportunidadeNrId,CandidaturaTxStatus,CandidaturaTxDataCandidatura")] Candidaturas candidaturas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidaturas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidaturas);
        }

        // GET: Candidaturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturas = await _context.Candidaturas.FindAsync(id);
            if (candidaturas == null)
            {
                return NotFound();
            }
            return View(candidaturas);
        }

        // POST: Candidaturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidaturaNrId,VoluntarioNrId,OportunidadeNrId,CandidaturaTxStatus,CandidaturaTxDataCandidatura")] Candidaturas candidaturas)
        {
            if (id != candidaturas.CandidaturaNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidaturas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidaturasExists(candidaturas.CandidaturaNrId))
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
            return View(candidaturas);
        }

        // GET: Candidaturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidaturas = await _context.Candidaturas
                .FirstOrDefaultAsync(m => m.CandidaturaNrId == id);
            if (candidaturas == null)
            {
                return NotFound();
            }

            return View(candidaturas);
        }

        // POST: Candidaturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidaturas = await _context.Candidaturas.FindAsync(id);
            if (candidaturas != null)
            {
                _context.Candidaturas.Remove(candidaturas);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidaturasExists(int id)
        {
            return _context.Candidaturas.Any(e => e.CandidaturaNrId == id);
        }
    }
}
