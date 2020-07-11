using EsrivaMobile.Models;
using EsrivaMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using EsrivaMobile.Data;
using Xamarin.Forms.Extended;

namespace EsrivaMobile.ViewModels
{
    public class FriendsViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private const int PageSize = 10;
        readonly DataServices _dataService = new DataServices();

        public InfiniteScrollCollection<FriendsBindingModel> Items { get; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public FriendsViewModel()
        {
            Items = new InfiniteScrollCollection<FriendsBindingModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // load the next page
                    var page = Items.Count / PageSize;

                    var items = await _dataService.GetFriendsAsync(page, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                },
                OnCanLoadMore = () =>
                {
                    return Items.Count < 44;
                }
            };

            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            var items = await _dataService.GetFriendsAsync(pageIndex: 0, pageSize: PageSize);

            Items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
