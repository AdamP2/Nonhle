using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MontclairModels;
using MontclairStore.Models;

namespace MontclairStore.Controllers
{
    public class CartItemEntitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CartItemEntities
        public ActionResult Index()
        {
            var cart_Items = db.Cart_Items.Include(c => c.Cart).Include(c => c.Item);
            return View(cart_Items.ToList());
        }

        // GET: CartItemEntities/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemEntity cartItemEntity = db.Cart_Items.Find(id);
            if (cartItemEntity == null)
            {
                return HttpNotFound();
            }
            return View(cartItemEntity);
        }

        // GET: CartItemEntities/Create
        public ActionResult Create()
        {
            ViewBag.cart_id = new SelectList(db.Carts, "cart_id", "cart_id");
            ViewBag.item_id = new SelectList(db.Items, "ItemCode", "Name");
            return View();
        }

        // POST: CartItemEntities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cart_item_id,cart_id,item_id,quantity,price,colour,shape,size,flavour")] CartItemEntity cartItemEntity)
        {
            if (ModelState.IsValid)
            {
                db.Cart_Items.Add(cartItemEntity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cart_id = new SelectList(db.Carts, "cart_id", "cart_id", cartItemEntity.cart_id);
            ViewBag.item_id = new SelectList(db.Items, "ItemCode", "Name", cartItemEntity.item_id);
            return View(cartItemEntity);
        }

        // GET: CartItemEntities/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemEntity cartItemEntity = db.Cart_Items.Find(id);
            if (cartItemEntity == null)
            {
                return HttpNotFound();
            }
            ViewBag.cart_id = new SelectList(db.Carts, "cart_id", "cart_id", cartItemEntity.cart_id);
            ViewBag.item_id = new SelectList(db.Items, "ItemCode", "Name", cartItemEntity.item_id);
            return View(cartItemEntity);
        }

        // POST: CartItemEntities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cart_item_id,cart_id,item_id,quantity,price,colour,shape,size,flavour")] CartItemEntity cartItemEntity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartItemEntity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cart_id = new SelectList(db.Carts, "cart_id", "cart_id", cartItemEntity.cart_id);
            ViewBag.item_id = new SelectList(db.Items, "ItemCode", "Name", cartItemEntity.item_id);
            return View(cartItemEntity);
        }

        // GET: CartItemEntities/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CartItemEntity cartItemEntity = db.Cart_Items.Find(id);
            if (cartItemEntity == null)
            {
                return HttpNotFound();
            }
            return View(cartItemEntity);
        }

        // POST: CartItemEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CartItemEntity cartItemEntity = db.Cart_Items.Find(id);
            db.Cart_Items.Remove(cartItemEntity);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
