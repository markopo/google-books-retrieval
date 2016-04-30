using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.IO; 
using GoogleBooksRetriever; 

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
      
        static void Main(string[] args)
        {
            var gr = new FindBooks();
            Console.Write("skriv nåt: ");
            var q = Console.ReadLine();
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

            Console.ReadLine();


        }
    }
}
