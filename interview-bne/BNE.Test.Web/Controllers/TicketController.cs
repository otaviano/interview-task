using BNE.Test.Domain;
using BNE.Test.Service;
using System;
using System.Web.Mvc;

namespace BNE.Test.Web.Controllers
{
  public class TicketController : Controller
  {
    // GET: Ticket
    public ActionResult Index()
    {
      var service = new TicketService();

      return View(service.GetLastGames());
    }
    
    // GET: Ticket/Create
    public ActionResult Create()
    {
      return View();
    }

    // POST: Ticket/Create
    [HttpPost]
    public ActionResult Create(Ticket ticket)
    {
      try
      {
        var service = new TicketService();

        service.SaveGame(ticket);

        return RedirectToAction("Index");
      }
      catch(Exception ex)
      {
        throw ex;
      }
    }

    // GET: Ticket/Edit/5
    public ActionResult Edit(int id)
    {
      return View();
    }

    // POST: Ticket/Edit/5
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

    // GET: Ticket/Delete/5
    public ActionResult Delete(int id)
    {
      return View();
    }

    // POST: Ticket/Delete/5
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
