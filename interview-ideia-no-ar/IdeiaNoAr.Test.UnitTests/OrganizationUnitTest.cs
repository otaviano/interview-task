using System;
using IdeiaNoAr.Test.Integration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IdeiaNoAr.Test.UnitTests
{
    [TestClass]
    public class OrganizationUnitTest
    {
        [TestMethod]
        public void GetOrganizationShouldReturnDomainObject()
        {
            var serv = new OrganizationIntegration();

            var obj = serv.GetOrganization(1578);

            Assert.IsNotNull(obj);
            Assert.AreEqual(obj.ExternalId, 1578);
        }
    }
}
