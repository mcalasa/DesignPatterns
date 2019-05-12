using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TheHumbleDialogBox.Core.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private const string ERROR_MESSAGE_BAD_SSN = "Bad SSN.";
        private const string ERROR_MESSAGE_BAD_NAME = "Bad name.";

        private Person _person;

        public MainPageViewModel()
        {
            _person = new Person();
        }

        public string Name
        {
            get { return _person.Name; }
            set
            {
                _person.Name = value;
            }
        }

        public string Ssn
        {
            get { return _person.Ssn; }
            set
            {
                _person.Ssn = value;                
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged("ErrorMessage");
            }
        }

        public bool OnOk()
        {
            if (IsValidName() == false)
            {
                ErrorMessage = ERROR_MESSAGE_BAD_NAME;
                return false;
            }

            if (IsValidSSN() == false)
            {
                ErrorMessage = ERROR_MESSAGE_BAD_SSN;
                return false;
            }

            ErrorMessage = string.Empty;
            return true;
        }

        private bool IsValidName()
        {
            return Name.Length > 0;
        }

        private bool IsValidSSN()
        {
            string pattern = @"^\d{3}-\d{2}-\d{4}$";
            return Regex.IsMatch(Ssn, pattern);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public string Ssn { get; set; }

    }
}
