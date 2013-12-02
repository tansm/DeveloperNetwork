using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DeveloperNetwork.Common.Test {
    [TestClass]
    public class StringZipTest {

        [TestMethod]
        public void TestGetOrZipString() {
            string[] testStrings = new string[]{
                null,
                string.Empty,
                "abc",
                ".abc",
                "abc.",
                "...",
                "abc.ab",
                "abc.abc..abc"
            };

            StringZip sz = new StringZip();

            foreach (var item in testStrings) {
                var data = sz.ZipString(item);
                var newString = sz.UnzipString(data);
                Assert.AreEqual<string>(item, newString);
            }
        }

        public void TestGetOrPutWord() {
            string[] testStrings = new string[]{
                null,
                string.Empty,
                "abc"
            };

            StringZip sz = new StringZip();

            foreach (var item in testStrings) {
                var data = sz.GetOrAddWord(item);
                var newString = sz.GetWord(data);
                Assert.AreEqual<string>(item, newString);
            }

            Assert.IsTrue(sz.GetWord(int.MaxValue) == null);
        }
    }
}
