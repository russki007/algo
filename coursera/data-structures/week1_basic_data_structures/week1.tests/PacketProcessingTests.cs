using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xunit;
using Xunit.Sdk;

namespace week1.tests {

    public class PacketProcessingTests {
        
        [Theory]
        [TestSetAttribute(typeof(PacketProcessing))]
        public void MainTest(string input, string output) {
           
        }

        public static TheoryData<string, string> GetTestData() {
            var theoryData = new TheoryData<string, string>();
            foreach (var testSet in new TestFilesProvider(typeof(PacketProcessing)).GetTestSets()) {
                theoryData.Add(testSet.Input, testSet.Output);
            }
            return theoryData;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TestSetAttribute : DataAttribute {
        public TestSetAttribute(Type testClass) {
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod) {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class TestFilesProvider {
        private Assembly ResourceAssembly { get; }

        public TestFilesProvider(Type type) {
            this.ResourceAssembly = type.Assembly;
            var resourceNames = this.ResourceAssembly.GetManifestResourceNames();
        }

        public IEnumerable<(string Input, string Output)> GetTestSets() {
            yield return ("", "");
        }
    }
}