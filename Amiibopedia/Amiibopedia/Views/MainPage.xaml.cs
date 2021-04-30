using System;
using System.Threading.Tasks;
using Amiibopedia.ViewModels;
using Xamarin.Forms;

namespace Amiibopedia.Views
{
    public partial class MainPage : ContentPage
    {
        private MainPageViewModel _vm;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _vm = new MainPageViewModel();
            await _vm.LoadCharactersAsync();

            BindingContext = _vm;
        }

        private async void Cell_OnAppearing(object sender, EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;

            view.TranslationX = -100;
            view.Opacity = 0;

            await Task.WhenAny<bool>
            (
                view.TranslateTo(0, 0, 250, Easing.SinIn),
                view.FadeTo(1, 500, Easing.BounceIn)
            );
        }
    }
}
