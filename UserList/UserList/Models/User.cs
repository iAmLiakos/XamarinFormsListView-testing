using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace UserList.Models
{
    public class User : INotifyPropertyChanged
    {
        //Fields and Properties Name, Surname, FullName

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged();
            }
        }

        private string _Surname;
        public string Surname
        {
            get { return _Surname; }

            set
            {
                _Surname = value;
                OnPropertyChanged();
            }

        }

        //Data to display at the list and delete item from list
        public string FullName
        {
            get
            {
                string fullname = Surname + " " + Name;
                return fullname;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



    }
}
