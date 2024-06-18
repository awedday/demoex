using NUnit.Framework;
using NUnit.Framework.Legacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Tests
{
    [TestFixture]
    public  class Class1
    {
        [Test]

        public void Test1()
        {
            var functional = new Functional();
            int result = functional.CountUsers();
            Assert.That(Equals(3, result));
        }

        [Test]
        public void Test2()
        {
            var functional = new Functional();
            string result = functional.IDUser();
            Assert.That(Equals("2", result));

        }

        [Test]
        public void Test3()
        {
            var list = new Session1_XXEntities();
            var result = list.Countries.ToList();
            CollectionAssert.IsNotEmpty(result);
        }

    }
}
