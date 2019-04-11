namespace Instant.Training.UI.Tests.Converters
{
    using System;

    using Instant.Training.UI.Converters;
    using Instant.Training.UI.Tests.TestUtil;
    using Instant.Training.UI.Utilities;

    using Moq;

    using Xunit;

    public class ArenaNameToImageConverterTests
    {
        private readonly ArenaNameToImageConverter _arenaNameToImageConverter;

        private readonly Mock<IResourceLocator> _resourceLocatorMock;

        public ArenaNameToImageConverterTests()
        {
            _resourceLocatorMock = new Mock<IResourceLocator>();

            _arenaNameToImageConverter = new ArenaNameToImageConverter(_resourceLocatorMock.Object);
        }

        [Fact]
        public void TestConvertCallsFindResource()
        {
            const string resourceName = "SomeResource";

            _arenaNameToImageConverter.Convert(resourceName);

            VerifyLocateResourceCalled(resourceName, Times.Once);
        }

        [Fact]
        public void TestConvertBackThrowsNotSupported()
        {
            Action convertBackCall = () => _arenaNameToImageConverter.ConvertBack(It.IsAny<object>());

            Assert.Throws<NotSupportedException>(convertBackCall);
        }

        private void VerifyLocateResourceCalled(string resourceName, Func<Times> times)
        {
            _resourceLocatorMock.Verify(resourceLocator => resourceLocator.LocateResource(resourceName), times);
        }
    }
}