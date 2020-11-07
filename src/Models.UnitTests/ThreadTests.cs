using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HawkLab.Courier.Models.UnitTests {
    [TestClass]
    public class ThreadTests {
        [TestMethod]
        public void TestThreadHasTitle() {
            var thread = new Thread();

            Assert.IsNull(thread.Title);
        }
    }
}
