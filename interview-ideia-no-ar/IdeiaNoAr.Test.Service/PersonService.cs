using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IdeiaNoAr.Test.Domain;
using IdeiaNoAr.Test.Integration;
using IdeiaNoAr.Test.Repository;

namespace IdeiaNoAr.Test.Service
{
    public class PersonService
    {
        PersonIntegration serviceAPI = new PersonIntegration();
        DBContext context = new DBContext();
        
        public IList<Person> GetBy(int OrganizationId)
        {
            return serviceAPI.GetPeopleFromOrganization(OrganizationId);
        }
        
        public IList<Person> GetAll()
        {
            return context.People.ToList();
        }
    }
}
