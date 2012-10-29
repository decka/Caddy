using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Caddy.Domain.Entities;
using Caddy.Domain.Abstract;
using Caddy.Domain.Concrete;
using Caddy.Server;

namespace Caddy.UnitTests
{
    [TestFixture]
    class ServerGodTests
    {
        public Purchase Purchase1 { get; set; }
        public Purchase Purchase2 { get; set; }
        public Purchase Purchase3 { get; set; }
        public Purchase Purchase4 { get; set; }
        public Purchase Purchase5 { get; set; }
        public Client Client1 { get; set; }
        public Client Client2 { get; set; }
        public Client Client3 { get; set; }
        public Client Client4 { get; set; }
        public Client Client5 { get; set; }
        public Client Client6 { get; set; }
        public List<Purchase> MockPurchases { get; set; }
        public IPurchasesRepository MockRepository { get; set; }
        public ServerGod ServerGod { get; set; }

        [SetUp]
        public void SetUp()
        {
            Purchase1 = new Purchase { PurchaseID = 1, InvState = PurchaseState.OPEN, DatabaseKey = "db1", Desription = "Purchase1", Project = new Project { ProjectName = "Project1" }, Supplier = new Supplier { Name = "Supplier1" } };
            Purchase2 = new Purchase { PurchaseID = 2, InvState = PurchaseState.CLOSED, DatabaseKey = "db2", Desription = "Purchase2", Project = new Project { ProjectName = "Project2" }, Supplier = new Supplier { Name = "Supplier2" } };
            Purchase3 = new Purchase { PurchaseID = 3, InvState = PurchaseState.SENDTOMYOB, DatabaseKey = "db3", Desription = "Purchase3", Project = new Project { ProjectName = "Project3" }, Supplier = new Supplier { Name = "Supplier3" } };
            Purchase4 = new Purchase { PurchaseID = 4, InvState = PurchaseState.OPEN, DatabaseKey = "db4", Desription = "Purchase4", Project = new Project { ProjectName = "Project4" }, Supplier = new Supplier { Name = "Supplier4" } };
            Purchase5 = new Purchase { PurchaseID = 5, InvState = PurchaseState.SENDTOMYOB, DatabaseKey = "db5", Desription = "Purchase5", Project = new Project { ProjectName = "Project5" }, Supplier = new Supplier { Name = "Supplier5" } };

            Client1 = new Client { ConnectionID = "1", DatabaseKey = "db1", Username = "User1", Password = "Password1" };
            Client2 = new Client { ConnectionID = "2", DatabaseKey = "db2", Username = "User2", Password = "Password2" };
            Client3 = new Client { ConnectionID = "3", DatabaseKey = "db3", Username = "User3", Password = "Password3" };
            Client4 = new Client { ConnectionID = "4", DatabaseKey = "db4", Username = "User4", Password = "Password4" };
            Client5 = new Client { ConnectionID = "5", DatabaseKey = "db5", Username = "User5", Password = "Password5" };
            Client6 = new Client { ConnectionID = "6", DatabaseKey = "db3", Username = "User6", Password = "Password6" };
            
            MockPurchases = new List<Purchase> { Purchase1, Purchase2, Purchase3, Purchase4, Purchase5 };
            MockRepository = new MockPurchasesRepository(MockPurchases);
            ServerGod = new ServerGod(MockRepository);
        }

        [Test]
        public void RegisterClient()
        {
            // Arrange
            
            // Act
            ServerGod.ClientRegisterWithServer(Client1);

            // Assert
            Assert.IsNotEmpty(ServerGod.RegisteredClients);
        }

        [Test]
        public void ReadDataFromRepository()
        {
            // Arrange
            ServerGod.ClientRegisterWithServer(Client1);
            ServerGod.ClientRegisterWithServer(Client2);
            ServerGod.ClientRegisterWithServer(Client3);
            ServerGod.ClientRegisterWithServer(Client4);
            ServerGod.ClientRegisterWithServer(Client5);
            ServerGod.ClientRegisterWithServer(Client6);
            List<Purchase> componentUnderTest;
            // Act
            componentUnderTest = ServerGod.ReadDataFromRepository();
                       
            // Assert
            Assert.Contains(Purchase3, componentUnderTest);
            Assert.Contains(Purchase5, componentUnderTest);
        }
        
        [Test]
        public void CreateDTOsForClients()
        {
            // Arrange
            ServerGod.ClientRegisterWithServer(Client1);
            ServerGod.ClientRegisterWithServer(Client2);
            ServerGod.ClientRegisterWithServer(Client3);
            ServerGod.ClientRegisterWithServer(Client4);
            ServerGod.ClientRegisterWithServer(Client5);
            ServerGod.ClientRegisterWithServer(Client6);
            List<ClientDTO> componentUnderTest;
            // Act
            componentUnderTest = ServerGod.CreateDTOsForAllClients(ServerGod.ReadDataFromRepository());

            // Assert
            Assert.Contains(Client3, componentUnderTest.Select(p => p.Client).ToList());
            Assert.Contains(Client5, componentUnderTest.Select(p => p.Client).ToList());
            Assert.Contains(Client6, componentUnderTest.Select(p => p.Client).ToList());
        }
    }
}
