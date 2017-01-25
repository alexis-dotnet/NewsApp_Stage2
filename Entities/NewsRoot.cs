using System.ComponentModel.DataAnnotations;

namespace NewsApp.Entities
{
        public enum NewsType
    {
        Uncategorized,
        Sports,
        Culture,
        Politics,
        Science,
        Fashion
    }

    public class NewsRoot
    {
        public NewsResponse response { get; set; }
        public string status { get; set; }
        public string copyright { get; set; }
    }

    public class NewsResponse
    {
        public NewsMeta meta { get; set; }
        public NewsDoc[] docs { get; set; }
    }

    public class NewsMeta
    {
        public int hits { get; set; }
        public int time { get; set; }
        public int offset { get; set; }
    }

    public class NewsDoc
    {
        public NewsDoc()
        {
            //headline = new NewsHeadline();
            //byline = new NewsByline();
            newsType = NewsType.Uncategorized;
        }

        public string web_url { get; set; }
        public string snippet { get; set; }
        public string lead_paragraph { get; set; }
        public string source { get; set; }
        //public NewsHeadline headline { get; set; }
        public string pub_date { get; set; }
        public string document_type { get; set; }
        public string section_name { get; set; }
        public string subsection_name { get; set; }
        //public NewsByline byline { get; set; }
        public string type_of_material { get; set; }
        [Key]
        public string _id { get; set; }
        //public int word_count { get; set; }
        public NewsType newsType { get; set; }
    }

    public class NewsHeadline
    {
        public string main { get; set; }
        //public string print_headline { get; set; }
    }

    public class NewsByline
    {
        public string original { get; set; }
        //public string organization { get; set; }
    }

}