using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontclairModels
{
   public class OrderTrackingEntity
    {

        [Key]
        public int tracking_ID { get; set; }
        [ForeignKey("Order")]
        public int order_ID { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public string Recipient { get; set; }

        public virtual OrderEntity Order { get; set; }
    }
}
