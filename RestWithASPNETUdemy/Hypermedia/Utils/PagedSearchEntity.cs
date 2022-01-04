using System.Collections.Generic;
using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace RestWithASPNETUdemy.Hypermedia;

public abstract class PagedSearchEntity<T> where T : ISupportsHyperMedia
{
    protected PagedSearchEntity()
    { }

    protected PagedSearchEntity(
        int currentPage,
        int pageSize,
        string sortFields,
        string sortDirections)
    {
        CurrentPage = currentPage;
        PageSize = pageSize;
        SortFields = sortFields;
        SortDirections = sortDirections;
    }

    protected PagedSearchEntity(
        int currentPage,
        int pageSize,
        string sortFields,
        string sortDirections,
        Dictionary<string, object> filters) :
        this(currentPage, pageSize, sortFields, sortDirections)
    {
        Filters = filters;
    }

    protected PagedSearchEntity(
        int currentPage,
        string sortFields,
        string sortDirections) :
        this(currentPage, pageSize: 10, sortFields, sortDirections)
    { }

    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalResults { get; set; }
    public string SortFields { get; set; }
    public string SortDirections { get; set; }
    public Dictionary<string, Object> Filters { get; set; }
    public IEnumerable<T> List { get; set; }

    public int GetCurrentPage()
    {
        return CurrentPage == 0 ? 2 : CurrentPage;
    }

    public int GetPageSize()
    {
        return PageSize == 0 ? 10 : PageSize;
    }
}
