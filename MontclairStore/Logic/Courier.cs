using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MontclairStore.Logic
{
    public class Courier
    {
        [JsonProperty(PropertyName = "id")]
        public string CourierId { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Name")]
        [RegularExpression(pattern: @"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed.")]
        [StringLength(maximumLength: 35, ErrorMessage = "Student Name must be atleast 3 characters long", MinimumLength = 3)]
        [Display(Name = "Courier Name")]
        public string CourierName { get; set; }
        [JsonProperty(PropertyName = "Email")]
        [Required]
        [Display(Name = "Email")]
        [DataType(dataType: DataType.EmailAddress)]
        public string CourierEmail { get; set; }
        [Required]
        [JsonProperty(PropertyName = "Contact Number")]
        [DataType(dataType: DataType.PhoneNumber)]
        [RegularExpression(pattern: @"^\(?([0]{1})\)?[-. ]?([1-9]{1})[-. ]?([0-9]{8})$", ErrorMessage = "Entered phone format is not valid.")]
        [StringLength(maximumLength: 10, ErrorMessage = "SA Contact Number must be exactly 10 digits long", MinimumLength = 10)]
        [Display(Name = "Contact Number")]
        public string Contact { get; set; }
        [JsonProperty(PropertyName = "isActive")]
        [Display(Name = "Is Active?")]
        public bool isActive { get; set; }
    }
}
