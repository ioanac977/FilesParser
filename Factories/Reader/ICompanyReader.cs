namespace FilesParser.Factories.Reader
{
    public interface ICompanyReader
    {
        public IEnumerable<Dictionary<string, string>> Read(string filePath, IList<string> fieldNames);
        public CompanyReader WithDelimiter(char delimiter);
    }
}
