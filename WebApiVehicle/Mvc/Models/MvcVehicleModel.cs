using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models
{
    public class MvcVehicleModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter a value for Year")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please enter a value for Make")]
        public string Make { get; set; }
        [Required(ErrorMessage = "Please enter a value for Model")]
        public string Model { get; set; }
    }
}