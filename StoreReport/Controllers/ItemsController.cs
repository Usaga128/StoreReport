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

    public class ItemsController : Controller
    {
        public static string vID = null;
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public void LoadViewBag()
        {

            var productlist = _context.ProductType.OrderBy(modelType => modelType.Name).ToList();
            ViewBag.productlist = new SelectList(productlist, "ProductTypeID", "Name");

        }
        [HttpPost]
        public async Task<IActionResult> Index(IFormCollection form, int page = 1)
        {
            LoadViewBag();
            string id = form["searchQuery"].ToString();
            vID = id;

            page = 1;
                var itemList  = _context.Item.AsNoTracking().Where(s => s.Name.Contains(id)).OrderBy(s => s.Name);
                 
             
            var model = await PagingList.CreateAsync<Item>(itemList, 8, page);
           
            return View(model);

        }
        // GET: Items
        public async Task<IActionResult> Index(int page = 1)
        {
            LoadViewBag();
            var itemList = _context.Item.AsNoTracking().OrderBy(s => s.Name);
            if(vID!=null)
            {
                itemList = _context.Item.AsNoTracking().Where(s => s.Name.Contains(vID)).OrderBy(s => s.Name);
            }

            var model = await PagingList.CreateAsync<Item>(itemList, 8, page);
          
            return View(model);
        }

        // GET: Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Items/Create
        public IActionResult Create()
        {
            LoadViewBag();
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemID,ProductCode,Name,Description,CreatedDate,CreatedBy,ProductTypeID")] Item item)
        {
            LoadViewBag();
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        // GET: Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemID,ProductCode,Name,Description,CreatedDate,CreatedBy,ProductTypeID")] Item item)
        {
            LoadViewBag();
            if (id != item.ItemID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(item);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.ItemID))
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
            return View(item);
        }

        // GET: Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            LoadViewBag();
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .FirstOrDefaultAsync(m => m.ItemID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            LoadViewBag();
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ItemID == id);
        }
    }
}
