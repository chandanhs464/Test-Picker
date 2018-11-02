using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Diagnostics;
using Xamarin.Forms;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Collections.ObjectModel;

[assembly: Dependency(typeof(XFWPF.WPF.MDBHelper))]
namespace XFWPF.WPF
{
    public class MDBHelper : IDBHelper
    {

        private string path = null;
        private string mdbFilePath = null;
        private string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=";

        OleDbConnection mdbConnection;
        OleDbCommand mdbCommand;
        OleDbDataReader mdbReader;
        public MDBHelper()
        {
            path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            mdbFilePath = Path.Combine(path, "Test.mdb");
            connectionString += mdbFilePath;
        }

        public void MDBDatabaseConnect()
        {
            // Create a connection  
            mdbConnection = new OleDbConnection(connectionString);

            // Open the connection and execute the select command.  
            try
            {
                // Open connecton  
                mdbConnection.Open();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WPF_databaseConnection_Exception :" + ex);
            }
        }

        public List<string> Test_Series_Read()
        {
            List<string> testList = new List<string>();

            string mdbQuery = "SELECT TEST_SERIES FROM TEST_TABLE";

            // Create a command and set its connection  
            mdbCommand = new OleDbCommand(mdbQuery, mdbConnection);

            try
            {

                mdbReader = mdbCommand.ExecuteReader();
                while (mdbReader.Read())
                {
                    testList.Add(mdbReader["TEST_SERIES"].ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WPF_databaseReader_Exception: " + ex);
            }
            mdbConnection.Close();
            return testList;
        }

        public List<string> Test_Series_Read_Few()
        {
            List<string> testList = new List<string>();

            string mdbQuery = "SELECT TOP 100 TEST_SERIES FROM TEST_TABLE";

            // Create a command and set its connection  
            mdbCommand = new OleDbCommand(mdbQuery, mdbConnection);

            try
            {
                mdbReader = mdbCommand.ExecuteReader();
                while (mdbReader.Read())
                {
                    testList.Add(mdbReader["TEST_SERIES"].ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("WPF_databaseReader_Exception: " + ex);
            }
            mdbConnection.Close();
            return testList;
        }
    }
}
