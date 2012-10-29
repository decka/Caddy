using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq;
using Moq;
using NUnit.Framework;
using Caddy.Domain.Abstract;
using Caddy.Domain.Concrete;
using Caddy.Domain.Entities;

namespace Caddy.UnitTests.Repositories
{
    [TestFixture]
    class PurchasesRepositoryTests
    {
        private IDbConnection dbConnection;
        private DataContext dataContext;

        [SetUp]
        public void ConnectToDatabase()
        {
            string connectionString = @"Server=(LocalDB)\v11.0; Integrated Security=true ;AttachDbFileName=E:\Google Drive\Caddy\CaddyDatabase.mdf";
            
            dbConnection = new SqlConnection(connectionString);
            dataContext = new DataContext(dbConnection);
            dbConnection.Open();
        }

        [Test]
        public void TestConnectionToSQLDatabase()
        {
            // Arrange
            // Act
            // Assert
            Assert.AreEqual(dbConnection.State, ConnectionState.Open);
        }
        [TearDown]
        public void TearDown()
        {
            dbConnection.Close();
        }
    }
    [TestFixture]
    class MockPurchasesRepositoryTests
    {
        public Purchase Purchase1 { get; set; }
        public Purchase Purchase2 { get; set; }
        public Purchase Purchase3 { get; set; }
        public Purchase Purchase4 { get; set; }

        [SetUp]
        public void SetUp()
        {
            Purchase1 = new Purchase { PurchaseID = 1, InvState = PurchaseState.OPEN, Supplier = new Supplier { Name = "One", MYOB = "1" } };
            Purchase2 = new Purchase { PurchaseID = 2, InvState = PurchaseState.CLOSED, Supplier = new Supplier { Name = "Two", MYOB = "2" } };
            Purchase3 = new Purchase { PurchaseID = 3, InvState = PurchaseState.SENDTOMYOB, Supplier = new Supplier { Name = "Three", MYOB = "3" } };
            Purchase4 = new Purchase { PurchaseID = 4, InvState = PurchaseState.OPEN, Supplier = new Supplier { Name = "Four", MYOB = "4" } };
        }
  
        [Test]
        public void InputDatabaseKeys_ReturnsCorrectPurchases()
        {
            // Arrange
            List<Purchase> mockPurchases = new List<Purchase>{ Purchase1, Purchase2, Purchase3, Purchase4};
            IPurchasesRepository mockRepository = new MockPurchasesRepository(mockPurchases);
            List<Purchase> componentUnderTest;
            List<string> mockDatabaseKeys = new List<string> { "2", "3" };

            // Act
            componentUnderTest = mockRepository.GetByDatabaseKeys(mockDatabaseKeys).ToList<Purchase>();

            // Assert
            Assert.Contains(Purchase2, componentUnderTest);
            Assert.Contains(Purchase3, componentUnderTest);
        }

        [Test]
        public void InputDatabaseKeys_ReturnsCorrectMYOBPurchases()
        {
            // Arrange
            List<Purchase> mockPurchases = new List<Purchase> { Purchase1, Purchase2, Purchase3, Purchase4 };
            IPurchasesRepository mockRepository = new MockPurchasesRepository(mockPurchases);
            List<Purchase> componentUnderTest;
            List<string> mockDatabaseKeys = new List<string> { "2", "3" };

            // Act
            componentUnderTest = mockRepository.GetByDatabaseKeysAndSendToMYOB(mockDatabaseKeys).ToList<Purchase>();

            // Assert
            Assert.Contains(Purchase3, componentUnderTest);
        }
    }
}
