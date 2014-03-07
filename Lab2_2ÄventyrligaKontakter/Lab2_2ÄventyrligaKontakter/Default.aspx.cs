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
            if (Session["a"] != null)
            {
                LabelOk.Text = Convert.ToString(Session["a"]);
                OkDiv.Visible = true;
                Session.Remove("a");
            }

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression                                                                            startRowIndex
        public IEnumerable<Lab2_2ÄventyrligaKontakter.Model.Contact> ContactListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            try
            {
                return Service.GetContactsPageWise(maximumRows, startRowIndex, out totalRowCount);
            }
            catch
            {

                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när kontakter skulle hämtas.";
                cv.IsValid = false;
                Page.Validators.Add(cv);
                totalRowCount = 0;
                return null;
            }
        }

        public void ContactListView_InsertItem(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveContact(contact);
                    Session["a"] = "Kontakten har blivit upplagd!!!";
                    Response.Redirect("~/Default.aspx");
                }
                catch
                {
                    CustomValidator cv = new CustomValidator();
                    cv.ErrorMessage = "Ett fel inträffade när kontakten skulle läggas up";
                    cv.IsValid = false;
                    Page.Validators.Add(cv);
                }
            }
        }

        public void ContactListView_DeleteItem(int ContactID)
        {
            try
            {
                Service.DeleteContact(ContactID);
                Session["a"] = "Kontakten har blivit raderad!!!";
                Response.Redirect("~/Default.aspx");
            }
            catch
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när kontakten skulle raderas";
                cv.IsValid = false;
                Page.Validators.Add(cv);


            }
        }

        public void ContactListView_UpdateItem(int ContactID)
        {
            var contact = Service.GetContact(ContactID);
            if (contact == null)
            {
                CustomValidator cv = new CustomValidator();
                cv.ErrorMessage = "Ett fel inträffade när kontakten skulle uppdateras";
                cv.IsValid = false;
                Page.Validators.Add(cv);
            }
            if (TryUpdateModel(contact))
            {
                Service.SaveContact(contact);
                Session["a"] = "Kontakten har blivit uppdaterad!!!";
                Response.Redirect("~/Default.aspx");
            }
        }
    }
}