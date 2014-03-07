using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Lab2_2ÄventyrligaKontakter.Model.DAL;

namespace Lab2_2ÄventyrligaKontakter.Model
{
    public class Service
    {
        private ContactDAL _contactDAL;

        private ContactDAL ContactDAL
        {
            get { return _contactDAL ?? (_contactDAL = new ContactDAL()); }
        }

        public IEnumerable<Contact> GetContacts() 
        {
            return ContactDAL.GetContacts();
        }

        public IEnumerable<Contact> GetContactsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {

            return ContactDAL.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }


        public Contact GetContact(int contactId)
        {
            return ContactDAL.GetContactById(contactId);
        }

        public void DeleteContact(int contactID)
        {
            ContactDAL.DeleteContact(contactID);
        }

        public void SaveContact(Contact contact)
        {
            var validationContext = new ValidationContext(contact);
            var validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateObject(contact, validationContext, validationResults, true))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            if (contact.ContactID == 0)
            {
                ContactDAL.InsertContact(contact);
            }
            else
            {
                ContactDAL.UpdateContact(contact);
            }
        }


    }
}