using AspNetCoreWebAppMvcCrudOperations.Data;
using AspNetCoreWebAppMvcCrudOperations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspNetCoreWebAppMvcCrudOperations.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ItemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Item> objList = _db.Items;
            return View(objList);
        }

        //GET-Create
        public IActionResult Create()
        {
            return View();
        }
        //Post-Create -> sends over the item from the create page to ItemController 
        //Validate and check if we have a token. For now I didn't put it but it is coming soon
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item obj)
        {
            _db.Items.Add(obj);
            _db.SaveChanges();
            //we redirect to our indexAction -> showing the table again with the added item
            return RedirectToAction("Index");
        }
    }
}
