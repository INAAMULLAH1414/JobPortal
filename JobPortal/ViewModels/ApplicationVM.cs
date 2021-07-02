using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.ViewModels
{
    public class ApplicationVM
    {
        public string  Profile { get; set; }
        [Display(Name = "Place of Posting")]
        public string PlacePosting { get; set; }
        [Display(Name = "Post Applied For")]

        public string PostAppliedFor { get; set; }
        public string Name { get; set; }
        [Display(Name = "Father's Name")]

        public string FatherName { get; set; }
        [Display(Name = "Date of Birth")]

        public DateTime DateofBirth { get; set; }

        [Display(Name ="Please enter the Age in Years and Month eg: 22 02")]
        public string Age { get; set; }
        public string CNIC { get; set; }
        [Display(Name = "Domicile(District)")]

        public string Domicile { get; set; }
        [Display(Name = "Contact No.")]

        public string Contact { get; set; }
        [Display(Name = "Other Contact #:")]

        public string Contact1 { get; set; }
        [Display(Name = "Postal Address")]

        public string PostalAddress { get; set; }
        [Display(Name = "Permanent Address")]

        public string PermanentAddress { get; set; }

        public string Email { get; set; }
        public string GovtService { get; set; }
      
        public string Disability { get; set; }

        public string HafizeQuran { get; set; }
        public string Religion { get; set; }
        public string Gender { get; set; }
        public string MartialStatus { get; set; }

    }
}
