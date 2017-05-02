using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Models
{
    public class Events
    {
        [Key]
        public int eventID { get; set;}

        public string eventName { get; set; }

        public string eventDescription { get; set; }

        public DateTime eventDate { get; set;}

        public string eventLocation { get; set; }

        public string eventEmail { get; set; }

        public string eventPhoneNumber { get; set; }

        public double eventCost { get; set; }

        public int subCategoryID { get; set; } //FK 

        // ---------- Navagation Properties ---------- //
        public virtual SubCategories Subcategory { get; set; }

    }
}
