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
    public class InstituicoesController : Controller
    {
        private readonly AppDbContext _context;

        public InstituicoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Instituicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instituicoes.ToListAsync());
        }

        // GET: Instituicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.InstituicaoNrId == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // GET: Instituicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instituicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstituicaoNrId,InstituicaoTxCnpj,InstituicaoTxNome,InstituicaoTxAreaAtuacao,InstituicaoTxMissao,InstituicaoTxWebsite,InstituicaoTxContato,InstituicaoTxEndereco")] Instituicoes instituicoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instituicoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instituicoes);
        }

        // GET: Instituicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes.FindAsync(id);
            if (instituicoes == null)
            {
                return NotFound();
            }
            return View(instituicoes);
        }

        // POST: Instituicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstituicaoNrId,InstituicaoTxCnpj,InstituicaoTxNome,InstituicaoTxAreaAtuacao,InstituicaoTxMissao,InstituicaoTxWebsite,InstituicaoTxContato,InstituicaoTxEndereco")] Instituicoes instituicoes)
        {
            if (id != instituicoes.InstituicaoNrId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instituicoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstituicoesExists(instituicoes.InstituicaoNrId))
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
            return View(instituicoes);
        }

        // GET: Instituicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instituicoes = await _context.Instituicoes
                .FirstOrDefaultAsync(m => m.InstituicaoNrId == id);
            if (instituicoes == null)
            {
                return NotFound();
            }

            return View(instituicoes);
        }

        // POST: Instituicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instituicoes = await _context.Instituicoes.FindAsync(id);
            if (instituicoes != null)
            {
                _context.Instituicoes.Remove(instituicoes);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstituicoesExists(int id)
        {
            return _context.Instituicoes.Any(e => e.InstituicaoNrId == id);
        }
    }
}
