using FilesParser.Data;

namespace FilesParser.Factories
{
    public interface ICompanyParser
    {
        Dictionary<string, string> Parse(string line, IList<string> fieldNames);
    }
}
