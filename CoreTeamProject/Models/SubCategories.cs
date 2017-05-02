using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Models
{
    public class SubCategories
    {
        [Key]
        public int subCategoryID { get; set;}
        
        public string subCategoryTitle { get; set; }

        public int categoryID { get; set; }


        // ---------- Navagation Properties ---------- //
        public virtual Categories Category { get; set; }

        public virtual ICollection<Events> Event { get; set; }
    }
}
