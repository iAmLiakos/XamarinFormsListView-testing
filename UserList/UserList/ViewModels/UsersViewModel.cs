using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UserList.Models;
using Xamarin.Forms;

namespace UserList.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> DisplayUsers { get; set; }

        public Command SaveUserFromXML { get; private set; }
        public Command DeleteUserFromXAML { get; private set; }

        public UsersViewModel()
        {
            //Users = new User();
            SaveUserFromXML = new Command(SaveUser);
            DeleteUserFromXAML = new Command(DeleteUser);

            //Some data to display at start
            DisplayUsers = new ObservableCollection<User>();
            //User noweada = new User();
            //noweada.Name = "hi";
            //noweada.Surname = "hello";
            //DisplayUsers.Add(noweada);
            //User noweadaa = new User();
            //noweadaa.Name = "hihi";
            //noweadaa.Surname = "aaahellohello";
            //DisplayUsers.Add(noweadaa);

            //Order that data
            OrderedUsers = DisplayUsers.OrderBy(x => x.Surname).ToList();

        }
        //Ordered List for Users Collection - use in xaml
        private List<User> _OrderedUsers;
        public List<User> OrderedUsers
        {
            get { return _OrderedUsers; }
            set
            {
                _OrderedUsers = value;
                OnPropertyChanged();
            }
        }

        //Name and Surname for binding in xaml
        private string _Name;
        public string name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }

        }



        private string _Surname;
        public string surname
        {
            get { return _Surname; }
            set
            {
                _Surname = value;
                OnPropertyChanged();
            }

        }

        private string _FullName;
        public string fullname
        {
            get { return _FullName; }
            set
            {
                _FullName = value;
                OnPropertyChanged();
            }
        }

        // Connect Model and ViewModel
        private User _newUser;
        public User newUser
        {
            get { return _newUser; }
            set
            {
                _newUser = value;
                OnPropertyChanged();
            }
        }

        //Use of Command for feftching values from xaml
        public void SaveUser()
        {
            User addeduser = new User();
            addeduser.Name = name;
            addeduser.Surname = surname;
            DisplayUsers.Add(addeduser);
            //DisplayUsers = new ObservableCollection<User>();
            //OrderedUsers = new ObservableCollection<User>(DisplayUsers.OrderBy(x => x.Surname));
            OrderedUsers = DisplayUsers.OrderBy(x => x.Surname).ToList();
        }

        //Handle Delete User from the Ordered List
        private User _UsertoDelete;
        public User UsertoDelete
        {
            get { return _UsertoDelete; }
            set
            {
                _UsertoDelete = value;
                OnPropertyChanged();
            }
        }
        public void DeleteUser()
        {
            User rmvuser = DisplayUsers.FirstOrDefault(n => n.FullName == fullname);
            DisplayUsers.Remove(rmvuser);
            OrderedUsers = DisplayUsers.OrderBy(x => x.Surname).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Data for testing before interaction with View
        //public UsersViewModel()
        //{

        //    Users = new ObservableCollection<User>();
        //    //User newuser = new User();
        //    //newuser.UserId = 1;
        //    //newuser.Name = "Ilias";
        //    //newuser.Surname = "Papanikolaou";
        //    //User newuser2 = new User();
        //    //newuser2.UserId = 2;
        //    //newuser2.Name = "Elpiniki";
        //    //newuser2.Surname = "Papanik";
        //    //User newuser3 = new User();
        //    //newuser3.UserId = 3;
        //    //newuser3.Name = "Dimitrios";
        //    //newuser3.Surname = "Dimitriou";
        //    //User newuser4 = new User();
        //    //newuser4.UserId = 4;
        //    //newuser4.Name = "Makis";
        //    //newuser4.Surname = "Paidas";
        //    //User newuser5 = new User();
        //    //newuser5.UserId = 2;
        //    //newuser5.Name = "Testing";
        //    //newuser5.Surname = "Testing";
        //    ////Users.Add(new User
        //    ////{
        //    ////    UserId = 1,
        //    ////    Name = "Ilias",
        //    ////    Surname = "Papanikolaou"

        //    ////});
        //    //Users.Add(newuser);
        //    //Users.Add(newuser2);
        //    //Users.Add(newuser3);
        //    //Users.Add(newuser4);
        //    //Users.Add(newuser5);
        //    //Users = new ObservableCollection<User>(Users.OrderBy(x => x.Surname));
        //    OrderedUsers = new ObservableCollection<User>(Users.OrderBy(x => x.Surname));
        //    //Users.OrderBy(u => u.Surname);
        //    //var list = Users.OrderBy(x => x.Surname).ToList();
        //    //Users.OrderBy(t => t.Surname);
        //    //OrderedUsers = UserHelper.UsersGrouped;
        //    //var orderedUsers = Users.OrderBy(User => User.Surname);
        //    //List<User> orduser = orderedUsers.ToList();
        //    //OrderedUsers = new ObservableCollection<User>();


        //}
    }
}
