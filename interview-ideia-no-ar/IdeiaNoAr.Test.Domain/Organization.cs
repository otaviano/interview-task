using System.Collections.Generic;

namespace IdeiaNoAr.Test.Domain
{
    public class Organization
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int ExternalId { get; set; }

        public Person Owner { get; set; }

        public Address Address { get; set; }

        public IList<Person> People { get; set; }
    }
}
