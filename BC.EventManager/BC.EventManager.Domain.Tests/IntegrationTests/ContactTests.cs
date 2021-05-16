using BC.EventManager.ApplicationLayer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BC.EventManager.Domain.Tests.IntegrationTests
{
    [TestFixture]
    public class ContactTests
    {
        [Test]
        public void Integration__Get_Contact_By_Id()
        {
            var contactId = 1;

            var service = new ApplicationService();
            var contactFromDb = service.GetContact(contactId);

            Assert.IsNotNull(contactFromDb);
        }


        [Test]
        public void Integration__Create_New_Contact()
        {
            // arrange - Define a new contact
            var contact = new Contact()
            {
                FirstName = "Bing",
                LastName = "Chen",
                PhoneNumber = "555-555-5555",
                Email = "bingchen@gmail.com",
                Company = "Intrepid Decisions"
            };

            // act - Call service to persist the contact
            var service = new ApplicationService();
            var savedContact = service.SaveContact(contact);

            // act - Get the contact back
            var contactFromDb = service.GetContact(savedContact.ContactId);

            // assert - make sure contact is not null
            Assert.IsNotNull(contactFromDb);

        }
    }
}
