using EsrivaMobile.Views;
using EsrivaMobile.Views.PushPopViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsrivaMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
            Shell.SetNavBarIsVisible(this, false);
        }

        Dictionary<string, Type> routes = new Dictionary<string, Type>();

        public ICommand NavigateCommand => new Command(Navigate);
        public ICommand FeedbackCommand
            => new Command(async () => await PushPage(new FeedbackPage()));
        public ICommand SettingPscCommand
            => new Command(async () => await PushPage(new SettingsPscPage()));
        public ICommand SettingUserCommand
            => new Command(async () => await PushPage(new SettingUserPage()));
        public ICommand HomeMessagesCommand
            => new Command(async () => await PushPage(new HomeMessagesPage()));
        public ICommand PActivityCommand
            => new Command(async () => await PushPage(new PActivityPage()));
        public ICommand ReportCommand
            => new Command(async () => await PushPage(new ReportPage()));
        public ICommand HelpCommand
            => new Command(async () => await PushPage(new HelpPage()));
        public ICommand AboutCommand
            => new Command(async () => await PushPage(new AboutPage()));

        private async Task PushPage(Page page)
        {
            await Shell.Current.Navigation.PushAsync(page);
            Shell.Current.FlyoutIsPresented = false;
        }

        private async void Navigate(object route)
        {
            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"{state.Location}/{route.ToString()}");
            Shell.Current.FlyoutIsPresented = false;
        }

        void RegisterRoutes()
        {
            routes.Add("register", typeof(RegistrationPage));
            routes.Add("login", typeof(LoginPage));
            routes.Add("friends", typeof(FriendsPage));
            routes.Add("forum", typeof(ForumPage));
            routes.Add("notification", typeof(NotificationPage));
            routes.Add("artikel", typeof(ArticlePage));
            routes.Add("profile", typeof(ProfilePage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }
    }
}