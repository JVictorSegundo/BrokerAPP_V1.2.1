using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrokerAPP.Domain.Tests
{
    [TestClass]
    public class EntitiesTests001
    {
        [TestMethod]
        [DataRow("WZR")]
        [DataRow("NomeLimite")]
        //[DataRow("WINZ@")]
        //[DataRow("WINZÁ")]
        //[DataRow("")]
        //[DataRow(null)]
        public void AssetNameValidation_ShouldFail_WhenNameIsInvalid (string assetName)
        {

            Asset asset = new Asset(assetName, 1);

            Assert.IsTrue(asset.Name == assetName);
        }

        [TestMethod]
        [DataRow("WZRTY")]
        [DataRow("Nomelimite")]
        //[DataRow("WINZ@")]
        //[DataRow("")]
        //[DataRow(null)]
        public void AssetGroupNameValidation_ShouldFail_WhenNameIsInvalid (string assetGroupName)
        {
            AssetGroup assetGroup = new AssetGroup(assetGroupName, 1);

            Assert.IsTrue(assetGroup.Name == assetGroupName);
        }

        [TestMethod]
        [DataRow("WIZNHLOPRYU")]
        [DataRow("NomeGrandeDentroDolimite")]
        //[DataRow("WINZ@")]
        //[DataRow("")]
        //[DataRow(null)]
        public void ClientNameValidation_ShouldFail_WhenNameIsInvalid(string managerName)
        {
            int clientAge = 25;
            long clientBalance = 1000;
            int clientId = 1;
            Client client = new Client(managerName, clientAge, clientBalance, clientId);

            Assert.IsTrue(client.Name == managerName);
        }

        [TestMethod]
        [DataRow(80)]
        [DataRow(25)]
        public void ClientAgeValidation_ShouldFail_WhenAgeIsInvalid (int clientAge)
        {
            string clientName = "Claudio Dantas Soarez";
            long clientBalance = 1000;
            int clientId = 1;
            Client client = new Client(clientName, clientAge, clientBalance, clientId);

            Assert.IsTrue(client.Age == clientAge);
        }

        [TestMethod]
        [DataRow("WIZNHLOPRYU")]
        [DataRow("NomeGrandeDentroDolimite")]
        //[DataRow("WINZ@")]
        //[DataRow("")]
        //[DataRow(null)]
        public void ManagerNameValidation_ShouldFail_WhenNameIsInvalid(string managerName)
        {
            int managerAge = 25;
            int managerId = 1;
            Manager manager = new Manager (managerName, managerAge, managerId);

            Assert.IsTrue(manager.Name == managerName);
        }

        [TestMethod]
        [DataRow(49)]
        [DataRow(27)]
        public void ManagerAgeValidation_ShouldFail_WhenAgeIsInvalid (int managerAge)
        {
            string managerName = "Claudio Dantas Soarez";
            int managerId = 1;
            Manager manager = new Manager (managerName, managerAge, managerId);

            Assert.IsTrue(manager.Age == managerAge);
        }
    }
}
