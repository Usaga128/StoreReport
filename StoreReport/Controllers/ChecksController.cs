using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreReport.Data;
using StoreReport.Models;

namespace StoreReport.Controllers
{
    public class ChecksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChecksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Checks
        public async Task<IActionResult> Index()
        {
            return View(await _context.Checks.ToListAsync());
        }

        // GET: Checks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checks = await _context.Checks
                .FirstOrDefaultAsync(m => m.ChecksID == id);
            if (checks == null)
            {
                return NotFound();
            }

            return View(checks);
        }

        // GET: Checks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Checks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChecksID,Question,QuestionType")] Checks checks)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(checks);
        }

        // GET: Checks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checks = await _context.Checks.FindAsync(id);
            if (checks == null)
            {
                return NotFound();
            }
            return View(checks);
        }

        // POST: Checks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChecksID,Question,QuestionType")] Checks checks)
        {
            if (id != checks.ChecksID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChecksExists(checks.ChecksID))
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
            return View(checks);
        }

        // GET: Checks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checks = await _context.Checks
                .FirstOrDefaultAsync(m => m.ChecksID == id);
            if (checks == null)
            {
                return NotFound();
            }

            return View(checks);
        }

        // POST: Checks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checks = await _context.Checks.FindAsync(id);
            _context.Checks.Remove(checks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChecksExists(int id)
        {
            return _context.Checks.Any(e => e.ChecksID == id);
        }
    }
}
