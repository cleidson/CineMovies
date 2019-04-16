using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CineMovies.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
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

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }

        public async Task PushAsync<TViewModel>(params object[] args) where TViewModel : BaseViewModel
        {
            var viewModelType = typeof(TViewModel);
            var viewModelTypeName = viewModelType.Name;
            var viewTypeName = $"CineMovies.Views.{viewModelTypeName.Substring(0, viewModelTypeName.Length - 9)}Page";
            var viewType = Type.GetType(viewTypeName);

            var page = Activator.CreateInstance(viewType) as Page; 


            var viewModel = Activator.CreateInstance(viewModelType, args);
            if (page != null)
            {
                page.BindingContext = viewModel;
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        public Task PopAsync()
        {
            return Application.Current.MainPage.Navigation.PopAsync();
        }
     
        public async Task DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, cancel);
        }

        public async Task DisplayAlert(string title, string message, string accept, string cancel)
        {
            await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
        }


    }
}
