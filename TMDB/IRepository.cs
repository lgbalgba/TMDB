using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDB.Models;

namespace TMDB
{
    public interface IRepository
    {
        Task<IResponse<Movie>> GetUpcomingAsync(int pageNumber = 1);

        Task<IResponse<Movie>> GetTopRatedAsync(int pageNumber = 1);

        Task<IResponse<Movie>> SearchByTitleAsync(string query, int pageNumber = 1);

        Task<Movie> FindByIdAsync(int id);
    }

    public interface IRepositorySettings
    {
        string Key { get; }
        string Url { get; }
    }
}
