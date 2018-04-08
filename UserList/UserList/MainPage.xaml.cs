using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserList.Models;
using UserList.ViewModels;
using Xamarin.Forms;

namespace UserList
{
	public partial class MainPage : ContentPage
	{
        public ObservableCollection<User> DisplayUsers { get; set; }

        public MainPage()
		{

			InitializeComponent();
            BindingContext = new UsersViewModel();
		}

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            
        }

        private void SaveButtonClicked(object sender, EventArgs e)
        {
            //code-behind logic
            
        }

        private void name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
