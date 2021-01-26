using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Assignment1.Models;
using Assignment1.ViewModels;

namespace Assignment1.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }
        RegisteredUserListPageViewModel viewModel;
        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new RegisteredUserListPageViewModel();

            Item = new Item
            {
                Text = "Item name",
                Description = "This is an item description."
            };

         
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.GetRegisteredUserList();
        }
    }
}