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
    public class OportunidadesController : Controller
    {
        private readonly AppDbContext _context;

        public OportunidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Oportunidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Oportunidades.ToListAsync());
        }

        // GET: Oportunidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.OportunidadeNrId == id);
            if (oportunidades == null)
            {
                return NotFound();
            }

            return View(oportunidades);
        }

        // GET: Oportunidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Oportunidades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OportunidadeNrId,InstituicaoNrId,OportunidadeTxTitulo,OportunidadeTxDescricao,OportunidadeTxLocalizacao,OportunidadeTxTipoAtividade,OportunidadeTxDisponibilidade")] Oportunidades oportunidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oportunidades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oportunidades);
        }

        // GET: Oportunidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades.FindAsync(id);
            if (oportunidades == null)
            {
                return NotFound();
            }
            return View(oportunidades);
        }

        // POST: Oportunidades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OportunidadeNrId,InstituicaoNrId,OportunidadeTxTitulo,OportunidadeTxDescricao,OportunidadeTxLocalizacao,OportunidadeTxTipoAtividade,OportunidadeTxDisponibilidade")] Oportunidades oportunidades)
        {
            if (id != oportunidades.OportunidadeNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oportunidades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OportunidadesExists(oportunidades.OportunidadeNrId))
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
            return View(oportunidades);
        }

        // GET: Oportunidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oportunidades = await _context.Oportunidades
                .FirstOrDefaultAsync(m => m.OportunidadeNrId == id);
            if (oportunidades == null)
            {
                return NotFound();
            }

            return View(oportunidades);
        }

        // POST: Oportunidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oportunidades = await _context.Oportunidades.FindAsync(id);
            if (oportunidades != null)
            {
                _context.Oportunidades.Remove(oportunidades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OportunidadesExists(int id)
        {
            return _context.Oportunidades.Any(e => e.OportunidadeNrId == id);
        }
    }
}
