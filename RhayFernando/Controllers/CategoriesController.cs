using RhayFernando.ExtensionMethods;
using RhayFernando.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Service.Tables;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace RhayFernando.Model.Tables
{
    public class CategoriesController : Controller
    {

        private CategoryServices categoryServices = new CategoryServices();

        private ActionResult GetViewCategoryById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = categoryServices.GetCategoryById((long)id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        private ActionResult SaveCategory(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    categoryServices.SaveCategory(category);
                    return RedirectToAction("Index");
                }
                return View(category);
            }
            catch
            {
                return View(category);
            }
        }

        private void PopularViewBag(Category category = null)
        {
            if (category == null)
            {
                ViewBag.CategoryId = new SelectList(categoryServices.GetCategoriesClassifiedByName(),
                   "CategoryId", "Name");
            }
        }

        #region [ Actions ]



        #region [ Index ] 
        // GET: Categories
        // GET: Categories/Index
        public async Task<ActionResult> Index()
            //public ActionResult Index()
        {
            var list = new List<Category>();

            using (var client = new HttpClient())
            {
                var baseUrl = string.Format("{0}://{1}",
                    HttpContext.Request.Url.Scheme,
                    HttpContext.Request.Url.Authority);

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                var response = await client.GetAsync("Api/Categories");

                if (response.IsSuccessStatusCode)
                {
                    var result = response
                        .Content
                        .ReadAsStringAsync()
                        .Result;

                    list = JsonConvert
                        .DeserializeObject<List<Category>>(result);
                }
            }

            return View(list);
 
           // return View(categoryServices.GetCategoriesClassifiedByName());
        }

        #endregion [ Index ] 

        #region [ Create ]

        // GET: Create Category
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {

            return SaveCategory(category);
        }


        #endregion [ Create ]

        #region [ Edit ]

        // GET: Edit Category
        public ActionResult Edit(long? ID)
        {
            PopularViewBag(categoryServices.GetCategoryById((long)ID));
            return GetViewCategoryById(ID);
        }

        //POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            return SaveCategory(category);
        }
        #endregion [ Edit ]

        #region [ Delete ]

        // GET: Delete Category
        public ActionResult Delete(long? ID)
        {
            return GetViewCategoryById(ID);
        }
        //POST: Categories/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long ID)
        {
            Category category = categoryServices.RemoveCategoryById(ID);
            TempData["Message"] = "Category" + category.Name.ToUpper() + "Was Removed";
            return RedirectToAction("Index");
        }


        #endregion [ Delete ]

        #region [ Details ]

        // GET: Details Category
        public ActionResult Details(long? ID)
        {

            return GetViewCategoryById(ID);
        }


        #endregion [ Details ]

        #endregion [ Actions ] 

        #region [ Extensions ]

        #region [ Count Word ]
        public string WordCount(string word = "")
        {
            return string.Format("The '{0}' has '{1}' chars", word, word.WordCount());
        }
        #endregion [ Count Word ] 

        #endregion [ Extensions ]
    }
}