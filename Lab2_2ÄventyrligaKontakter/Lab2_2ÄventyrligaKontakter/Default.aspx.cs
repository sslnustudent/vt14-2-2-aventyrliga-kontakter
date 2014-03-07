using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab2_2ÄventyrligaKontakter.Model;

namespace Lab2_2ÄventyrligaKontakter
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _service;

        public Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Lab2_2ÄventyrligaKontakter.Model.Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            //return Service.GetContacts();
            //try
            //{
            totalRowCount = Service.GetContacts().Count();
            return Service.GetContactsPageWise(maximumRows, (startRowIndex / 3) + 1, totalRowCount);
            //}
            //catch (Exception)
            //{
            //    //ModelState.AddModelError(String.Empty, "Ett fell inträffade när kontaktere skulle hämtas.");
            
            //}
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                }
                catch
                { 
                    
                }
            }
        }

        public void ContactListView_DeleteItem(int ContactID)
        {
            try
            {
                Service.DeleteContact(ContactID);
            }
            catch
            {
 
            }
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ContactListView_UpdateItem(int ContactID)
        {
            var contact = Service.GetContact(ContactID);
            if (contact == null)
            {
                //ModelState.AddModelError("", String.Format("Item with id {0} was not found", ContactID));
                return;
            }
            if (TryUpdateModel(contact))
            {
                Service.SaveContact(contact);
            }
        }
    }
}