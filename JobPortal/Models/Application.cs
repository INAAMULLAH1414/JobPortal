using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JobPortal.Models
{
    public class Application
    {
        public int Id { get; set; }
    
        [Required]
        public string Profile { get; set; }
        [Display(Name = "Place of Posting")]

        [Required]
        public string PlacePosting { get; set; }
        [Display(Name = "Post Applied For")]

        [Required]
        public string PostAppliedFor { get; set; }

        [Required]
        public string Name { get; set; }
        [Display(Name = "Father's Name")]

        [Required]
        public string FatherName { get; set; }
        [Display(Name = "Date of Birth")]

        [Required]
        public DateTime DateofBirth { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string CNIC { get; set; }
        [Display(Name = "Domicile(District)")]


        [Required]
        public string Domicile { get; set; }
        [Display(Name = "Contact No.")]

        [Required]
        public string Contact { get; set; }
        [Display(Name = "Other Contact #:")]

        
        public string Contact1 { get; set; }
        [Display(Name = "Postal Address")]

        [Required]
        public string PostalAddress {get;set;}
        [Display(Name = "Permanent Address")]

        [Required]
        public string PermanentAddress { get; set; }

        [Required]
        public string Email { get; set; }
        [Display(Name = "Already in Govt. Service")]

         [Required]
        public string GovtService { get; set; }
        [Required]
        public string Disability{ get; set; }
      
        [Required (ErrorMessage ="required field")]
        public string HafizeQuran { get; set; }

        [Required]
        public string Religion { get; set; }

        [Required]
        public string Gender { get; set; }
        [Display(Name = "Martial Status")]

        [Required]
        public string MartialStatus { get; set; }

    }
}
