using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using HelloWorldExtensibleConsole.Code;

namespace HelloWorldExtensibleConsole
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static void Main()
        {
            RunAsync().Wait();
        }

        /// <summary>
        /// Make web service call 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>HTTP server root (protocol & host - http://www.example.org/)</returns>
        static async Task<string> GetGreetingAsync(string path)
        {
            string greetingResponse = string.Empty;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                greetingResponse = await response.Content.ReadAsAsync<string>();
            }
            return greetingResponse;
        }

        static async Task RunAsync()
        {
            // 1: Set everything up
            Greeting greeting = new Greeting();
            client.BaseAddress = new System.Uri(ConfigurationManager.AppSettings["baseURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            //
            // 2: Call /api/hello for "Hello World"
            try
            {
                Console.WriteLine("Saying hello to everyone from {0}...", client.BaseAddress.ToString());
                greeting.Response = await GetGreetingAsync("/api/Hello");
                if (!String.IsNullOrEmpty(greeting.Response))
                {
                    Console.WriteLine(greeting.Response);
                }
                else
                {
                    Console.WriteLine("No one to say hello");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();

            //
            // 2: Call /api/hello?audience={0} for "Hello {0}"
            try
            {
                string inputAudience = string.Empty;
                Console.WriteLine("Saying hello to someone specific from {0}...", client.BaseAddress.ToString());
                

                while (string.IsNullOrEmpty(inputAudience))
                {
                    Console.WriteLine("Who shall we say \"Hello\" to?");
                    Console.Write("[everybody]: ");
                    inputAudience = Console.ReadLine();
                }

                

                greeting.Response = await GetGreetingAsync(string.Format("/api/Hello?audience={0}", inputAudience));

                if (!string.IsNullOrEmpty(greeting.Response))
                {
                    Console.WriteLine(greeting.Response);
                }
                else
                {
                    Console.WriteLine("No one to say hello");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();


        }

        


    }
}
