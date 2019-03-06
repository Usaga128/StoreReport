using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using StoreReport.Data;
using StoreReport.Models;

namespace StoreReport.Controllers
{
   
    public class StoresController : Controller
    {
        private readonly ApplicationDbContext _context;
        public static string vID = null;
        public StoresController(ApplicationDbContext context)
        {
            _context = context;
        }
 
        //public async Task<IActionResult> Index(IFormCollection form, int page = 1)
        //{
        //    LoadViewBag();

        //    string id = form["searchQuery"].ToString();

        //    var itemList = _context.Store.AsNoTracking().OrderBy(s => s.FranchiseID);
        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        page = 1;
        //        itemList = _context.Store.AsNoTracking().Where(s => s.Name.Contains(id)).OrderBy(s => s.FranchiseID);

        //    }
        //    var model = await PagingList.CreateAsync<Store>(itemList, 8, page);

        //    return View(model);

        //}


         [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form, int page = 1)
        {
            LoadViewBag();
            string id = form["searchQuery"].ToString();
            vID = id;

            page = 1;
                var itemList  = _context.Store.AsNoTracking().Where(s => s.Name.Contains(id)).OrderBy(s => s.FranchiseID);


            var model = await PagingList.CreateAsync<Store>(itemList, 8, page);
           
            return View(model);

        }
        // GET: Items
        public async Task<IActionResult> Index(int page = 1)
        {
            LoadViewBag();
            var itemList = _context.Store.AsNoTracking().OrderBy(s => s.FranchiseID);
            if(vID!=null)
            {
                itemList = _context.Store.AsNoTracking().Where(s => s.Name.Contains(vID)).OrderBy(s => s.FranchiseID);
            }

            var model = await PagingList.CreateAsync<Store>(itemList, 8, page);
          
            return View(model);
        }



























 
        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            LoadViewBag();

            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Store
                .FirstOrDefaultAsync(m => m.StoreID == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }
      

        public  void LoadViewBag()
        {

            var franchiseslist =   _context.Franchise.OrderBy(model => model.Name).OrderBy(model => model.Status).ToList();
            ViewBag.StoreList = new SelectList(franchiseslist, "FranchiseID", "Name");
            


        }
      

        // GET: Stores/Create
        public IActionResult Create()
        {


            LoadViewBag();

            return View();
        }

        // POST: Stores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StoreID,Name,Phone,ContactName,Address,GeoAddress,CreatedBy,CreatedDate,Status,FranchiseID")] Store store)
        {
            LoadViewBag();

            if (ModelState.IsValid)
            {
                store.CreatedDate = DateTime.Now;
                _context.Add(store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

           
            return View(store);
           
        }

        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Store.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }
           
            return View(store);
        }

        // POST: Stores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StoreID,Name,Phone,ContactName,Address,GeoAddress,CreatedBy,CreatedDate,Status,FranchiseID")] Store store)
        {
            LoadViewBag();
            if (id != store.StoreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    store.CreatedDate = DateTime.Now;
                    _context.Update(store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StoreExists(store.StoreID))
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
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var store = await _context.Store
                .FirstOrDefaultAsync(m => m.StoreID == id);
            if (store == null)
            {
                return NotFound();
            }

            return View(store);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            LoadViewBag();
            var store = await _context.Store.FindAsync(id);
            _context.Store.Remove(store);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StoreExists(int id)
        {

            return _context.Store.Any(e => e.StoreID == id);
        }
    }
}
