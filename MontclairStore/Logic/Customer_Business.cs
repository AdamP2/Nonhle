
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MontclairModels;
using MontclairStore.Models;


namespace MontclairStore.Logic
{
    public class Customer_Business
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public List<CustomerEntity> all()
        {
            return db.Customers.ToList();
        }
        public bool add(CustomerEntity model)
        {
            try
            {
                db.Customers.Add(model);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            { return false; }
        }
        public bool edit(CustomerEntity model)
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
        public CustomerEntity find_by_id(int? id)
        {
            return db.Customers.Find(id);
        }

        public string getGender(string id_num)
        {
            if (Convert.ToInt16(id_num.Substring(7, 1)) >= 5)
                return "Male";
            else
                return "Female";
        }
    }
}