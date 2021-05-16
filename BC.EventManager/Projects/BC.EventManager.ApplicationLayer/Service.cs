using BC.EventManager.Domain;
using BC.EventManager.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace BC.EventManager.ApplicationLayer
{
    public class ApplicationService
    {
        
        private ContactRepository contactRepository => new ContactRepository();

        public Contact SaveContact(Contact contact)
        {

            return contactRepository.SaveContact(contact);
        }

        public Contact GetContact(int contactId)
        {
            return contactRepository.GetContact(contactId);

        }
    }
}
