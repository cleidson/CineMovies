using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CineMovies.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool _busy;
        public bool Busy
        {
            get { return _busy; }
            set { SetProperty(ref _busy, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private bool _loading;
        public bool Loading
        {
            get { return _loading; }
            set { SetProperty(ref _loading, value); }
        }

        public BaseViewModel(string title)
        {
            Title = title;
        }

        protected void OnPropertyChanged([CallerMemberName] string PropertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PropertyName)));

         
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
