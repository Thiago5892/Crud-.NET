﻿using Crud.Context;
using Crud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Crud.Controllers
{
    public class ProdutoController : Controller
    {

        private LojaContext db = new LojaContext();
        // GET: Produto
        public ActionResult Index()
        {
            return View(db.Produto.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = db.Produto.Find(id);
            return View(produto);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Produto.Add(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);


            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var produto = db.Produto.Find(id);
            return View(produto);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
               if(ModelState.IsValid)
                {
                    db.Entry(produto).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View();
            }
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            return View();
        }

        // POST: Produto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    produto = db.Produto.Find(id);
                    db.Produto.Remove(produto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }
    }
}
