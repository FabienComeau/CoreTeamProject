using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Services
{
    public interface IRequestFormDataServices
    {
        List<SelectListItem> GetSubCategories();
    }
}
