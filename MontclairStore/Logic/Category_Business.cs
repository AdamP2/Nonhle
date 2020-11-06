
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MontclairStore.Models;
using MontclairStore;
using MontclairModels;

namespace MontclairStore.Logic
{
    public class Category_Business
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<CategoryEntity> all()
        {
            return db.Categories.ToList();
        }
        public bool add(CategoryEntity model)
        {
            try
            {
                db.Categories.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(CategoryEntity model)
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
        public bool delete(CategoryEntity model)
        {
            try
            {
                db.Categories.Remove(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public CategoryEntity find_by_id(int? id)
        {
            return db.Categories.Find(id);
        }
        public List<ItemEntity> category_items(int? id)
        {
            return find_by_id(id).Items.ToList();
        }
    }
}