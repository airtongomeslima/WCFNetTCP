using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContracts;

namespace WCFClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("abrir conexão");
            Console.ReadLine();
            var uri = "http://localhost:9015/ProductService";
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);

            for (int i = 0; i < 20000; i++)
            {
                    using (var channel = new ChannelFactory<IProductService>(binding))
                    {
                        var endPoint = new EndpointAddress(uri);
                        var proxy = channel.CreateChannel(endPoint);
                        for (int a = 0; a < 3; a++)
                        {
                            proxy?.GetStrings().ToList().ForEach(p => Console.WriteLine(i + " - " + p + "- - " + a));
                        }
                        channel.Close();
                        proxy = null;
                    }
            }

            Console.ReadLine();

        }
    }
}
