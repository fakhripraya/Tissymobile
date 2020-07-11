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
    public class ArticleViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private const int PageSize = 10;
        readonly DataServices _dataService = new DataServices();

        public InfiniteScrollCollection<ArticleBindingModel> Items { get; }
        public List<ArticleBindingModel> CarouselElement { set; get; }

        ArticleBindingModel dummyArticle = new ArticleBindingModel()
        {
            ArticleId = 0,
            Title = "Apakah untuk prakter psikologi memerlukan lisensi?",
            AuthorId = 0,
            AuthorName = "Al Rhundi",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 0,
            Topic = "Psikologi Keras",
            ArticleContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            Thumbnail = "landscape1.jpeg",
            ViewNumber = 54,
            Replies = null
        };

        ArticleBindingModel dummyArticle1 = new ArticleBindingModel()
        {
            ArticleId = 1,
            Title = "Apa sih Skizofrenia itu",
            AuthorId = 1,
            AuthorName = "Al Qaeda",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 1,
            Topic = "Psikologi Keras",
            ArticleContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            Thumbnail = "landscape2.jpeg",
            ViewNumber = 103,
            Replies = null
        };

        ArticleBindingModel dummyArticle2 = new ArticleBindingModel()
        {
            ArticleId = 2,
            Title = "Bagaimana cara menangani anak pengidap autisme",
            AuthorId = 2,
            AuthorName = "Al Kafirun",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 2,
            Topic = "Psikologi Keras",
            ArticleContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            Thumbnail = "landscape3.jpg",
            ViewNumber = 199,
            Replies = null
        };

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ArticleViewModel()
        {
            Items = new InfiniteScrollCollection<ArticleBindingModel>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;

                    // load the next page
                    var page = Items.Count / PageSize;

                    var items = await _dataService.GetArticlesAsync(page, PageSize);

                    IsBusy = false;

                    // return the items that need to be added
                    return items;
                },
                OnCanLoadMore = () =>
                {
                    return Items.Count < 44;
                }
            };

            CarouselElement = new List<ArticleBindingModel>
            {
                dummyArticle,
                dummyArticle1,
                dummyArticle2
            };

            DownloadDataAsync();
        }

        private async Task DownloadDataAsync()
        {
            var items = await _dataService.GetArticlesAsync(pageIndex: 0, pageSize: PageSize);

            Items.AddRange(items);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
