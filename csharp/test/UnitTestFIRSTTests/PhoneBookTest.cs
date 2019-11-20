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
        public void should_find_name_matching_phone_number_on_data()
        {
            // Arrange
            var phoneBook = new PhoneBook(TestHelper.RetrieveContacts());

            // Act
            var name = phoneBook.ReverseLookup("0699999999");

            // Assert
            name.Should().Be("Jacques R");
        }
    }

    [TestClass]
    public class Fast
    {
        [TestMethod]
        public void should_find_name_matching_phone_number_on_data()
        {
            // Arrange
            var phoneBook = new PhoneBook(TestHelper.SampleContacts());

            // Act
            var name = phoneBook.ReverseLookup("0612345678");

            // Assert
            name.Should().Be("Jacques");
        }
    }

    [TestClass]
    public class NotSelfValidating
    {
        [TestMethod]
        public void should_find_a_name_matching_phone_number_on_data()
        {
            // Arrange
            var phoneBook = new PhoneBook(TestHelper.SampleContacts());

            // Act
            var name = phoneBook.ReverseLookup("0612345678");

            // Assert
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
            matchingContacts.Count.Should().Be(130381);
        }
        [TestMethod]
        public void should_add_new_contact()
        {
            // Arrange
            var phoneBook = new PhoneBook(TestHelper.RetrieveContacts());
            Contact newContact = new Contact("Jack Napier", "0777777777");

            // Act
            bool contactWasAdded = phoneBook.AddContact(newContact);
            if (contactWasAdded)
            {
                TestHelper.StoreContacts(phoneBook.Contacts);
            }

            // Assert
            contactWasAdded.Should().BeTrue();
        }
    }

}
