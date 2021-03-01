using Microsoft.VisualStudio.TestTools.UnitTesting;
using CopyObjectLibrary;
using Testing.Models;

namespace Testing
{
    [TestClass]
    public class ExtensionTests
    {
        [TestMethod]
        public void CopyAsTest()
        {
            var src = new ProjectsQueryResult()
            {
                ManagerId = 10,
                ClientId = 34,
                Number = "AFL-D99",
                Description = "sample project",
                IsActive = true,
                Id = 2953
            };

            var dest = src.CopyAs<Project>();

            Assert.IsTrue(dest.ManagerId == src.ManagerId);
            Assert.IsTrue(dest.ClientId == src.ClientId);
            Assert.IsTrue(dest.Number.Equals(src.Number));
            Assert.IsTrue(dest.Description.Equals(src.Description));
            Assert.IsTrue(dest.IsActive.Equals(src.IsActive));
            Assert.IsTrue(dest.Id.Equals(src.Id));
        }

        [TestMethod]
        public void TypeMatching()
        {
            Assert.IsTrue(typeof(bool).IsTypeCloseEnough(typeof(bool?)));
            Assert.IsTrue(typeof(bool?).IsTypeCloseEnough(typeof(bool)));
            Assert.IsTrue(typeof(int?).IsTypeCloseEnough(typeof(int)));
            Assert.IsFalse(typeof(int).IsTypeCloseEnough(typeof(bool)));
            Assert.IsTrue(typeof(int).IsTypeCloseEnough(typeof(int)));
        }

        [TestMethod]
        public void CopyAsFromNullable()
        {
            var src = new GreetingWithNull()
            {
                Value = "whatever",
                IsHappy = true
            };

            var copy = src.CopyAs<GreetingWithoutNull>();
            Assert.IsTrue(copy.Value.Equals(src.Value));
            Assert.IsTrue(copy.IsHappy.Equals(src.IsHappy));

            // when the source property is nullable, but the target isn't, you can try to copy, but it won't set
            src = new GreetingWithNull()
            {
                Value = "whatever",
                IsHappy = null
            };

            copy = src.CopyAs<GreetingWithoutNull>();
            Assert.IsTrue(copy.Value.Equals(src.Value));
            Assert.IsTrue(copy.IsHappy.Equals(default(bool)));
        }

        [TestMethod]
        public void CopyAsToNullable()
        {
            var src = new GreetingWithoutNull()
            {
                Value = "avast!",
                IsHappy = true
            };

            var copy = src.CopyAs<GreetingWithNull>();
            Assert.IsTrue(copy.Value.Equals(src.Value));
            Assert.IsTrue(copy.IsHappy.Equals(src.IsHappy));
        }
    }

    public class GreetingWithNull
    {
        public string Value { get; set; }
        public bool? IsHappy { get; set; }
    }

    public class GreetingWithoutNull
    {
        public string Value { get; set; }
        public bool IsHappy { get; set; }
    }
}
