using RhayFernando.ExtensionMethods;
using RhayFernando.Models;
using Persistence.Contexts;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Service.Registers;

namespace RhayFernando.Model.Registers
{
    public class SuppliersController : Controller
    {
        private SupplierServices supplierServices = new SupplierServices();

        private ActionResult GetViewSupplierById(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = supplierServices.GetSupplierById((long)id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        private ActionResult SaveSupplier(Supplier supplier)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    supplierServices.SaveSupplier(supplier);
                    return RedirectToAction("Index");
                }
                return View(supplier);
            }
            catch
            {
                return View(supplier);
            }
        }

        private void PopularViewBag(Supplier supplier = null)
        {
            if (supplier == null)
            {
                ViewBag.SupplierId = new SelectList(supplierServices.GetSuppliersClassifiedsByName(),
                   "SupplierId", "Name");
            }
        }

        #region [ Actions ] 

        #region [ Index ]
        // GET: Suppliers
        // GET: Suppliers/Index     
        public ActionResult Index()
        {
            return View(supplierServices.GetSuppliersClassifiedsByName());
        }

        #endregion [ Index ]

        #region [ Details ]

        //	GET:	Produtos/Details/5
        public ActionResult Details(long? ID)
        {

            return GetViewSupplierById(ID);
        }

        #endregion [ Details ]

        #region [ Create ]

        // GET: Suppliers
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }
        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            return SaveSupplier(supplier);
        }

        #endregion [ Create ]

        #region [ Edit ] 

        // GET: Suppliers/Edit/5
        public ActionResult Edit(long? ID)
        {
            PopularViewBag(supplierServices.GetSupplierById((long)ID));
            return GetViewSupplierById(ID);
        }

        //POST: Suppliers
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {

            return SaveSupplier(supplier);
        }
        #endregion [ Edit ]

        #region [ Delete ]

        //	GET:	Produtos/Delete/5
        public ActionResult Delete(long? ID)
        {
            return GetViewSupplierById(ID);
        }
        //POST: Suppliers/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long ID)
        {
            Supplier supplier = supplierServices.RemoveSupplierById(ID);
            
            return RedirectToAction("Index");
        }

        #endregion [ Delete ] 

        #endregion [ Actions ] 

    }
}