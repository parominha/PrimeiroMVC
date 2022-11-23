using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrimeiroMVC.Data;
using PrimeiroMVC.EF;

namespace PrimeiroMVC.Controllers
{
    public class PalomasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PalomasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Palomas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paloma.ToListAsync());
        }

        // GET: Palomas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paloma = await _context.Paloma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paloma == null)
            {
                return NotFound();
            }

            return View(paloma);
        }

        // GET: Palomas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Palomas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,DataNascimento,Ativo,Sexo")] Paloma paloma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paloma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paloma);
        }

        // GET: Palomas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paloma = await _context.Paloma.FindAsync(id);
            if (paloma == null)
            {
                return NotFound();
            }
            return View(paloma);
        }

        // POST: Palomas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,DataNascimento,Ativo,Sexo")] Paloma paloma)
        {
            if (id != paloma.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paloma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalomaExists(paloma.Id))
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
            return View(paloma);
        }

        // GET: Palomas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paloma = await _context.Paloma
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paloma == null)
            {
                return NotFound();
            }

            return View(paloma);
        }

        // POST: Palomas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paloma = await _context.Paloma.FindAsync(id);
            _context.Paloma.Remove(paloma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalomaExists(int id)
        {
            return _context.Paloma.Any(e => e.Id == id);
        }
    }
}
