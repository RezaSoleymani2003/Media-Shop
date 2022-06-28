using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestMethod()]
        public void CheckerTest()
        {
            Assert.AreEqual(true,Student.Checker("91234567"));
            Assert.AreEqual(false, Student.Checker("9f234567"));
            Assert.AreEqual(false, Student.Checker("99234h67"));
            Assert.AreEqual(false, Student.Checker("61234567"));
            Assert.AreEqual(false, Student.Checker("o1234067"));
            Assert.AreEqual(false, Student.Checker("9924567"));

        }
    }
}