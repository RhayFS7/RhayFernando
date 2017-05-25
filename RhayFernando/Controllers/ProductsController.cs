using RhayFernando.ExtensionMethods;
using RhayFernando.Models;
using Service.Registers;
using Service.Tables;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace RhayFernando.Model.Registers
{
    public class ProductsController : Controller
    {
        private ProductServices productServices = new ProductServices();
        private CategoryServices categoryServices = new CategoryServices();
        private SupplierServices supplierServices = new SupplierServices();

        private ActionResult GetViewProductById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productServices.GetProductById((long)id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        private void PopularViewBag(Product product = null)
        {
            if (product == null)
            {
                ViewBag.CategoryId = new SelectList(categoryServices.GetCategoriesClassifiedByName(),
                    "CategoryId", "Name");
                ViewBag.SupplierId = new SelectList(supplierServices.GetSuppliersClassifiedsByName(),
                    "SupplierId", "Name");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoryServices.GetCategoriesClassifiedByName(),
                    "CategoryId", "Name",product.CategoryId);
                ViewBag.S = new SelectList(supplierServices.GetSuppliersClassifiedsByName(),
                    "SupplierId", "Name", product.SupplierId);


            }
        }

        private ActionResult SaveProduct(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    productServices.SaveProduct(product);
                    return RedirectToAction("Index");
                }
                return View(product);
            }
            catch
            {
                return View(product);
            }
        }

        #region [ Actions ]

        #region [ Index ]
        // GET: Products
        public ActionResult Index()
        {
            return View(productServices.GetProductsClassifiedByName());
        }
        #endregion [ Index ]

        #region [ Details ]
        // GET: Products/Details/5
        public ActionResult Details(long? id)
        {

            return GetViewProductById(id);
        }

        #endregion [ Details ]

        #region [ Create ]
        // GET: Products/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Products/Create      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            return SaveProduct(product);
        }

        #endregion [ Create ]

        #region [ Edit ]
        // GET: Products/Edit/5
        public ActionResult Edit(long? id)
        {
            PopularViewBag(productServices.GetProductById((long)id));
            return GetViewProductById(id);
        }

        // POST: Products/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long? id, Product product)
        {
            return SaveProduct(product);
        }

        #endregion [ Edit ]

        #region [ Delete ]
        // GET: Products/Delete/5
        public ActionResult Delete(long? id)
        {

            return GetViewProductById(id);
        }
        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try
            {
                Product product = productServices.RemoveProductById(id);
                TempData["Massege"] = "Product" + product.Name.ToUpper() + "Was Removed";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #endregion [ Delete ]

            #endregion [ Actions ]

        }
    }

