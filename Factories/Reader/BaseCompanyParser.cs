namespace FilesParser.Factories.Reader
{
    public abstract class BaseCompanyParser : ICompanyParser
    {
        protected char Delimiter { get; set; }
        public Dictionary<string, string> Parse(string line, IList<string> fieldNames)
        {
            return ParseFields(line, fieldNames, Delimiter);
        }

        private Dictionary<string, string> ParseFields(string line, IList<string> fieldNames, char delimiter)
        {
            string[] parts = line.Split(delimiter);
            Dictionary<string, string> fields = new();
            for (int i = 0; i < parts.Length; i++)
            {
                fields[fieldNames[i]] = parts[i];
            }
            return fields;
        }
    }
}
