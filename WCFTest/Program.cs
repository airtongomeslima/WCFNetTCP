using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFContracts;

namespace WCFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var uris = new Uri[1];
            string addr = "http://localhost:9015/ProductService";
            uris[0] = new Uri(addr);


            ServiceHost host = new ServiceHost(typeof(ProductService), uris);
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            host.AddServiceEndpoint(typeof(IProductService), binding, "");
            host.Opened += HostOpened;
            host.Open();

            Console.ReadLine();
            host.Close();
        }

        private static void HostOpened(object sender, EventArgs e)
        {
            Console.WriteLine("WCF service is started");
        }
    }
}
