using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Caddy.Domain;
using Caddy.Domain.Abstract;
using Caddy.Domain.Concrete;

namespace Caddy.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IPurchasesRepository PurchasesRepository = new FakePurchasesRepository(); // TODO: Wire up with IoC.
            
            foreach (var x in PurchasesRepository.Purchases)
            {
                Console.WriteLine("FakePurchase ID: {0}, Description: {1}.", x.PurchaseID, x.Desription);
            }
            Console.ReadKey();
        }
    }
}
