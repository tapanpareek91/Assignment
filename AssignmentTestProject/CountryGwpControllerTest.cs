using Assignment.Controllers;
using Assignment.Models;
using Assignment.Repository;
using Assignment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace AssignmentTestProject
{
    [TestClass]
    public class CountryGwpControllerTest
    {
        private readonly ICountryGwpService countryGwpService;
        private readonly Mock<ICountryGwpRepository> mockRepo;
        public CountryGwpControllerTest()
        {
            this.mockRepo = new Mock<ICountryGwpRepository>();
            this.countryGwpService = new CountryGwpService(this.mockRepo.Object);
        }
        [TestMethod]
        public async Task GetAvgGwpAsync_success()
        {
            // Arrange
            var controller = new CountryGwpController(this.countryGwpService);
            GwpAvgRequest request = new GwpAvgRequest { Country = "ae", LineOfBusiness = new List<string>() };
            request.LineOfBusiness.Add("transport");
            request.LineOfBusiness.Add("freight");
            request.LineOfBusiness.Add("property");

            var result = new Dictionary<string, double>();
            foreach (var item in request.LineOfBusiness)
            {
                result.Add(item, 1.0);
            }

            this.mockRepo.Setup(x => x.GetGwpAvgAsync(It.IsAny<GwpAvgRequest>())).ReturnsAsync(result);

            // Act
            var response = await controller.GetAvgGwpAsync(request).ConfigureAwait(false);

            //Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Count, result.Count);
        }
    }
}
