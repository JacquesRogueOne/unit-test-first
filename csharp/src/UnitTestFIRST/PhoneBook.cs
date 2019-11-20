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
            return this.contacts.FirstOrDefault(n => n.PhoneNumber == phoneNumber)?.Name;
        }

        public bool AddContact(Contact newContact)
        {
            if (contacts.Contains(newContact)) return false;
            contacts.Add(newContact);
            return true;
        }



        public List<Contact> FindAllContact(string searchParameter)
        {
            if (string.IsNullOrWhiteSpace(searchParameter)) return this.contacts.ToList();
            return contacts
                .Where(c => c.Name.Contains(searchParameter) || c.PhoneNumber.Contains(searchParameter))
                .ToList();
        }

        public bool RemoveContact(Contact contactToRemove)
        {
            if (contacts.Contains(contactToRemove))
                return false;
            contacts.Remove(contactToRemove);
            return true;
        }

        public string Lookup(string name)
        {
            return contacts
                .FirstOrDefault(contact => contact.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
                ?.PhoneNumber;
        }        
        
        public string ReverseLookup(string phoneNumber)
        {
            return contacts
                .FirstOrDefault(contact => contact.Name.Equals(phoneNumber, StringComparison.InvariantCultureIgnoreCase))
                ?.Name;
        }

        public List<Contact> Contacts => contacts.ToList();
    }
}
