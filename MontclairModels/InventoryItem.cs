using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontclairModels
{
    public class InventoryItem
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryItem_ID { get; set; }
        [Required]
        [Display(Name = "Quantity On Hand")]
        public int QuantityOnHand { get; set; }
        [Required]
        [Display(Name = "Cost Price")]
        [DataType(DataType.Currency)]
        public double CostPrice { get; set; }
        [Required]
        [Display(Name = "Mark Up Percentage")]
        public double markUpPerc { get; set; }
        [Required]
        [Display(Name = "Selling Price")]
        public double  sellingPrice { get; set; }
        [Required]
        [Display(Name = "Re-Order Quantity")]
        public int reOrderQuantity { get; set; }
        [Required]
        [Display(Name = "Date Last Ordered")]
        public DateTime dateLastOrdered { get; set; }
        [Required]
        [Display(Name = "Date Last Shipped")]
        public DateTime dateLastShipped { get; set; }
     
    }
}

