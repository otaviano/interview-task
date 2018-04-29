using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using IdeiaNoAr.Test.Domain;
using IdeiaNoAr.Test.Integration;
using IdeiaNoAr.Test.Repository;

namespace IdeiaNoAr.Test.Service
{
    public class OrganizationService
    {
        OrganizationIntegration serviceAPI = new OrganizationIntegration();
        PersonService servicePerson = new PersonService();
        DBContext context = new DBContext();
        
        public Organization Create(int externalId)
        {
            var organization = serviceAPI.GetOrganization(externalId);
            organization.People = servicePerson.GetBy(externalId);
            
            if (!context.Organizations.Any(p => p.ExternalId == externalId))
            {
                context.Organizations.Add(organization);
                context.SaveChanges();
            }

            return organization;
        }

        public Organization Edit(Organization organization)
        {
            context.Entry(organization).State = EntityState.Modified;
            context.SaveChanges();
            
            return organization;
        }
        
        public Organization GetBy(int id)
        {
            return context.Organizations.SingleOrDefault(p => p.Id == id);
        }

        public IList<Organization> GetAll()
        {
            return context.Organizations.ToList();
        }

        public void Delete(int id)
        {
            var obj = new Organization { Id = id };
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}
