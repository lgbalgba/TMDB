using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMDB.Models;

namespace TMDB.Api
{
    public class ApiRepository : ApiRequest, TMDB.IRepository
    {
        #region Local Variables

        private readonly IRepositorySettings _apiSettings;

        #endregion

        #region Constructors

        public ApiRepository(IRepositorySettings apiSettings)
            : base(apiSettings)
        {
            _apiSettings = apiSettings;
        }

        #endregion

        #region Public Methods

        public async Task<IResponse<Movie>> GetTopRatedAsync(int pageNumber = 1)
        {
            string command = "movie/top_rated";
            var param = new Dictionary<string, string>
            {
                {"language", "pt-BR"},
                {"primary_release_year" , DateTime.Now.AddMonths(-12).Date.ToString("yyyy-MM-dd")},
            };
                   
            ApiResponse<Movie> response = await SearchAsync<Movie>(command, pageNumber, param);
            return response;
        }

        public async Task<IResponse<Movie>> GetUpcomingAsync(int pageNumber = 1)
        {
            string command = "movie/upcoming";
            var param = new Dictionary<string, string>
            {
                {"language",  "pt-BR"},
                {"primary_release_year" , DateTime.Now.AddMonths(-12).Date.ToString("yyyy-MM-dd")},
            };           

            ApiResponse<Movie> response = await SearchAsync<Movie>(command, pageNumber, param);
            return response;
        }

        public async Task<IResponse<Movie>> SearchByTitleAsync(string query, int pageNumber = 1)
        {
            string command = "search/movie";
            var param = new Dictionary<string, string>
            {
                {"query", query},
                {"language",  "pt-BR"},
                {"primary_release_year" , DateTime.Now.AddMonths(-12).Date.ToString("yyyy-MM-dd")},
            };

            ApiResponse<Movie> response = await SearchAsync<Movie>(command, pageNumber, param);
            return response;
        }

        public async Task<Movie> FindByIdAsync(int id)
        {
            string command = $"movie/{id}";
            var param = new Dictionary<string, string>
            {
                {"language",  "pt-BR"},
                {"primary_release_year" , DateTime.Now.AddMonths(-12).Date.ToString("yyyy-MM-dd")},
            };

            Movie response = await FindAsync<Movie>(command, 1, param);
            return response;
        }

        #endregion
    }
}
