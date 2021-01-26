using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Akavache;
using Assignment1.Models;

namespace Assignment1.ViewModels
{
    public class RegisteredUserListPageViewModel : BaseViewModel
    {
        private ObservableCollection<UserModel> _UserList;
        public ObservableCollection<UserModel> UserList
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
        public RegisteredUserListPageViewModel()
        {
            UserList = new ObservableCollection<UserModel>();
        }


        public async void GetRegisteredUserList()
        {

            try
            {

                UserList = new ObservableCollection<UserModel>((List<UserModel>)await BlobCache.LocalMachine.GetAllObjects<UserModel>()); 
            }
            catch (KeyNotFoundException)
            {
                UserList = null;
            }
        }
    }
}
