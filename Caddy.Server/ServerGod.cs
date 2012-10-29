using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caddy.Domain.Abstract;
using Caddy.Domain.Entities;
using System.Diagnostics;

namespace Caddy.Server
{
    public class ServerGod
    {
        public List<Client> RegisteredClients { get; set; }
        public List<string> RegisteredDatabaseKeys { get; set; }
        
        private readonly IPurchasesRepository PurchasesRepository;

        public ServerGod(IPurchasesRepository purchasesRepository)
        {
            //Dependency Injection of Repository
            this.PurchasesRepository = purchasesRepository;
            this.RegisteredClients = new List<Client>();
            this.RegisteredDatabaseKeys = new List<string>();

        }
        public void ClientRegisterWithServer(Client clientToRegister)
        {
            RegisteredClients.Add(clientToRegister);
            RegisteredDatabaseKeys.Add(clientToRegister.DatabaseKey);
        }
        public List<Purchase> ReadDataFromRepository()
        {
            return PurchasesRepository.GetByDatabaseKeysAndSendToMYOB(RegisteredDatabaseKeys).ToList<Purchase>();
        }
        public List<ClientDTO> CreateDTOsForAllClients(List<Purchase> purchases)
        {
            var ClientDTOs = new List<ClientDTO>();
            var PurchaseDTOAssembler = new PurchaseDTOAssembler();

            foreach (var purchase in purchases)
            {
                var tempPurchaseDTO = PurchaseDTOAssembler.CreateDTO(purchase);
                foreach(var applicableClient in RegisteredClients.Where(p => p.DatabaseKey == purchase.DatabaseKey))
                {
                    ClientDTOs.Add(new ClientDTO { Client = applicableClient, PurchaseDTO = tempPurchaseDTO });
                }
            }
            return ClientDTOs;
        }
        public void SendDTOsToClients(List<ClientDTO> ClientDTOs)
        {
            foreach (var ClientDTO in ClientDTOs)
            {
                //
            }
        }
    }
}
