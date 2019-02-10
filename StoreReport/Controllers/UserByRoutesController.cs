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
    public class UserByRoutesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public void LoadViewBag()
        {

            var userlist = _context.Users.OrderBy(model => model.Name).OrderBy(model => model.Status).ToList();
            ViewBag.UserList = new SelectList(userlist, "UserName", "Name");

            var routelist = _context.Route.OrderBy(model => model.RouteName).ToList();
            ViewBag.routelist = new SelectList(routelist, "RouteID", "RouteName");

        }

        public UserByRoutesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UserByRoutes
        public async Task<IActionResult> Index()
        {
            LoadViewBag();
            return View(await _context.UserByRoute.ToListAsync());
        }

        // GET: UserByRoutes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userByRoute = await _context.UserByRoute
                .FirstOrDefaultAsync(m => m.UserByRouteID == id);
            if (userByRoute == null)
            {
                return NotFound();
            }

            return View(userByRoute);
        }

        // GET: UserByRoutes/Create
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }

        // POST: UserByRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserByRouteID,UserName,RouteId,CreatedBy,CreatedDate")] UserByRoute userByRoute)
        {
            if (ModelState.IsValid)
            {
                userByRoute.CreatedDate = DateTime.Now;
                userByRoute.CreatedBy = User.Identity.Name;
                _context.Add(userByRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userByRoute);
        }

        // GET: UserByRoutes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var userByRoute = await _context.UserByRoute.FindAsync(id);
            if (userByRoute == null)
            {
                return NotFound();
            }
            return View(userByRoute);
        }

        // POST: UserByRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserByRouteID,UserName,RouteId,CreatedBy,CreatedDate")] UserByRoute userByRoute)
        {
            LoadViewBag();
            if (id != userByRoute.UserByRouteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    userByRoute.CreatedDate = DateTime.Now;
                    userByRoute.CreatedBy = User.Identity.Name;
                    _context.Update(userByRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserByRouteExists(userByRoute.UserByRouteID))
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
            return View(userByRoute);
        }

        // GET: UserByRoutes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var userByRoute = await _context.UserByRoute
                .FirstOrDefaultAsync(m => m.UserByRouteID == id);
            if (userByRoute == null)
            {
                return NotFound();
            }

            return View(userByRoute);
        }

        // POST: UserByRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userByRoute = await _context.UserByRoute.FindAsync(id);
            _context.UserByRoute.Remove(userByRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserByRouteExists(int id)
        {
            return _context.UserByRoute.Any(e => e.UserByRouteID == id);
        }
    }
}
