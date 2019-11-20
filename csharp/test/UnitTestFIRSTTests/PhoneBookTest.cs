using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestFIRST;

namespace UnitTestFIRSTTests
{
    [TestClass]
    public class Slow
    {
        [TestMethod]
        public void should_find_name_matching_phone_number_on_data_slow()
        {
            var contacts = TestHelper.RetrieveContacts();
            var phoneBook = new PhoneBook(contacts);

            var name = phoneBook.FindName("0612345678");

            name.Should().Be("Jacques");
        }
    }

    [TestClass]
    public class Fast
    {
        [TestMethod]
        public void should_find_name_matching_phone_number_on_data_fast()
        {
            var contacts = TestHelper.SampleContacts();
            var phoneBook = new PhoneBook(contacts);

            var name = phoneBook.FindName("0612345678");

            name.Should().Be("Jacques");
        }
    }

    [TestClass]
    public class OnDataSlow
    {
        [TestMethod]
        public void should_find_a_name_matching_phone_number_on_data_not_self_validating()
        {
            var contacts = TestHelper.SampleContacts();
            var phoneBook = new PhoneBook(contacts);

            var name = phoneBook.FindName("0612345678");

            Console.WriteLine("nom du contact obtenu en cherchant avec 0612345678 est " + name);
        }
    }

    [TestClass]
    public class Other
    {
        [TestMethod]
        public void should_find_all_contact_matching()
        {
            // Arrange
            PhoneBook phoneBook = new PhoneBook(TestHelper.RetrieveContacts());

            // Act
            List<Contact> matchingContacts = phoneBook.FindAllContact("Ja");

            // Assert
            matchingContacts.Count.Should().Be(266434);
        }
        [TestMethod]
        public void should_add_new_contact()
        {
            var contacts = TestHelper.RetrieveContacts();
            var phoneBook = new PhoneBook(contacts);
            Contact newContact = new Contact("Jack Napier", "0777777777");

            bool contactWasAdded = phoneBook.AddContact(newContact);
            if (contactWasAdded)
            {
                TestHelper.StoreContacts(phoneBook.GetContacts());
            }

            contactWasAdded.Should().BeTrue();
        }
    }

}
