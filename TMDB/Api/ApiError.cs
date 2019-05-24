using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TMDB.Api
{
    /// <summary>
    /// Representa uma resposta de erro da API. 
    /// </summary>
    [DataContract]
    public class ApiResponseError
    {
        /// <summary>
        /// Código da mensagem.
        /// </summary>
        [DataMember(Name = "status_code")]
        public int StatusCode { get; set; }

        /// <summary>
        /// Mensagem de erro.
        /// </summary>
        [DataMember(Name = "status_message")]
        public string StatusMessage { get; set; }
    }
}
