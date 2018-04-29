using System;
using System.Linq;
using IdeiaNoAr.Test.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdeiaNoAr.Test.UnitTests
{
    [TestClass]
    public class PersonUnitTest
    {
        [TestMethod]
        public void GetPersonByOrganizationShouldReturnDomainObject()
        {
            var serv = new PersonIntegration();

            var objs = serv.GetPeopleFromOrganization(1578);

            Assert.IsNotNull(objs);
            //Assert.IsTrue(objs.All(p => p.ExternalId == 1578));
        }
    }
}
