using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetIdentity.Models;
using AspNetIdentity.Repository;
using Microsoft.AspNet.Identity;

namespace AspNetIdentity.Controllers
{
    [Authorize]
    public class ToolsController : Controller
    {
        private readonly IRepository<Tool> _repo;

        public ToolsController()
        {
            _repo = new Repository<Tool>(new ApplicationDbContext());
        }

        // GET: Tools
        public ActionResult Index()
        {
            var currentUser = User.Identity.GetUserId();
            var tools = _repo.List(x => x.UserId == currentUser, x => x.User);
            return View(tools.ToList());
        }

        // GET: Tools/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tool tool = _repo.GetById(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // GET: Tools/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tools/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ToolName")] Tool tool)
        {
            ModelState.Remove("UserId");

            tool.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                _repo.Insert(tool);
                return RedirectToAction("Index");
            }

            return View(tool);
        }

        // GET: Tools/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = _repo.GetById(id);
            if (tool == null)
            {
                return HttpNotFound();
            }

            return View(tool);
        }

        // POST: Tools/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ToolName")] Tool tool)
        {
            ModelState.Remove("UserId");

            tool.UserId = User.Identity.GetUserId();

            if (ModelState.IsValid)
            {
                _repo.Update(tool);
                return RedirectToAction("Index");
            }

            return View(tool);
        }

        // GET: Tools/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tool tool = _repo.GetById(id);
            if (tool == null)
            {
                return HttpNotFound();
            }
            return View(tool);
        }

        // POST: Tools/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool tool = _repo.GetById(id);
            _repo.Delete(tool);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
