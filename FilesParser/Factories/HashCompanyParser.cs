using FilesParser.Data;
using FilesParser.Factories.Reader;
using System;

namespace FilesParser.Factories
{
    public class HashCompanyParser : DelimitedCompanyParser
    {
        protected override char GetDelimiter()
        {
            return '#';
        }
    }
}