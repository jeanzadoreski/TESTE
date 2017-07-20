using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TESTE.Models;
using System.Net;
using System.Data;
using System.Data.Entity;
using TESTE.Contexts;


namespace TESTE.Controllers
{
    public class TarefasController : Controller
    {
        private EFContext context = new EFContext();
        // GET: Tarefas
        public ActionResult Index()
        {
            return View(context.Tarefas.OrderBy(c => c.Titulo));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tarefa tarefa)
        {            
            context.Tarefas.Add(tarefa);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new
                HttpStatusCodeResult(
                HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {               
                context.Entry(tarefa).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = context.Tarefas.
            Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = context.Tarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Tarefa tarefa = context.Tarefas.Find(id);
            context.Tarefas.Remove(tarefa);
            context.SaveChanges();
            //TempData["Message"] = "Tarefa " +
            //tarefa.Titulo.ToUpper() + " foi removido";
            return RedirectToAction("Index");
        }
    }
}