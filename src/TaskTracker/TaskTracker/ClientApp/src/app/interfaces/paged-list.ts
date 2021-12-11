export interface PagedList<TSource> {
  source: TSource[],
  pageCount: number,
  totalItemCount: number,
  pageNumber: number,
  pageSize: number,
  hasPreviousPage: boolean,
  hasNextPage: boolean,
  isFirstPage: boolean,
  isLastPage: boolean,
  firstItemOnPage: number,
  lastItemOnPage: number
}