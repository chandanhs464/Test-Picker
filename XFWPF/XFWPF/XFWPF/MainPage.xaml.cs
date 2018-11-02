using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFWPF
{
	public partial class MainPage : ContentPage
	{
        List<string> smallList = null;
        List<string> largeList = null;
		public MainPage()
		{
			InitializeComponent();
            DependencyService.Get<IDBHelper>().MDBDatabaseConnect();
            smallList = DependencyService.Get<IDBHelper>().Test_Series_Read_Few();
            DependencyService.Get<IDBHelper>().MDBDatabaseConnect();
            largeList = DependencyService.Get<IDBHelper>().Test_Series_Read();

            smallPicker.ItemsSource = smallList;
            largePicker.ItemsSource = largeList;
		}
    }
}
