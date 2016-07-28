using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EventProviderGeneratorTests
{
    [SetUpFixture]
    public class UnitTestsEnvironment
    {
        public static string DataDirPath;

        [OneTimeSetUp]
        public void SetupEnvironment()
        {
            var codebase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new Uri(codebase);

            var workingDir = Path.GetDirectoryName(uri.LocalPath);
            var wd = new DirectoryInfo(workingDir);

            var dataDir = GetUnitTestsRootDirectory(wd);
            DataDirPath = Path.Combine(dataDir.FullName, "data");
        }

        public static DirectoryInfo GetUnitTestsRootDirectory(DirectoryInfo directory)
        {
            var topDir = directory;

            while (directory != null)
            {
                var rootMarkerFile = Path.Combine(directory.FullName, "tests.root");
                if (File.Exists(rootMarkerFile))
                {
                    return directory;
                }

                directory = directory.Parent;
            }

            return topDir;
        }
    }
}
