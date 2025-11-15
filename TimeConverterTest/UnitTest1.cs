using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeConverter;

namespace TimeConverterTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetFullMinutes()
        {
            int input = 550;
            int expected = 9;

            int result = Program.GetFullMinutes(input);

            Assert.AreEqual(expected, result);
        }
    }
}
