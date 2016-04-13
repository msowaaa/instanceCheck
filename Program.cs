using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;

namespace InstanceChechCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://www.uat.website.com";
            int wrongInstanceCounter = 0;
            int numbersOfChecks = 30;
            string instanceHeader;
            int timeBeetweenChecks = 100;

            HttpWebRequest myHttpWebRequest;
            HttpWebResponse myHttpWebResponse;

            for (int i = 0; i < numbersOfChecks; i++)
            {

                myHttpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();
                myHttpWebResponse.Close();

                instanceHeader = myHttpWebResponse.GetResponseHeader("X-Server");
                
                if (instanceHeader == "Primark-Server-1")
                {
                    Console.WriteLine(" correct instance: " + instanceHeader);
                }
                else
                {
                    Console.WriteLine(" wrong instance: " + instanceHeader);
                    wrongInstanceCounter++;
                }
                Thread.Sleep(timeBeetweenChecks);
            }
            

            Console.WriteLine("");
            Console.WriteLine("number of wrong instances: " + wrongInstanceCounter);
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
