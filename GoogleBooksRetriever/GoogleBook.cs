﻿using System;

namespace GoogleBooksRetriever
{
    [Serializable]
    public class GoogleBook
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string[] Authors { get; set; }
        public string Publisher { get; set; }
        public string PublishedDate { get; set; }
        public string Description { get; set; }
        public string PageCount { get; set; }
        public string PrintType { get; set; }
        public string[] Categories { get; set; }
        public string AverageRating { get; set; }
        public string ThumbNail { get; set; }
        public string Language { get; set; }
        public string CanonicalVolumeLink { get; set; }
        public string WebReaderLink { get; set; }
        public string PdfLink { get; set; }
        public string ISBN13 { get; set; }
        public string ISBN10 { get; set; }  
    }
}
