using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Models
{
    public class Events
    {
        [Key]
        public int eventID { get; set;}

        [Required]
        [StringLength(200, MinimumLength =3)]
        [Display(Name = "Name")]
        public string eventName { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 3)]
        [Display(Name = "Description")]
        public string eventDescription { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:D}")]
        [Display(Name = "Date")]
        public DateTime eventDate { get; set;}

        [Required]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:t}")]
        [Display(Name = "Time")]
        public DateTime eventTime { get; set; }

        [Required]
        [StringLength(100,MinimumLength =3)]
        [Display(Name = "Location")]
        public string eventLocation { get; set; }

        //[Required]
        [EmailAddress]
        [Display(Name = "Contact Email")]
        public string eventEmail { get; set; }

        //[Required]
        [Phone]
        [Display(Name = "Contact Phone")]
        public string eventPhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName ="money")]
        [Display(Name = "Cost")]
        public decimal eventCost { get; set; }

        
        public int subCategoryID { get; set; } //FK 

        // ---------- Navagation Properties ---------- //
        public virtual SubCategories Subcategory { get; set; }



        //public string ContactInfo
        //{
        //    get
        //    {
        //        return eventEmail + "\n" + eventPhoneNumber;
        //    }
        //}


    }
}
