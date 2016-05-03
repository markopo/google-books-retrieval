using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO; 
using GoogleBooksRetriever;
using Newtonsoft.Json.Linq;

namespace GoogleBooksConsoleRunner
{
    class Program
    {

        public static string ConvertToXml(object obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                return textWriter.ToString();
            }
        }

        public static GoogleBooksRetriever.GoogleBook FromXmlToGoogleBook(string googleBookXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GoogleBooksRetriever.GoogleBook));
            using (StringReader sr = new StringReader(googleBookXml))
            {
                return xmlSerializer.Deserialize(sr) as GoogleBooksRetriever.GoogleBook;
            }
        }

        public static List<GoogleBooksRetriever.GoogleBook> FromXmlToGoogleBookList(string googleBookXmlList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<GoogleBooksRetriever.GoogleBook>));
            using (StringReader sr = new StringReader(googleBookXmlList))
            {
                return xmlSerializer.Deserialize(sr) as List<GoogleBooksRetriever.GoogleBook>;
            }
        }

        static void Main(string[] args)
        {
            var gr = new FindBooks();
            Console.Write("skriv nåt: ");
            var q = Console.ReadLine();
            //    var data = gr.FindRaw(q);
            ////System.IO.File.WriteAllText(@"C:\BOOKDATA\" + q.Replace(" ", "") + ".txt", data);


            //var path = @"C:\BOOKDATA\HMVC.txt";
            //var text = System.IO.File.ReadAllText(path);
            //var gbList = FromXmlToGoogleBookList(text);

            //foreach (var gb in gbList)
            //{

            //    Console.WriteLine("ti:  " + gb.Title);
            //    if (gb.Categories != null && gb.Categories.Length > 0)
            //    {
            //        Console.WriteLine("cat: "  + gb.Categories[0]);
            //    }

            //}

            var result = gr.Retrieve(q);
            if (result.Success)
            {
                var serBooks = ConvertToXml(result.GoogleBooks);
                System.IO.File.WriteAllText(@"C:\BOOKDATA\" + q.Replace(" ", "") + ".txt", serBooks);

                foreach (var book in result.GoogleBooks)
                {
                    Console.WriteLine(book.Title);
                }

            }
            else
            {
                Console.WriteLine(result.ErrorMessage);
            }

            //var arr = JArray.Parse(@"[ 'kuk', 'fitta' ]");

            //foreach (var a in arr)
            //{
            //    Console.WriteLine(a);
            //}

            //     dynamic jsonData = Newtonsoft.Json.JsonConvert.DeserializeObject(data); 


            Console.ReadLine();


        }
    }
}
