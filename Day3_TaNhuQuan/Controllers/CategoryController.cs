using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day3_TaNhuQuan.Datas;
using Day3_TaNhuQuan.Models;

namespace Day3_TaNhuQuan.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            var categories = SeedData.Categories;

            return View(categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            //lay id category co id truyen vao tu SeedData
            var category = SeedData.Categories.FirstOrDefault(c => c.ID == id);
            //neu caregory=null thi tra ve trang loi
            if (category == null)
            {
                return NotFound();
            }
            
            //net category khac null thi tra ve view va truyen category vao view
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            //Lay max id trong danh sach category hien tai va tang len 1 de tao id moi
            int maxId = SeedData.Categories.Max(c => c.ID);
            category.ID = maxId + 1;

            if (ModelState.IsValid)
            {
                SeedData.Categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
                
            return View(category);
        }
            
        

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = SeedData.Categories.FirstOrDefault(c => c.ID == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([FromForm] Category category)
        {
            var existingCategory = SeedData.Categories.FirstOrDefault(c => c.ID == category.ID);
            if(existingCategory == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                existingCategory.Description = category.Description;
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(category);
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = SeedData.Categories.FirstOrDefault(c => c.ID == id);
            if(category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromForm] Category category)
        {
            var existingCategory = SeedData.Categories.FirstOrDefault(c => c.ID == category.ID);
            if (existingCategory == null)
            {
                return NotFound();
            }
            SeedData.Categories.Remove(existingCategory);
            return RedirectToAction(nameof(Index));

        }

        //Cach 2 de Xoa category
        //[HttpPost, ActionName("Delete")]  //-> Dinh nghia ten action la Delete, nhung thuc te la DeleteConfirmed
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfermed([FromRoute] int id)
        //{
        //    var category = SeedData.Categories.FirstOrDefault(c => c.ID == id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }
        //    SeedData.Categories.Remove(category);
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
