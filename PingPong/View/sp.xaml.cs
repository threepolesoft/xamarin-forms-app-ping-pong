using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PingPong.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class sp : ContentPage
    {
        public sp()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await image.TranslateTo(0, 50, 300);
            await image.TranslateTo(0, -100, 400);
            await image.TranslateTo(0, 50, 300);


            await image.RotateYTo(30, 200, Easing.CubicIn);
            await image.RotateYTo(60, 200, Easing.CubicIn);
            await image.RotateYTo(30, 200, Easing.CubicIn);


           Application.Current.MainPage = new NavigationPage(new Home());
        }
    }
}