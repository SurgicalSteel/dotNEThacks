using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Controllers;
using Tweetinvi.Core;
using Tweetinvi.Credentials;
using Tweetinvi.Factories;
using Tweetinvi.Injectinvi;
using Tweetinvi.Json;
using Tweetinvi.Logic;
using Tweetinvi.Security;
using Tweetinvi.Streams;
using Tweetinvi.WebLogic;
using Newtonsoft;
using Newtonsoft.Json;
using System.Net;
using System.IO;
namespace Twitter_Streamer_Console
{
    class Program
    {
        static string cust = "YOUR-CONSUMER-KEY";
        static string custsec = "YOUR-CONSUMER-SECRET";
        static string acto = "YOUR-ACCESS-TOKEN";
        static string actosec = "YOUR-TOKEN-SECRET";
        static void Main(string[] args)
        {
            Auth.SetUserCredentials(cust, custsec, acto, actosec);
            string confirm = "y";
            string inp;
            int maxlimit=10;
            List<string> keywords = new List<string>();
            List<string> tweetresult = new List<string>();
            while (confirm == "y" || confirm == "Y")
            {
                if (keywords.Count > 0)
                {
                    while (keywords.Count > 0) { keywords.RemoveAt(0); }
                }
                if(tweetresult.Count>0)
                {
                    while (tweetresult.Count > 0) { tweetresult.RemoveAt(0); }
                }
                Console.WriteLine("Enter the keywords :\n(separate with a comma if you want to enter multiple)");
                inp = Console.ReadLine();
                Console.WriteLine("Enter maximum tweet limit :");
                maxlimit = int.Parse(Console.ReadLine());
                keywords = inp.Split(',').ToList<string>();
                var stream = Tweetinvi.Stream.CreateFilteredStream();
                foreach (string x in keywords)
                {
                    stream.AddTrack(x);
                }
                int i = 0;
                stream.MatchingTweetReceived += (senders, wargs) =>
                {
                    string s = wargs.Tweet.ToString();
                    tweetresult.Add(s);
                    Console.WriteLine(s);
                    i++;
                    if (i == maxlimit)
                    {
                        stream.StopStream();
                        string csave;
                        Console.WriteLine("Do you want to save the result? (y/n) :");
                        csave = Console.ReadLine();
                        if (csave == "Y" || csave == "y")
                        {
                            Console.WriteLine("Enter full path :");
                            string path =Console.ReadLine();
                            Console.WriteLine("writing to file....");
                            StreamWriter sw = new StreamWriter(path);
                            foreach(string x in tweetresult)
                            {sw.WriteLine(x);}
                            sw.Close();
                            Console.WriteLine("finished writing....");
                        }
                        Console.WriteLine("Do you want to start again? (y/n)");
                        confirm = Console.ReadLine();
                        if (confirm != "y" || confirm != "Y") { Console.WriteLine("Thank You!");Console.ReadLine(); }
                    }
                };
                stream.StartStreamMatchingAllConditions();
            }
        }
    }
}
