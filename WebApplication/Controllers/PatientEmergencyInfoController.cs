using BusinessServices;
using Marlabs.Tool.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class PatientEmergencyInfoController : Controller
    {
        private readonly IProductServices _productServices;


        /// <summary>
        /// Public constructor to initialize product service instance
        /// </summary>
        public PatientEmergencyInfoController()
        {
            _productServices = new ProductServices();
        }

        // GET: PatientEmergencyInfo
        public ActionResult Index()
        {
            return View();
        }

        // GET: PatientEmergencyInfo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PatientEmergencyInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PatientEmergencyInfo/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientEmergencyInfo/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PatientEmergencyInfo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PatientEmergencyInfo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PatientEmergencyInfo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
