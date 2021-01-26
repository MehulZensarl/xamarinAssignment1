using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using Assignment1.Models;
using Assignment1.Views;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Assignment1.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        private ObservableCollection<Article> _ArticleList;
        public ObservableCollection<Article> ArticleList
        {
            get
            {
                return _ArticleList;
            }
            set
            {

                _ArticleList = value;
                OnPropertyChanged("ArticleList");
            }
        }

public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            ArticleList = new ObservableCollection<Article>();
               Title = "Browse";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void GetListDAta()
        {
           await Task.Run(()=>  IsBusy = true);
            string Json = await MakeGetAPICall();
            string newJson = Json;
            if (!string.IsNullOrEmpty(Json))
            {try
                {

                    NewsResponseModel NewsResponseModel = JsonConvert.DeserializeObject<NewsResponseModel>(Json);
                    if (NewsResponseModel != null)
                    {
                        ArticleList = new ObservableCollection<Article>(NewsResponseModel.articles);
                    }
                }
                catch
                {

                }
            }


            await Task.Run(() => IsBusy = false);
        }

        public  async Task<string> MakeGetAPICall()
        {
            try
            {
                HttpClientHandler crmSignUphttpClientHandler = new HttpClientHandler();
                crmSignUphttpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(crmSignUphttpClientHandler);
                string date = DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd");
                string URL = "http://newsapi.org/v2/everything?q=bitcoin&from="+ date + "&sortBy=publishedAt&apiKey=10d50e05da8e4acfb3278d005d6f2686";
                var uri = new Uri(URL);
                HttpResponseMessage response = await client.GetAsync(uri);
                String responseString = response.Content.ReadAsStringAsync().Result;
                return responseString;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}