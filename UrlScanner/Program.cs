using System;
using System.Net;

namespace UrlScanner
{
    class Program
    {
        static void Main(string[] args)
        {
            var url = "https://www.kampustenevar.com/yazar-detay-halit-korucu-";
            var id = 11465;

            var loop = true;

            while (loop)
            {
                Console.WriteLine("ID: {0} Status: Başarısız", id.ToString());

                id += 1;
                Onay(url + id.ToString());

            }


            void Onay(string uri)
            {

                try
                {
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest
                                           .Create(uri);
                    webRequest.AllowAutoRedirect = false;
                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();

                    var statuscode = (int)response.StatusCode;

                    if (statuscode != 404)
                    {
                        Console.WriteLine("Sonuç: {0}", id.ToString());

                        loop = false;
                    }
                    else
                    {
                        loop = true;
                    }


                }

                catch
                {
                    loop = true;
                }

            }


            Console.ReadLine();

        }
    }
}
