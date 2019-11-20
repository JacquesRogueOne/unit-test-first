using System.Collections.Generic;
using System.Linq;
using UnitTestFIRST;

namespace UnitTestFIRSTTests
{
    public static class TestHelper
    {
        public static readonly string MY_CONTACT_CSV = "my-contacts.csv";
        public static IEnumerable<Contact> SampleContacts()
        {
            return new List<Contact>()
            {
                new Contact("Jacques", "0612345678"),
                new Contact("Michael", "0612345679")
            };
        }

        public static IEnumerable<Contact> RetrieveContacts()
        {
            var list = new Persistence().RetrieveFromPersistence(MY_CONTACT_CSV);
            return list.Select(x => new Contact(x.Split(';')[1], x.Split(';')[0]));
        }

        public static void StoreContacts(IEnumerable<Contact> contacts)
        {
            new Persistence().StoreToPersistence(contacts, MY_CONTACT_CSV);
        }
    }


}
