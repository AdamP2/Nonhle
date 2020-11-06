﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontclairModels
{
   public class OrderItemEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Item_id { get; set; }
        [ForeignKey("Order")]
        public int Order_id { get; set; }
        public virtual OrderEntity Order { get; set; }

        [ForeignKey("Item")]
        public int item_id { get; set; }
        public virtual ItemEntity Item { get; set; }

        public int quantity { get; set; }
        public double price { get; set; }

        public bool replied { get; set; }
        public Nullable<DateTime> date_replied { get; set; }

        public bool accepted { get; set; }
        public Nullable<DateTime> date_accepted { get; set; }

        public bool shipped { get; set; }
        public string status { get; set; }
        public Nullable<DateTime> date_shipped { get; set; }
    }
}
