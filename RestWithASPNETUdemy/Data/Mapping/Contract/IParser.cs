namespace RestWithASPNETUdemy.Data.Mapping.Contract;

public interface IParser<Origin, Destiny>
{
    Destiny Parse(Origin Origem);
    IEnumerable<Destiny> Parse(IEnumerable<Origin> Origem);

    Origin Parse(Destiny Origem);
    IEnumerable<Origin> Parse(IEnumerable<Destiny> Origem);

}
