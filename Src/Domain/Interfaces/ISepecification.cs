using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISepecification<TResult> where TResult : class
    {
        /// <summary>
        /// Specification Pattern to Reduce make a lot of methods to each business logic 
        /// </summary>
        /// <param name="query">set any query you set it through EF core</param>
        /// <returns>deffered execution by IQuirable< <para name="TResult"> ></para></returns>
        IQueryable<TResult> Apply(IQueryable<TResult> query);
    }
}
