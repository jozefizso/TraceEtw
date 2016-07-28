using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EventProviderGenerator;
using NUnit.Framework;

namespace EventProviderGeneratorTests
{
    [TestFixture]
    public class GenerateEventProviderTests
    {
        [Test]
        public void TestCase01Epx()
        {
            string inputFileName = "TestCase01.epx";
            string goldFileName = "TestCase01.man.gold";

            var inputPath = Path.Combine(UnitTestsEnvironment.DataDirPath, inputFileName);
            var goldPath = Path.Combine(UnitTestsEnvironment.DataDirPath, goldFileName);

            var generator = new GenerateEventProvider();

            var inputXml = generator.LoadInputXml(inputPath);
            var output = generator.GenerateManifest(inputXml, inputXml.Name);

            Assert.NotNull(output);

            string tmpName = Path.GetTempFileName();
            File.WriteAllText(tmpName, output);

            FileAssert.AreEqual(goldPath, tmpName);

            File.Delete(tmpName);
        }
        [Test]
        public void TestCase02Epx()
        {
            string inputFileName = "TestCase02.epx";
            string goldFileName = "TestCase02.man.gold";

            var inputPath = Path.Combine(UnitTestsEnvironment.DataDirPath, inputFileName);
            var goldPath = Path.Combine(UnitTestsEnvironment.DataDirPath, goldFileName);

            var generator = new GenerateEventProvider();

            var inputXml = generator.LoadInputXml(inputPath);
            var output = generator.GenerateManifest(inputXml, inputXml.Name);

            Assert.NotNull(output);

            string tmpName = Path.GetTempFileName();
            File.WriteAllText(tmpName, output);

            FileAssert.AreEqual(goldPath, tmpName);

            File.Delete(tmpName);
        }
    }
}
