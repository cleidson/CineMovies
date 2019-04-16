using CineMovies.Models;
using CineMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CineMovies.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private MoviesViewModel MoviesVmToBindContext => (BindingContext as MoviesViewModel);
        int page = 1;
        int countSearch = 1;

        public MoviesPage()
        {
            InitializeComponent();
            BindingContext = new MoviesViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await MoviesVmToBindContext.LoadListAsync();
        }

        private void Movies_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var item = (Movie)e.Item;
            if (item == null || MoviesVmToBindContext.IsRefreshing) { return; }
             
            if (item.CountItem == MoviesVmToBindContext.Movies.Count)
            {
                if (string.IsNullOrEmpty(searchMovie.Text))
                {
                    MoviesVmToBindContext.MoviesCommand.Execute(++page);
                }
                else
                {
                    MoviesVmToBindContext.SearchBarCommand.Execute(countSearch++);
                }
            } 
        }

        private void SearchMovie_TextChanged(object sender, TextChangedEventArgs e)
        {
            countSearch = (e.OldTextValue != e.NewTextValue) ? 1 : countSearch;

            if (e.NewTextValue.Length == 0)
            {
                page = 1;
                MoviesVmToBindContext.MoviesCommand.Execute(page);
            }
            else
            {
                MoviesVmToBindContext.SearchBarCommand.Execute(countSearch++);
            }
        }

        private void Movies_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (Movie)e.Item;
            if (item == null || MoviesVmToBindContext.IsBusy) { return; }
            MoviesVmToBindContext.MovieDetailsCommand.Execute(item);
        }
    }
}