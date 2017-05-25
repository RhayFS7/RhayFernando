using RhayFernando.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RhayFernando.Controllers
{
    public class CategoriesController : Controller
    {
        #region [ Properties ]

        private static IList<Category> categories = new List<Category>()
        {
            new Category() { CategoryID = 1, name = "Notebooks"     },
            new Category() { CategoryID = 2, name = "Monitores"     },
            new Category() { CategoryID = 3, name = "Impressoras"   },
            new Category() { CategoryID = 4, name = "Mouses"        },
            new Category() { CategoryID = 5, name = "Desktops"      }
       };
       

        #endregion [ Properties ]


        #region [ Actions ]

        // GET: Categories
        public ActionResult Index()
        {
            return View(categories);
        }

        #region [ Create ]

        // GET: Create Category
        public ActionResult Create()
        {
            return View();
        }

        //POST: Create Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            categories.Add(category);
            category.CategoryID = categories.Select(c => c.CategoryID).Max() + 1;
                                  
            return RedirectToAction("Index");                                  
        }

        #endregion [ Create ]

        #region [ Edit ]

        // GET: Edit Category
        public ActionResult Edit(long id)
        {
            var cat = categories.Where(c => c.CategoryID == id).First();
            return View(cat);
        }

        //POST: Edit Category
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var cat = categories.Where(c => c.CategoryID == category.CategoryID).First();
            cat.name = category.name;
            return RedirectToAction("Index");
        }
        #endregion [ Edit ]

        #region [ Delete ]

        // GET: Delete Category
        public ActionResult Delete(long id)
        {
            var cat = categories.Where(c => c.CategoryID == id).First();
            return View(cat);
        }

        //POST: Delete Category
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            var cat = categories.Where(c => c.CategoryID == id).First();
            categories.Remove(cat);

            return RedirectToAction("index");

        }


        #endregion [ Delete ]

        #region [ Details ]

        // GET: Details Category
        public ActionResult Details(long id)
        {
            var cat = categories.Where(c => c.CategoryID == id).First();
            return View(cat);
        }

        #endregion [ Details ]

        #endregion [ Actions ] 
    }
}