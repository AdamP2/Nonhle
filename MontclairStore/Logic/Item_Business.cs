
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MontclairModels;
using MontclairStore.Models;


namespace MontclairStore.Logic
{
    public class Item_Business
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<ItemEntity> all()
        {
            return db.Items.Include(i => i.Category).ToList();
        }
        public bool add(ItemEntity model)
        {
            try
            {
                db.Items.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(ItemEntity model)
        {
            try
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool delete(ItemEntity model)
        {
            try
            {
                db.Items.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public ItemEntity find_by_id(int? id)
        {
            return db.Items.Find(id);
        }
        //public List<StockCart_Item> get_cart_items(int id)
        //{
        //    //return db.StockCart_Items.
        //}


        public void updateStock_Received(int item_id, int quantity)
        {
            var item = db.Items.Find(item_id);
            item.QuantityInStock += quantity;
            db.SaveChanges();
        }
        public void updateOrder(int id, double price)
        {
            var item = db.Order_Items.Find(id);
            item.price = price;
            item.replied = true;
            item.date_replied = DateTime.Now;
            item.status = "Supplier Replied with Pricing Details";
            db.SaveChanges();
        }
     
    }
}