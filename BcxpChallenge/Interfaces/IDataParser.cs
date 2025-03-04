
namespace BcxpChallenge.Interfaces
{
    public interface IDataParser<T>
    {
        List<T> ParseData(IDataReader reader);
    }
}
