using System;
using System.Collections.Generic;
using System.Text;

namespace EsrivaMobile.ViewModels.Base
{
    public class BaseViewModel : ObservableObject
    {
        public BaseViewModel()
        {

        }

        private bool _isBusy = false;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}
