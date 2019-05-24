using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TMDB.Api
{
    /// <summary>
    /// Representa a resposta da API TMDB.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class ApiResponse<T> : IResponse<T>
    {
        /// <summary>
        /// Lista de resultados.
        /// </summary>
        [DataMember(Name = "results")]
        public IReadOnlyList<T> Results { get; private set; }

        /// <summary>
        /// Página atual do resultado.
        /// </summary>
        [DataMember(Name = "page")]
        public int PageNumber { get; private set; }

        /// <summary>
        /// Próxima página.
        /// </summary>
        public int NextPage { get { return PageNumber + 1; } }

        /// <summary>
        /// Página anterior.
        /// </summary>
        public int PrevPage { get { return PageNumber - 1; } }

        /// <summary>
        /// Total de páginas.
        /// </summary>
        [DataMember(Name = "total_pages")]
        public int TotalPages { get; private set; }

        /// <summary>
        /// Total de resultados.
        /// </summary>
        [DataMember(Name = "total_results")]
        public int TotalResults { get; private set; }

        /// <summary>
        /// Consulta realizada.
        /// </summary>
        public string Query { get; set; }
    }
}
