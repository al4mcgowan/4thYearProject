using System.Windows;
using Gm.Models;
using System.ComponentModel;
using System;

namespace GraveFinderApp
{
    class GraveViewModel : INotifyPropertyChanged
    {
        private Grave grave;

        public GraveViewModel(Grave grave)
        {
            this.grave = grave;
        }

        public string Cemetery
        {
            get
            {
                return grave.Cemetery;
            }
            set
            {
                if (value != grave.Cemetery)
                {
                    grave.Cemetery = value;
                    NotifyPropertyChanged("Cemetery");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
