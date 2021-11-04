using Lib.Models.Persons;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalTesting
{
    [TestFixture]
    class UserModuleTest
    {
        private User _user;

        [SetUp]
        public void StartUp()
        {
            _user = new User();
        }

        [Test, Description("User can generate random user")]
        public void Test_User_CreateNewRandomUser()
        {
            var newUser = _user.CreateNewRandomUser();
            Assert.IsNotNull(newUser);
        }

        [Test]
        public void Test_User_CreateNewRandomUser_NotReturnsNull()
        {
            var newUser = _user.CreateNewRandomUser();
            Debug.Print($"Name: {newUser.Name}\n Age: {newUser.Age}\n Salary: {newUser.Salary}$");
            Assert.IsTrue(newUser.Age > 0 && newUser.Salary > 0 && !newUser.Name.Equals("Name"));
        }

        [Test]
        public void Test_User_CreateNewRandom_Equals()
        {
            var expected = _user.CreateNewRandomUser();
            var actual = _user.CreateNewRandomUser();
            Assert.IsTrue(!expected.Equals(actual));
        }

        [Test]
        public void Test_User_Equals_Works()
        {
            var Id = Guid.NewGuid();
            var expected = new User() { Name = "Name", Age = 18, Salary = 20.00, Surname = "Sname", Id = Id };
            var actual = new User() { Name = "Name", Age = 18, Salary = 20.00, Surname = "Sname", Id = Id };
            Assert.IsTrue(expected.Equals(actual));
        }
    }
}
