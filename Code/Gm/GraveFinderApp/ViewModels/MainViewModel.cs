using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Collections.ObjectModel;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Gm.Models;

namespace GraveFinderApp
{
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<GraveViewModel>();
        }

        public ObservableCollection<GraveViewModel> Items { get; private set; }
        private string _sampleProperty = "Sample Runtime Property Value";

        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }
    }
}
