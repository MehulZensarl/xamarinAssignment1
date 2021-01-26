using System;

using Assignment1.Models;

namespace Assignment1.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        private string _Uri;
        public string Uri {
            get {
                return
                _Uri;
            }
            set
            {
                _Uri = value;
                OnPropertyChanged("Uri");

            } }

        public ItemDetailViewModel(string url)
        {
            Uri = url;
        }
    }
}
