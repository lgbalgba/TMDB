using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDB.Api
{
    /// <summary>
    /// Representa as configurações de acesso a API TMD.
    /// </summary>
    public class ApiSettings : IRepositorySettings
    {
        #region Local Variables

        private readonly IConfiguration _configuration;

        #endregion

        #region Properties

        /// <summary>
        /// Chave para acesso a API.
        /// </summary>
        public string Key => _configuration["ApiSettings:TheMovieDBApi:Key"];

        /// <summary>
        /// Url para consumo da API.
        /// </summary>
        public string Url => _configuration["ApiSettings:TheMovieDBApi:Url"];

        /// <summary>
        /// Url para consumo das imagens da API.
        /// </summary>
        public string ImageUrl => _configuration["ApiSettings:TheMovieDBApi:ImageUrl"];

        #endregion

        #region Constructors

        public ApiSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion

    }
}
