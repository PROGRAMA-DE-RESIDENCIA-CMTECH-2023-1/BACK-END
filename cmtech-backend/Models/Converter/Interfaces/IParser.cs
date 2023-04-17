namespace cmtech_backend.Models.Converter.Interfaces
{
    public interface IParser<O,D>
    {
        D Parse(O parser);

        List<D> Parse(List<O> parser);
    }
}
