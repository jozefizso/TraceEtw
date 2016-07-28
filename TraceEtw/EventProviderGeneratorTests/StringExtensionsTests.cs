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
    }
}
