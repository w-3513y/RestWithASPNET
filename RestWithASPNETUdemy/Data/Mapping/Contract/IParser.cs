namespace RestWithASPNETUdemy.Data.Mapping.Contract;

public interface IParser<O, D>
{
    D Parse(O Origem);
    IEnumerable<D> Parse(IEnumerable<O> Origem);
}