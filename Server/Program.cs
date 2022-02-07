using System;
using System.Text;

using System.ServiceModel;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {                    
            ServiceHost host = new ServiceHost(typeof(MyService), new Uri("http://localhost:8000/MyService"));
                                
            host.AddServiceEndpoint(typeof(IMyService), new BasicHttpBinding(), "");
                                
            host.Open();
            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
                                
            host.Close();
        }
    }
}
