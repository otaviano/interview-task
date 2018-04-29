using IdeiaNoAr.Test.Domain;
using IdeiaNoAr.Test.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IdeiaNoAr.Test.Web.Controllers
{
    public class OrganizationController : Controller
    {
        // GET: Organization
        public ActionResult Index()
        {
            var service = new OrganizationService();
            var list = service.GetAll();

            return View(list);
        }
        
        // GET: Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Organization/Create
        [HttpPost]
        public ActionResult Create(int id)
        {
            try
            {
                var service = new OrganizationService();
                var obj = service.Create(id);

                return View(obj);
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Organization/Edit/5
        public ActionResult Edit(int id)
        {
            var service = new OrganizationService();
            var obj = service.GetBy(id);

            return View(obj);
        }

        // POST: Organization/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Organization organization)
        {
            try
            {
                var service = new OrganizationService();
                var obj = service.Edit(organization);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }

        // GET: Organization/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var service = new OrganizationService();
                service.Delete(id);
                
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View(e.Message);
            }
        }
    }
}