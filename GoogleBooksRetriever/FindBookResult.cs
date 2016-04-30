using System.Collections.Generic;

namespace GoogleBooksRetriever
{
    public class FindBookResult
    {
        public List<GoogleBook> GoogleBooks { get; set; }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
