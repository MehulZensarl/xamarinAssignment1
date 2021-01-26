using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Windows.Input;
using Akavache;
using Assignment1.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Assignment1.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private UserModel _User;
        public UserModel User
        {
            get
            {
                return _User;
            }
            set
            {

                _User = value;
                OnPropertyChanged("User");
            }
        }
        private List<UserModel> _UserList;
        public List<UserModel> UserList
        {
            get
            {
                return _UserList;
            }
            set
            {

                _UserList = value;
                OnPropertyChanged("UserList");
            }
        }
        private string _Name = string.Empty;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {

                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        private string _Designation= string.Empty;
        public string Designation
        {
            get
            {
                return _Designation;
            }
            set
            {

                _Designation = value;
                OnPropertyChanged("Designation");
            }
        }
        private string _Email=string.Empty;
        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {

                _Email = value;
                OnPropertyChanged("Email");
            }
        }
        private string _MobNumber=string.Empty;
        public string MobNumber
        {
            get
            {
                return _MobNumber;
            }
            set
            {

                _MobNumber = value;
                OnPropertyChanged("MobNumber");
            }
        }

        private byte[] _ImageData =new byte[0];
        public byte[] ImageData
        {
            get
            {
                return _ImageData;
            }
            set
            {

                _ImageData = value;
                OnPropertyChanged("ImageData");
            }
        }
        private string _ImageName =string.Empty;
        public string ImageName
        {
            get
            {
                return _ImageName;
            }
            set
            {

                _ImageName = value;
                OnPropertyChanged("ImageName");
            }
        }

        private string _ProfileImg = string.Empty;
        public string ProfileImg
        {
            get
            {
                return _ProfileImg;
            }
            set
            {

                _ProfileImg = value;
                OnPropertyChanged("ProfileImg");
            }
        }
        public ICommand OpenWebCommand { get; }
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://xamarin.com"));
            
        }



        public void ResetData()
        {
            Name = string.Empty;
            Designation = string.Empty;
            Email = string.Empty;
            MobNumber = string.Empty;
            ProfileImg = string.Empty;
            ImageName = string.Empty;
        }

        public async  void AddToDataBase()
        {try
            {
                UserList = new List<UserModel>();
                User = new UserModel();
                User.name = Name;
                User.designation = Designation;
                User.email = Email;
                User.mobnumber = MobNumber;
                User.profileImage = ImageData;

                await BlobCache.LocalMachine.InsertObject<UserModel>(
                    User.name + User.id,
                    User,
                    DateTimeOffset.Now.AddHours(2));
                await Application.Current.MainPage.DisplayAlert("Success", "User registered successfully", "Ok");
                ResetData();

            }
            catch
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error in adding user", "Ok");
            }
        }

    
    }
}