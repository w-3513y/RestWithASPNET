using System.Text;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Entities;
using RestWithASPNETUdemy.Hypermedia.Constants;

namespace RestWithASPNETUdemy.Hypermedia.Enricher;

public class BookEnricher : ContentResponseEnricher<BookEntity>
{
    private readonly object _lock = new();
    protected override Task EnrichModel(BookEntity content,
                                        IUrlHelper urlHelper)
    {
        var path = "api/book/v1";
        string link = GetLink(content.Id, urlHelper, path);

        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.GET,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultGet
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.POST,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultPost
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.PUT,
            Href = link,
            Rel = RelationType.self,
            Type = ResponseTypeFormat.DefaultPut
        });
        content.Links.Add(new HyperMediaLink()
        {
            Action = HttpActionVerb.DELETE,
            Href = link,
            Rel = RelationType.self,
            Type = "int"
        });
        return Task.CompletedTask;
    }

    private string GetLink(int id, IUrlHelper urlHelper, string path)
    {
        lock (_lock)
        {
            var url = new
            {
                controller = path,
                id = id
            };
            return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
        };
    }
}