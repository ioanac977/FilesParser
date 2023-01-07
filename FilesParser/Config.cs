namespace FilesParser
{
    public static class Config
    {
        public static readonly IList<string> columnsForFilesWithCommaDelimiter = new List<string>
        {  
            "Company Name",
            "Contact Name",
            "Contact Phone Number",
            "Years in Business",
            "Contact Email"
        };
        public static readonly IList<string> columnsForFilesWithHashDelimiter = new List<string>
        {
            "Company Name",
            "Year Founded",
            "Contact Name",
            "Contact Phone Number"
        };
        public static readonly IList<string> columnsForFilesWithHyphenDelimiter = new List<string>
        { 
            "Company Name",
            "Year Founded",
            "Contact Phone Number",
            "Contact Email",
            "Contact First Name",
            "Contact Last Name"
        };
    }
}
