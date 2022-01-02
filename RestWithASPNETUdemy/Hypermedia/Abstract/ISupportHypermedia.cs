namespace RestWithASPNETUdemy.Hypermedia.Abstract;

public interface ISupportHypermedia
{
    IEnumerable<HyperMediaLink> Links { get; set; }
}