using System;
using System.Collections.Generic;
using System.Linq;
using EventProviderGenerator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EventProviderGeneratorTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void GetSafeString_ProviderNameWithDots_ReturnsSanitizedProviderName()
        {
            // Arrange
            var userProvidedName = "Company.ProviderName";

            // Act
            var actualProviderName = StringExtensions.GetSafeString(userProvidedName);

            // Assert
            Assert.AreEqual("Company_ProviderName", actualProviderName);
        }

        [TestMethod]
        public void GetSafeString_ProviderNameWithDashes_ReturnsSanitizedProviderName()
        {
            // Arrange
            var userProvidedName = "Company-ProviderName";

            // Act
            var actualProviderName = StringExtensions.GetSafeString(userProvidedName);

            // Assert
            Assert.AreEqual("Company_ProviderName", actualProviderName);
        }

        [TestMethod]
        public void GetGuidFromName_ProviderName_ReturnsDerivedGuid()
        {
            // Arrange
            var expectedGuid = Guid.Parse("{087dbfbb-b160-5b9e-6848-551a57847db4}");
            var validProviderName = "Company_ProviderName";

            // Act
            var actualGuid = StringExtensions.GetGuidFromName(validProviderName);

            // Assert
            Assert.AreEqual(expectedGuid, actualGuid);
        }
    }
}
