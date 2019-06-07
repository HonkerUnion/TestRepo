using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PatientEmergencyInfoModel
    {
        public int Id { get; set; }
        [Required]
        public string illness { get; set; }    
        [Required]
        public string ConditionDescription { get; set; }
    }
}