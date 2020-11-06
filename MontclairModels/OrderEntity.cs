﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontclairModels
{
  public  class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }
        public DateTime date_created { get; set; }
        [ForeignKey("Customer")]
        public string Email { get; set; }
        public bool shipped { get; set; }
        public string status { get; set; }
        public bool packed { get; set; }
        public virtual ICollection<OrderItemEntity> Order_Items { get; set; }
        public virtual ICollection<OrderAddressEntity> Order_Addresses { get; set; }
        public virtual CustomerEntity Customer { get; set; }

        public virtual ICollection<OrderTrackingEntity> Order_Tracking { get; set; }
    }
}
