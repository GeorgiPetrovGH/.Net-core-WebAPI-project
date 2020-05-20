using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Web.Http.Results;
using Websites.Api.Controllers;
using Websites.Common;
using Websites.Data;

namespace Websites.Api.Tests
{
    [TestFixture]
    public class Delete_Should
    {
        private readonly Mock<WebsiteRepository> mockedRepository;

        public Delete_Should()
        {
            this.mockedRepository = new Mock<WebsiteRepository>();             
        }

        [Test]
        public async Task ReturnBadRequet_WhenNullEntity()
        {
            // Arrange
            this.mockedRepository.Setup(x => x.SoftDelete(It.IsAny<int>())).Returns(Task.FromResult<WebsiteModel>(null));

            var controller = new WebsiteController(this.mockedRepository.Object);

            // Act
            var response = await controller.Delete(10);

            // Assert
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(response);
        }
    }
}
