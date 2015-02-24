using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace UniversityofLouisvilleVaccine.Models
{
    public class Vendor
    {
        [Key]
        [Required]
        [Display(Name = "Vendor ID")]
        public string vendorID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string vendorName { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        public string vendorPhone { get; set; }

        [Required]
        [Display(Name = "Fax Number")]
        public string vendorFax { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string vendorEmail { get; set; }

        [Required]
        [Display(Name = "Website")]
        public string vendorWebsite { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string vendorAddress { get; set; }

    }

}