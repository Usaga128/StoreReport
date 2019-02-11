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
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            LoadViewBag();
            return View();
        }

        public IActionResult Register()
        {
            LoadViewBag();

            ViewData["Message"] = "";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Página de contacto.";

            return View();
        }

        public IActionResult Error()
        {
            return null;
        }

        public void LoadViewBag()
        {

            var productlist = _context.Store.OrderBy(modelType => modelType.Name).ToList();
            ViewBag.storelist = new SelectList(productlist, "StoreID", "Name");

            var routelist = _context.Route.OrderBy(modelType => modelType.RouteName).ToList();
            ViewBag.routelist = new SelectList(routelist, "RouteID", "RouteName");

            var itemlist = _context.Item.OrderBy(modelType => modelType.ItemID).ToList();
            ViewBag.itemlist = new SelectList(itemlist, "ItemID", "Name");

            var checklist = _context.Checks.OrderBy(modelType => modelType.ChecksID).ToList();
            ViewBag.checklist = new SelectList(checklist, "ChecksID", "Question");


        }
    }
}
