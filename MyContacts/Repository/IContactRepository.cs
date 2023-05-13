using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyContacts
{
    internal interface IContactRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactID);
        bool Insert(string name,string family,string email,int age,string address);
        bool Update( int contactID,string name, string family, string email, int age, string address);
        bool Delete(int contactID);
        DataTable Search(string pharameter);
    }
}
