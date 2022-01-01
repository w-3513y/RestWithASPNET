namespace RestWithASPNETUdemy.Data.Converter.Contract;

public interface IParser<O, D>
{
    D Parse(O Origem);
    IEnumerable<D> Parse(List<O> Origem);
}