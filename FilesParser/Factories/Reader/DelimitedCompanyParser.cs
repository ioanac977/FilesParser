using FilesParser.Data;

namespace FilesParser.Factories.Reader
{
    public abstract class DelimitedCompanyParser : ICompanyParser
    {
        public Dictionary<string, string> Parse(string line, IList<string> fieldNames)
        {
            return ParseFields(line, fieldNames, GetDelimiter());
        }

        protected abstract char GetDelimiter();

        private Dictionary<string, string> ParseFields(string line, IList<string> fieldNames, char delimiter)
        {
            string[] parts = line.Split(delimiter);
            Dictionary<string, string> fields = new Dictionary<string, string>();
            for (int i = 0; i < parts.Length; i++)
            {
                fields[fieldNames[i]] = parts[i];
            }
            return fields;
        }
    }
}
