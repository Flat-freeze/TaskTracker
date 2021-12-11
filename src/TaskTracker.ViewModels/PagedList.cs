using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using X.PagedList;

namespace TaskTracker.ViewModels
{
    public class PageOf<TSource> : IPagedList
    {
        private readonly IPagedList<TSource> source;

        public PageOf(IPagedList<TSource> source) => this.source = source;

        public IEnumerable<TSource> Source => source;
        public int PageCount => source.PageCount;
        public int TotalItemCount => source.TotalItemCount;
        public int PageNumber => source.PageNumber;
        public int PageSize => source.PageSize;
        public bool HasPreviousPage => source.HasPreviousPage;
        public bool HasNextPage => source.HasNextPage;
        public bool IsFirstPage => source.IsFirstPage;
        public bool IsLastPage => source.IsLastPage;
        public int FirstItemOnPage => source.FirstItemOnPage;
        public int LastItemOnPage => source.LastItemOnPage;
    }
}
