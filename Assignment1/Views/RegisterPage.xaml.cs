using System;
using System.ComponentModel;
using System.IO;
using Assignment1.ViewModels;
using Plugin.FilePicker;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Assignment1.Views
{
    public partial class AboutPage : ContentPage
    {
        AboutViewModel viewModel;

        public AboutPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AboutViewModel();
        }

       async void TapGestureRecognizer_Tapped(System.Object sender, System.EventArgs e)
        {

            var file = await CrossFilePicker.Current.PickFile();

            if (file != null)
            {
                viewModel.ImageName = file.FileName;
                byte[] imgFile= file.DataArray;
                if (imgFile != null)
                {
                    viewModel.ImageData = imgFile;

                    Stream stream = new MemoryStream(imgFile);
                    var imageSource = ImageSource.FromStream(() => stream);
                  //  Image_Profile.Source = imageSource;
                }
                
            }
        }

        void Button_Cancel_Clicked(System.Object sender, System.EventArgs e)
        {
            viewModel.ResetData();
        }

        void Button_save_Clicked(System.Object sender, System.EventArgs e)
        {
            viewModel.AddToDataBase();
        }

       async void Button_AlreadyRegistered_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }
    }
}