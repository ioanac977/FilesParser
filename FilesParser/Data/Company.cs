using System.Text.Json.Serialization;

namespace FilesParser.Data
{
    public class Company
    {
        private Dictionary<string, string> _fields;

        public Company(Dictionary<string, string> fields)
        {
            _fields = fields;
        }
        public string this[string fieldName]
        {
            get
            {
                return _fields[fieldName];
            }
        }

    }
}
