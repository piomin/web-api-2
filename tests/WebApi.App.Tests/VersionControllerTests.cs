using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using WebApi.App.Controllers;
using WebApi.Library;
using Xunit;

namespace WebApi.App.Tests
{
    public class VersionControllerTests
    {
        private readonly Mock<ILogger<VersionController>> _loggerMock;
        private readonly VersionController _controller;

        public VersionControllerTests()
        {
            _loggerMock = new Mock<ILogger<VersionController>>();
            _controller = new VersionController(_loggerMock.Object);
        }

        [Fact]
        public void GetVersion_ReturnsOkResult_WithVersion()
        {
            // Act
            var result = _controller.GetVersion();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var versionProperty = okResult.Value.GetType().GetProperty("version");
            Assert.NotNull(versionProperty);
            var versionValue = versionProperty.GetValue(okResult.Value);
            Assert.NotNull(versionValue);
            Assert.IsType<string>(versionValue);
        }

        [Fact]
        public void GetVersion_LogsInformation_WhenCalled()
        {
            // Act
            _controller.GetVersion();

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("GetVersion")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }
}
