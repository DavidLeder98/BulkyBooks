using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

		// - - CONSTRUCTOR - -

        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }



		// - - SHOW ALL CATEGORIES - -

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }



        // - - CREATE NEW CATEGORY - -

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
		public IActionResult Create(Category obj)
		{
            
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
            
			if (ModelState.IsValid)
            {
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
            return View();
		}



		// - - EDIT EXISTING CATEGORY - -

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{

			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
			}

			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}

	}
}
