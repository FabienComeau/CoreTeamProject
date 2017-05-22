using CoreTeamProject.Components;
using CoreTeamProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTeamProject.Services
{
    public interface INewsService
    {
        Task<IEnumerable<Events>> GetNews(int threshold);
    }
}
