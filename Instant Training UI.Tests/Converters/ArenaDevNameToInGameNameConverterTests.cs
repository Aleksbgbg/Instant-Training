namespace Instant.Training.UI.Tests.Converters
{
    using System;

    using Instant.Training.UI.Converters;
    using Instant.Training.UI.Tests.TestUtil;

    using Moq;

    using Xunit;

    public class ArenaDevNameToInGameNameConverterTests
    {
        private readonly ArenaDevNameToInGameNameConverter _arenaDevNameToInGameNameConverter;

        public ArenaDevNameToInGameNameConverterTests()
        {
            _arenaDevNameToInGameNameConverter = new ArenaDevNameToInGameNameConverter();
        }

        [Fact]
        public void TestConvert()
        {
            const int arenaIndex = 5;
            string arenaDevName = Constants.ArenaDevNames[arenaIndex];
            string arenaInGameName = Constants.ArenaDevToInGameNameMappings[arenaDevName];

            Assert.Equal(arenaInGameName, _arenaDevNameToInGameNameConverter.Convert(arenaDevName));
        }

        [Fact]
        public void TestConvertBackThrowsNotSupported()
        {
            Action convertBackInvocation = () => _arenaDevNameToInGameNameConverter.ConvertBack(It.IsAny<object>());

            Assert.Throws<NotSupportedException>(convertBackInvocation);
        }
    }
}