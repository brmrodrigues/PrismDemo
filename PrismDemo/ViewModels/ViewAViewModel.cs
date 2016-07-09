using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PrismDemo.ViewModels
{
    class ViewAViewModel : BindableBase
    {
        private string _firstName = "huehue";

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                //(1)UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                //(1)UpdateCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime? _lastUpdated;

        public DateTime? LastUpdated
        {
            get { return _lastUpdated; }
            set
            {
                SetProperty(ref _lastUpdated, value);
            }
        }

        public DelegateCommand UpdateCommand { get; set; }

        public ViewAViewModel()
        {
            UpdateCommand = new DelegateCommand(Execute, CanExecute).ObservesProperty(() => FirstName).ObservesProperty(() => LastName);
            //Útil quando houver muitas Properties e ter que usar (1) em todas elas
        }

        private bool CanExecute()
        {
            return !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
        }





        //private string _firstName;

        //public string FirstName
        //{
        //    get { return _firstName; }
        //    set
        //    {
        //        _firstName = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //void OnPropertyChanged([CallerMemberName] string propertyName = "")
        //{
        //    //Para ambiente MultiThread, para lidar em caso de PropertyChanged seja null
        //    var handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
    }
}
