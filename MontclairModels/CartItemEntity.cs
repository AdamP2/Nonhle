using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontclairModels
{
   public class CartItemEntity
    {

        [Key]
        public string cart_item_id { get; set; }
        [ForeignKey("Cart")]
        public string cart_id { get; set; }
        [ForeignKey("Item")]
        public int item_id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public string colour { get; set; }
        public string shape { get; set; }
        public string size { get; set; }
        public string flavour { get; set; }
        public virtual ItemEntity Item { get; set; }
        public virtual CartEntity Cart { get; set; }
    }
}
