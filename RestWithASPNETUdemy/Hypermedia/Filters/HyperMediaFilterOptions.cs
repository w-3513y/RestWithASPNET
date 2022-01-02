using RestWithASPNETUdemy.Hypermedia.Abstract;

namespace RestWithASPNETUdemy.Hypermedia.Filters;

public class HyperMediaFilterOptions
{
    public IEnumerable<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
}