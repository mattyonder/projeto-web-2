﻿using System;
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
    public class VoluntariosController : Controller
    {
        private readonly AppDbContext _context;

        public VoluntariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Voluntarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Voluntarios.ToListAsync());
        }

        // GET: Voluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios
                .FirstOrDefaultAsync(m => m.VoluntarioNrid == id);
            if (voluntarios == null)
            {
                return NotFound();
            }

            return View(voluntarios);
        }

        // GET: Voluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Voluntarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoluntarioNrid,VolutarioNTxome,VoluntarioDtDataNascimento,VoluntarioTxCpf,VoluntarioTxEmail,VoluntarioTxTelefone,VoluntarioTxEndereco")] Voluntarios voluntarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(voluntarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(voluntarios);
        }

        // GET: Voluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios.FindAsync(id);
            if (voluntarios == null)
            {
                return NotFound();
            }
            return View(voluntarios);
        }

        // POST: Voluntarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoluntarioNrid,VolutarioNTxome,VoluntarioDtDataNascimento,VoluntarioTxCpf,VoluntarioTxEmail,VoluntarioTxTelefone,VoluntarioTxEndereco")] Voluntarios voluntarios)
        {
            if (id != voluntarios.VoluntarioNrid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(voluntarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VoluntariosExists(voluntarios.VoluntarioNrid))
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
            return View(voluntarios);
        }

        // GET: Voluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var voluntarios = await _context.Voluntarios
                .FirstOrDefaultAsync(m => m.VoluntarioNrid == id);
            if (voluntarios == null)
            {
                return NotFound();
            }

            return View(voluntarios);
        }

        // POST: Voluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var voluntarios = await _context.Voluntarios.FindAsync(id);
            if (voluntarios != null)
            {
                _context.Voluntarios.Remove(voluntarios);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VoluntariosExists(int id)
        {
            return _context.Voluntarios.Any(e => e.VoluntarioNrid == id);
        }
    }
}
