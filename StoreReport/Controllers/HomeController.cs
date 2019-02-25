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


        public JsonResult GetStoresByRoute(string route)
        {
            var storebyroutelist = _context.StoresByRoute.OrderBy(modelType => modelType.RouteID).ToList();
            var storetlist = _context.Store.OrderBy(modelType => modelType.Name).ToList();

            List<Store> newList = new List<Store>();

            foreach (var item in storebyroutelist)
            {
                if (item.RouteID.ToString() == route)
                {

                    var vCurrentDay = GetCurrentDay();
                    if (item.DaysOfWeek.Contains(vCurrentDay))
                    {
                        foreach (var item2 in storetlist)
                    {
                        if (item2.StoreID.ToString() == item.StoreID.ToString())
                        {
                            
                            // SelectListItem selListItem = new SelectListItem() { Value = item2.RouteID.ToString(), Text = item2.RouteName };
                            Store vItem = new Store();

                            vItem.StoreID = item2.StoreID;
                            vItem.Name = item2.Name;
                            newList.Add(vItem);

                        }
                    }
                    }

                }



                ViewBag.storelist = new SelectList(newList, "StoreID", "Name");
            }




            return Json(
                ViewBag.storelist
            );
        }

        private string GetCurrentDay()
        {

            int d = (int)System.DateTime.Now.DayOfWeek;
            string vDay=String.Empty;
            switch (d)
            {
                case 1:
                    vDay="Lunes";
                    break;
                case 2:
                    vDay = "Martes";
                    break;
                case 3:
                    vDay = "Miércoles";
                    break;
                case 4:
                    vDay = "Jueves";
                    break;
                case 5:
                    vDay = "Viernes";
                    break;
                case 6:
                    vDay = "Sábado";
                    break;
                case 0:
                    vDay = "Domingo";
                    break;

            }

            return vDay;


        }

        public void LoadViewBag()
        {

          if(User.Identity.Name!=null)
            {

                var storetlist = _context.Store.OrderBy(modelType => modelType.Name).ToList();

            var storebyroutelist = _context.StoresByRoute.OrderBy(modelType => modelType.RouteID).ToList();
            ViewBag.storebyroutelist = new SelectList(storebyroutelist, "RouteID", "StoreName");


            var routelist = _context.Route.OrderBy(modelType => modelType.RouteName).ToList();
           

            var itemlist = _context.Item.OrderBy(modelType => modelType.ItemID).ToList();
            ViewBag.itemlist = new SelectList(itemlist, "ItemID", "Name");

            var checklist = _context.Checks.OrderBy(modelType => modelType.ChecksID).ToList();
            ViewBag.checklist = new SelectList(checklist, "ChecksID", "Question");

            var userbyroute = _context.UserByRoute.OrderBy(modelType => modelType.RouteId).ToList();


            List<Route> newList = new List<Route>();
          
            foreach (var item in userbyroute)
            {
                if (item.UserName == User.Identity.Name)
                {

                  
                    foreach (var item2 in routelist)
                    {
                        if (item2.RouteID.ToString() == item.RouteId.ToString())
                        {
                            
                             // SelectListItem selListItem = new SelectListItem() { Value = item2.RouteID.ToString(), Text = item2.RouteName };
                             Route vItem = new Route();
                           
                            vItem.RouteID = item2.RouteID;
                            vItem.RouteName = item2.RouteName;
                            newList.Add(vItem);

                        }
                    }

                }
            }

            ViewBag.routelist = new SelectList(newList, "RouteID", "RouteName");



           

                ViewBag.storelist = new SelectList(storetlist, "StoreID", "Name");
            }

        }
        public static SelectList SetSelectedValue(SelectList list, string value)
        {
            if (value != null)
            {
                var selected = list.Where(x => x.Value == value).First();
                selected.Selected = true;
                return list;
            }
            return list;
        }
    }
}
