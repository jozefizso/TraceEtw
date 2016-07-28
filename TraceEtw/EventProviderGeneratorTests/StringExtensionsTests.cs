using System;
using System.Collections.Generic;
using System.Linq;
using EventProviderGenerator;
using NUnit.Framework;

namespace EventProviderGeneratorTests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        [Test]
        public void GetSafeString_ProviderNameWithDots_ReturnsSanitizedProviderName()
        {
            // Arrange
            var userProvidedName = "Company.ProviderName";

            // Act
            var actualProviderName = StringExtensions.GetSafeString(userProvidedName);

            // Assert
            Assert.AreEqual("Company_ProviderName", actualProviderName);
        }

        [Test]
        public void GetSafeString_ProviderNameWithDashes_ReturnsSanitizedProviderName()
        {
            // Arrange
            var userProvidedName = "Company-ProviderName";

            // Act
            var actualProviderName = StringExtensions.GetSafeString(userProvidedName);

            // Assert
            Assert.AreEqual("Company_ProviderName", actualProviderName);
        }

        [Test]
        [TestCase("Company_ProviderName", "{087dbfbb-b160-5b9e-6848-551a57847db4}")]
        [TestCase("Company-Product-Component", "{25919991-eb95-5bdc-42b1-e284dbe4c542}")]
        public void GetGuidFromName_ProviderName_ReturnsDerivedGuid(string validProviderName, string expectedGuidValue)
        {
            // Arrange
            var expectedGuid = Guid.Parse(expectedGuidValue);

            // Act
            var actualGuid = StringExtensions.GetGuidFromName(validProviderName);

            // Assert
            Assert.AreEqual(expectedGuid, actualGuid);
        }
    }
}
