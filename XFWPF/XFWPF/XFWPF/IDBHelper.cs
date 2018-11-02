using System;
using System.Collections.Generic;
using System.Text;

namespace XFWPF
{
    public interface IDBHelper
    {

        void MDBDatabaseConnect();

        List<string> Test_Series_Read();

        List<string> Test_Series_Read_Few();
    }
}
