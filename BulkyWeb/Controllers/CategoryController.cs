using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {

		// - - CONSTRUCTOR - -

        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }

		

		// - - SHOW ALL CATEGORIES - -

        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
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
				_categoryRepo.Add(obj);
				_categoryRepo.Save();
				TempData["success"] = "Category created successfully";
				return RedirectToAction("Index");
			}
            return View();
		}



		// - - EDIT EXISTING CATEGORY - -

		// - - Edit Action - -
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		// - - Edit Method - -
		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (ModelState.IsValid)
			{
				_categoryRepo.Update(obj);
				_categoryRepo.Save();
				TempData["success"] = "Category updated successfully";
				return RedirectToAction("Index");
			}
			return View();
		}



		// - - DELETE EXISTING CATEGORY - -

		// - - Delete Action - -
		public IActionResult Delete (int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id);
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		// - - Delete Method - -
		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{
			Category obj = _categoryRepo.Get(u => u.Id == id);
			if (obj == null) 
			{
				return NotFound();
			}
			_categoryRepo.Remove(obj);
			_categoryRepo.Save();
			TempData["success"] = "Category deleted successfully";
			return RedirectToAction("Index");
		}
	}
}
