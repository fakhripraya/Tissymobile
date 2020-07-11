using EsrivaMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsrivaMobile.Data
{
    public class DataServices
    {
        public List<ForumBindingModel> _forums = new List<ForumBindingModel>();
        public List<ArticleBindingModel> _articles = new List<ArticleBindingModel>();
        public List<FriendsBindingModel> _friends = new List<FriendsBindingModel>();
        public List<NotificationBindingModel> _notifs = new List<NotificationBindingModel>();

        ForumBindingModel dummyForum = new ForumBindingModel()
        {
            ForumId = 0,
            Title = "Apakah untuk prakter psikologi memerlukan lisensi?",
            AuthorId = 0,
            AuthorName = "Al Rhundi",
            ProfilePicSrc = "ProfilePic.jpg",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 0,
            Topic = "Psikologi Keras",
            ForumContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            ViewNumber = 54,
            Replies = null
        };

        ForumBindingModel dummyForum1 = new ForumBindingModel()
        {
            ForumId = 1,
            Title = "Apa sih Skizofrenia itu",
            AuthorId = 1,
            AuthorName = "Al Qaeda",
            ProfilePicSrc = "ProfilePic2.jpg",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 1,
            Topic = "Psikologi Keras",
            ForumContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            ViewNumber = 103,
            Replies = null
        };

        ForumBindingModel dummyForum2 = new ForumBindingModel()
        {
            ForumId = 2,
            Title = "Bagaimana cara menangani anak pengidap autisme",
            AuthorId = 2,
            AuthorName = "Al Kafirun",
            ProfilePicSrc = "ProfilePic3.jpg",
            PostDate = Convert.ToDateTime("01/01/2010"),
            TopicId = 2,
            Topic = "Psikologi Keras",
            ForumContent = "Lorem Ipsum Dolor sit amet",
            Attatchment = "",
            ViewNumber = 199,
            Replies = null
        };

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

        FriendsBindingModel dummyFriend = new FriendsBindingModel()
        {
            FriendId = 0,
            UserId = 0,
            FriendName = "Udin",
            ProfilePicSrc = "ProfilePic.jpg",

        };

        FriendsBindingModel dummyFriend1 = new FriendsBindingModel()
        {
            FriendId = 1,
            UserId = 0,
            FriendName = "Mamad",
            ProfilePicSrc = "ProfilePic2.jpg",
        };

        FriendsBindingModel dummyFriend2 = new FriendsBindingModel()
        {
            FriendId = 2,
            UserId = 0,
            FriendName = "Soleh",
            ProfilePicSrc = "ProfilePic3.jpg",
        };

        NotificationBindingModel dummyNotif = new NotificationBindingModel()
        {
            NotificationId = 0,
            UserId = 0,
            TypeId = 0,
            Title = "Request Pertemanan",
            Content = "Mamad melakuka request pertemanan dengan anda , terima?",
            Thumbnail = "ProfilePic2.jpg"

        };

        NotificationBindingModel dummyNotif1 = new NotificationBindingModel()
        {
            NotificationId = 0,
            UserId = 0,
            TypeId = 1,
            Title = "Udin baru saja membuat Forum baru",
            Content = "Udin baru saja membuat Forum baru berjudul Bagaimana cara menangani anak pengidap autisme",
            Thumbnail = "ProfilePic.jpg"
        };

        NotificationBindingModel dummyNotif2 = new NotificationBindingModel()
        {
            NotificationId = 0,
            UserId = 0,
            TypeId = 2,
            Title = "Udin baru saja membuat Artikel baru",
            Content = "Udin baru saja membuat Artikel baru berjudul Apa sih Skizofrenia itu",
            Thumbnail = "ProfilePic.jpg"
        };

        public async Task<List<ForumBindingModel>> GetForumsAsync(int pageIndex, int pageSize)
        {
            for (int i = 0; i < 43; i++)
            {
                _forums.Add(dummyForum);
                _forums.Add(dummyForum1);
                _forums.Add(dummyForum2);
            }

            await Task.Delay(3000);

            return _forums.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<ArticleBindingModel>> GetArticlesAsync(int pageIndex, int pageSize)
        {
            for (int i = 0; i < 43; i++)
            {
                _articles.Add(dummyArticle);
                _articles.Add(dummyArticle1);
                _articles.Add(dummyArticle2);
            }

            await Task.Delay(3000);

            return _articles.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<FriendsBindingModel>> GetFriendsAsync(int pageIndex, int pageSize)
        {
            for (int i = 0; i < 43; i++)
            {
                _friends.Add(dummyFriend);
                _friends.Add(dummyFriend1);
                _friends.Add(dummyFriend2);
            }

            await Task.Delay(0);

            return _friends.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<NotificationBindingModel>> GetNotificationAsync(int pageIndex, int pageSize)
        {
            for (int i = 0; i < 43; i++)
            {
                _notifs.Add(dummyNotif);
                _notifs.Add(dummyNotif1);
                _notifs.Add(dummyNotif2);
            }

            await Task.Delay(0);

            return _notifs.Skip(pageIndex * pageSize).Take(pageSize).ToList();
        }
    }
}
