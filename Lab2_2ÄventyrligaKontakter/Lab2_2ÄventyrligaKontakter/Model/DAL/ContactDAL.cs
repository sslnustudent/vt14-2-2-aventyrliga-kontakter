using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Lab2_2ÄventyrligaKontakter.Model.DAL
{
    public class ContactDAL : DALBase
    {

        public IEnumerable<Contact> GetContacts()
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var contacts = new List<Contact>(100);

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactID = reader.GetOrdinal("ContactID");
                        var firstName = reader.GetOrdinal("FirstName");
                        var lastName = reader.GetOrdinal("LastName");
                        var emailAddress = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                                {
                                    ContactID = reader.GetInt32(contactID),
                                    FirstName = reader.GetString(firstName),
                                    LastName = reader.GetString(lastName),
                                    EmailAddress = reader.GetString(emailAddress)

                                });
                        }
                    }

                    contacts.TrimExcess();

                    return contacts;
 
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när kontakter skulle hämtas");
                }
            }
        }

        public IEnumerable<Contact> GetContactsPageWise(int pageSize, int pageIndex, int recordCount)
        {
            using (var conn = CreateConnection())
            {
                try
                {

                    var contacts = new List<Contact>(100);

                    var cmd = new SqlCommand("Person.uspGetContactsPageWise", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);
                    cmd.Parameters.AddWithValue("@RecordCount", recordCount);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var contactID = reader.GetOrdinal("ContactID");
                        var firstName = reader.GetOrdinal("FirstName");
                        var lastName = reader.GetOrdinal("LastName");
                        var emailAddress = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {
                            contacts.Add(new Contact
                                {
                                    ContactID = reader.GetInt32(contactID),
                                    FirstName = reader.GetString(firstName),
                                    LastName = reader.GetString(lastName),
                                    EmailAddress = reader.GetString(emailAddress)

                                });
                        }
                    }

                    contacts.TrimExcess();

                    return contacts;
 
                }

                catch
                {
                    throw new ApplicationException("Ett fel uppstod när kontakter skulle hämtass");
                }
            }
        }

        public Contact GetContactById(int contactId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ContactID", contactId);

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var contactID = reader.GetOrdinal("ContactID");
                            var firstName = reader.GetOrdinal("FirstName");
                            var lastName = reader.GetOrdinal("LastName");
                            var emailAddress = reader.GetOrdinal("EmailAddress");

                            return new Contact
                                {
                                    ContactID = reader.GetInt32(contactID),
                                    FirstName = reader.GetString(firstName),
                                    LastName = reader.GetString(lastName),
                                    EmailAddress = reader.GetString(emailAddress)
                                };

                        }
                    }
                    return null;
                }
                catch
                {
                    throw new ApplicationException("Det uppstod ett fel");
                }
            }
        }

        public void InsertContact(Contact contact)
        {
            using (var conn = CreateConnection())
            {
                try 
                {
                    var cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = contact.EmailAddress;

                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;
                }
                catch 
                {
                    throw new ApplicationException("Ett fell uppstod");
                }
            }
        }

        public void UpdateContact(Contact contact)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactID", contact.ContactID);
                    cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.NVarChar, 50).Value = contact.EmailAddress;
                    

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return;


                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt");
                }
            }
 
        }

        public void DeleteContact(int contactID)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ContactID", contactID);

                    conn.Open();

                    cmd.ExecuteNonQuery();

                    return;


                }
                catch
                {
                    throw new ApplicationException("Ett fel har uppståt");
                }
            }
        }
    }
}