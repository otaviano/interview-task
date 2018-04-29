using System.Collections.Generic;

namespace IdeiaNoAr.Test.Domain
{
    public class Person
    {
        public int Id { get; set; }

        public int ExternalId { get; set; }

        public string Name { get; set; }

        public string Info { get; set; }

        public IList<Email> Emails { get; set; }

        public IList<Phone> Phones { get; set; }
    }
}
