using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MyContacts
{
    internal class ContactRepository : IContactRepository
    {
        private string connectionstring = "Data Source=DESKTOP-MJD6DUJ\\SQL2019;Initial Catalog=Contact_DB;Integrated Security=True";


        public bool Delete(int contactID)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Delete from MyContacts where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("ID", contactID);
                connection.Open();
                command.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }


        }

        public bool Insert(string name, string family, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);
            try
            {
                string query = "Insert Into MyContacts (Name,Family,Email,Age,Address) values (@Name,@Family,@Email,@Age,@Address)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch
            {

                return false;
            }
            finally
            {
                connection.Close();
            }


        }

        public DataTable Search(string pharameter)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = " Select * From MyContacts";
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataAdapter adaper = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adaper.Fill(data);
            return data;
        }

        public DataTable SelectRow(int contactID)
        {
            string query = "Select * From MyContacts where ContactID=" + contactID;
            SqlConnection connection = new SqlConnection(connectionstring);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }


        public bool Update(int contactID, string name, string family, string email, int age, string address)
        {
            SqlConnection connection = new SqlConnection(connectionstring);

            try
            {
                string query = "Update MyContacts set Name=@Name,Family=@Family,Email=@Email,Age=@Age,Address=@Address where ContactID=@ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", contactID);

                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Family", family);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@Address", address);
                connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
