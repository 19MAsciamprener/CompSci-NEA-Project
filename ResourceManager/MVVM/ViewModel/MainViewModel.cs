using ResourceManager.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceManager.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {

        public HomeViewModel HomeVM { get; set; }

        private object _CurrentView;

        public object CurrentView
        {
            get { return _CurrentView; }
            set
            { 
                _CurrentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel() 
        { 
            HomeVM = new HomeViewModel();
            CurrentView = HomeVM;
        }
    }
}
