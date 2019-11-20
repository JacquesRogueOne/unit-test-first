using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestFIRST
{
    public class PhoneBook
    {
        private IList<Contact> contacts;

        public PhoneBook(IEnumerable<Contact> contacts)
        {
            this.contacts = contacts.ToList();
        }

        public string FindName(string phoneNumber)
        {
            return this.contacts.FirstOrDefault(n => n.PhoneNumber == phoneNumber).PhoneNumber;
        }

        public bool AddContact(Contact newContact)
        {
            if (contacts.Contains(newContact)) return false;
            contacts.Add(newContact);
            return true;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return this.contacts;
        }

        public List<Contact> FindAllContact(string searchParameter)
        {
            if (string.IsNullOrWhiteSpace(searchParameter)) return this.contacts.ToList();
            return contacts
                .Where(c => c.Name.Contains(searchParameter) || c.PhoneNumber.Contains(searchParameter))
                .ToList();
        }
    }
}
