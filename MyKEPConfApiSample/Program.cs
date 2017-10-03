using RestSharp;
using RestSharp.Authenticators;
using System;

namespace MyKEPConfApiSample
{
    class Program
    {
 

        static void Main(string[] args)
        {
            KepConfApiH.kepConfApiUrl = "http://192.168.1.22:57412";
            KepConfApiH.kepAuth = new HttpBasicAuthenticator("Administrator", "");

            Console.WriteLine("Ch:" + KepConfApiH.getChListJson());Console.ReadLine();
            Console.WriteLine("Devs:" + KepConfApiH.getDevListJson("13006")); Console.ReadLine();
            Console.WriteLine("Tags:" + KepConfApiH.getTagListJson("13006","1")); Console.ReadLine();

            var x = KepConfApiH.createCh("mych");//results:  201:created //400:alrady exists //200:ok/deleted
            KepConfApiH.createDev("mych", "mydev");
            KepConfApiH.createTags("mych", "mydev", new string[] { "mytag","mytag2" });

            KepConfApiH.deleteTag("mych", "mydev", "mytag");
            KepConfApiH.deleteDev("mych", "mydev");
            KepConfApiH.deleteCh("mych");
            Console.ReadLine();

        }


       

    }
}
