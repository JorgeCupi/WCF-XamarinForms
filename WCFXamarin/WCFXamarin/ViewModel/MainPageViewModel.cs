using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFXamarin.Model;

namespace WCFXamarin.ViewModel
{
    class MainPageViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


        private Result _result;
        public Result result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged("result");
            }
        }


        private string _myVar;
        public string myProp
        {
            get { return _myVar; }
            set
            {
                _myVar = value;
                OnPropertyChanged("myProp");
            }
        }

        public MainPageViewModel()
        {
            result = new Result();
            callWCF();
        }

        private void callWCF()
        {
            var wcfModel = new ServiceReference1.Service1Client();
            var wcfViewModel = new ServiceReference1.Service1Client();

            wcfModel.GetDataCompleted += WcfModel_GetDataCompleted; // Receive feedback asynchronously
            wcfViewModel.GetDataCompleted += WcfViewModel_GetDataCompleted;

            wcfModel.GetDataAsync("Model"); // Send request asynchronously
            wcfViewModel.GetDataAsync("ViewModel");
        }

        private void WcfViewModel_GetDataCompleted(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            myProp = e.Result;
        }

        private void WcfModel_GetDataCompleted(object sender, ServiceReference1.GetDataCompletedEventArgs e)
        {
            result.message = e.Result;
        }
    }
}
