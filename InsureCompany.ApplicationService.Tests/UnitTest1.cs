using InsureCompany.ApplicationService.Contracts;
using InsureCompany.ApplicationService.Service;
using InsureCompany.DomainModel.Entities;
using InsureCompany.DomainModel.RepositoryContracts;
using Moq;

namespace InsureCompany.ApplicationService.Tests
{
    [TestClass]
    public class ClientServiceTests
    {
        private Mock<IClientRepository> _clientRepositoryMock;
        private Mock<IPolicyRepository> _policyRepositoryMock;
        private IClientService _clientService;

        private IPolicyService _policyService;

        [TestInitialize]
        public void TestInitialize()
        {
            _clientRepositoryMock = new Mock<IClientRepository>();
            _policyRepositoryMock = new Mock<IPolicyRepository>();
            _clientService = new ClientService(_clientRepositoryMock.Object, _policyRepositoryMock.Object);

            _policyService = new PolicyService(_policyRepositoryMock.Object);
        }

        [TestMethod]
        public async Task GetClientByPolicyNumberAsync_ReturnsExpectedClient()
        {
            // Arrange
            var expectedClient = new Client { Id = "1", Name = "Test", Email = "test@test.com", Role = "User" };
            _policyRepositoryMock.Setup(repo => repo.GetUserByPolicyNumberAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedClient);

            // Act
            var result = await _clientService.GetClientByPolicyNumberAsync("test_policy");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedClient, result);
        }
        [TestMethod]

        public async Task GetClientByNameAsync() {
            // Arrange
            var expectedClient = new Client { Id = "1", Name = "Test User", Email = "test@test.com", Role = "user" };

            _clientRepositoryMock.Setup(repo => repo.GetByUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedClient);

            // Act
            var result = await _clientService.GetClientByNameAsync("Test User");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedClient, result);
        }


        [TestMethod]
        public async Task GetByUserNameAsync_ReturnsExpectedPolicies()
        {
            // Arrange
            var expectedPolicies = new List<Policy>
    {
        new Policy { Id = "1", AmountInsured = 1000, Email = "test@test.com", InceptionDate = DateTime.Now, InstallmentPayment = true, ClientId = "1" },
        new Policy { Id = "2", AmountInsured = 2000, Email = "test@test.com", InceptionDate = DateTime.Now, InstallmentPayment = true, ClientId = "1" }
    };

            _policyRepositoryMock.Setup(repo => repo.GetByUserNameAsync(It.IsAny<string>()))
                .ReturnsAsync(expectedPolicies);

            // Act
            var result = await _policyService.GetPoliciesByUserNameAsync("test_user");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPolicies.Count, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsync() {
            var expectedPolicy = new Policy { Id = "1", AmountInsured = 1000, Email = "test@test.com", InceptionDate = DateTime.Now, InstallmentPayment = true, ClientId = "1" };

            _policyRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<string>()))
            .ReturnsAsync(expectedPolicy);
            var result = await _policyService.GetByIdAsync("1");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedPolicy, result);
        }
    }


}