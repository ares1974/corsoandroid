using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;

namespace WorkshopPomeriggio.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;
        private bool _isLoading;

        private double chargingLevel = Battery.ChargeLevel;
        private BatteryState batteryState=Battery.State;


        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Title
        {
            get { return _title; }
            set { 
                if(_title == value) return;
                _title = value;
                OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                if (_isLoading == value) return;
                _isLoading = value;
                OnPropertyChanged();
                OnPropertyChanged("IsNotLoading");
            }
        }

        public bool IsNotLoading => !_isLoading;


        public double ChargingLevel
        {
            get { return chargingLevel; }
            set
            {
                if (chargingLevel == value) return;
                chargingLevel = value;
                OnPropertyChanged();
            }
        }

        public BatteryState BatteryState
        {
            get { return batteryState; }
            set
            {
                if (batteryState == value) return;
                batteryState = value;
                OnPropertyChanged();
            }
        }

    }
}
