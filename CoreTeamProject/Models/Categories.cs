using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Models
{
    public class Categories
    {
        [Key]
        public int categoryID { get; set; }

        public string categoryTitle { get; set; }



        public virtual ICollection<SubCategories> SubCategories { get; set; } 
    }
}
