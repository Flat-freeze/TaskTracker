using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X.PagedList;

namespace TaskTracker.ViewModels
{
    public static class Extensions
    {
        public static PageOf<TSource> ToPageOf<TSource>(this IPagedList<TSource> sources) => new PageOf<TSource>(sources);
    }
}
