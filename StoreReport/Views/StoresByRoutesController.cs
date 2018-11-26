using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreReport.Data;
using StoreReport.Models;

namespace StoreReport.Views
{
    public class StoresByRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StoresByRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StoresByRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StoresByRoute.ToListAsync());
        }

        // GET: StoresByRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storesByRoute = await _context.StoresByRoute
                .FirstOrDefaultAsync(m => m.StoresByRouteID == id);
            if (storesByRoute == null)
            {
                return NotFound();
            }

            return View(storesByRoute);
        }

        // GET: StoresByRoutes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StoresByRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoresByRouteID,StoreID,RouteID,RouteName,UserName,CreatedDate,Order")] StoresByRoute storesByRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(storesByRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(storesByRoute);
        }

        // GET: StoresByRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storesByRoute = await _context.StoresByRoute.FindAsync(id);
            if (storesByRoute == null)
            {
                return NotFound();
            }
            return View(storesByRoute);
        }

        // POST: StoresByRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoresByRouteID,StoreID,RouteID,RouteName,UserName,CreatedDate,Order")] StoresByRoute storesByRoute)
        {
            if (id != storesByRoute.StoresByRouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(storesByRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoresByRouteExists(storesByRoute.StoresByRouteID))
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
            return View(storesByRoute);
        }

        // GET: StoresByRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var storesByRoute = await _context.StoresByRoute
                .FirstOrDefaultAsync(m => m.StoresByRouteID == id);
            if (storesByRoute == null)
            {
                return NotFound();
            }

            return View(storesByRoute);
        }

        // POST: StoresByRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var storesByRoute = await _context.StoresByRoute.FindAsync(id);
            _context.StoresByRoute.Remove(storesByRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoresByRouteExists(int id)
        {
            return _context.StoresByRoute.Any(e => e.StoresByRouteID == id);
        }
    }
}
