using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMDB
{
    public interface IResponse<T>
    {
        IReadOnlyList<T> Results { get; }

        int PageNumber { get; }

        int NextPage { get; }

        int PrevPage { get; }

        int TotalPages { get; }

        int TotalResults { get; }

        string Query { get; set; }
    }
}
