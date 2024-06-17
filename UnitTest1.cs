using WpfApp1;

namespace TestProject1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var functional = new Functional();
            int result = functional.CountUsers();
            Assert.AreEqual(1, result);
        }
    }
}