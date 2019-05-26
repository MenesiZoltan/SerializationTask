using System;
using SerializePeople;
using NUnit.Framework;

namespace ClassTesting
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void ConstructorMethod_AddValidInformation_ToStringWorkingCorrectly()
        {
            DateTime dob = new DateTime(1993, 9, 17, 18, 32, 0);
            Person person = new Person("Zoli", dob, Gender.Male);
            string exceptedResult = "Name: Zoli; DateOfBirth: 17/09/1993 00:00:00; Gender: Male; Age: 25";

            Assert.AreEqual(exceptedResult, person.ToString());
        }
    }
}
