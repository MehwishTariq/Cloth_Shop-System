using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Clothes_Management
{
    class connection
    {                
        public string myConnectionString =
        "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=D:/source/repos/Clothes_Management/Clothes_Management/ClothData.accdb";
        public OleDbConnection Connect()
        {
            OleDbConnection myConnection = new OleDbConnection(myConnectionString);
            myConnection.Open();
            return myConnection;
        }

       
    }
}
