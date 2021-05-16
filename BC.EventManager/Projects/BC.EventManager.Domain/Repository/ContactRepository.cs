using System;
using System.Collections.Generic;
using System.Text;

using System.Data.SqlClient;
using Dapper;
using System.Linq;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace BC.EventManager.Domain.Repository
{
    public class ContactRepository
    {
        private string connectionString;

        public ContactRepository()
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("AppSettings.json", true).Build();
            connectionString = configuration.GetConnectionString("MyConnection");
        }

        public Contact GetContact(int contactId)
        {
            var db = new SqlConnection(connectionString);
            var query = $@"SELECT * FROM Contacts where contactId = @contactId";
            var parameters = new
            {
                contactId
            };

            db.Open();

            var contact = db.Query<Contact>(query, parameters).SingleOrDefault();

            db.Close();

            return contact;
        }

        //Question:  Should I split out the repository into a separate project from the domain project?
        // What if I want to be able to have 2 different repositories that I swap between?  Entity Framework and Dapper?
        public Contact SaveContact(Contact contact)
        {
            //var connectionString = $@"Data Source=localhost;Initial Catalog=BCEventManager;Integrated Security=True";
            var db = new SqlConnection(connectionString);

            var parameters = new
            {
                contact.ContactId,
                contact.FirstName,
                contact.LastName,
                contact.PhoneNumber,
                contact.Email,
                contact.Company
            };

            db.Open();

            var savedContactId = db.Query<int>("SaveContact", parameters, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();

            //Question:  Should we return the ContactId in the query, or the entire Contact object?
            // Replace int with Contact -> In Stored Procedure select the entire contact object-> Might miss things happening in the GetContact method
            var savedContact = GetContact(savedContactId);

            db.Close();

            return savedContact;
        }
    }
}
