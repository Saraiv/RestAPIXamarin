using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using RestAPIXamarin.Views;
using RestAPIXamarin.Data;
using RestAPIXamarin.Models;
using System.Threading;
using System.Threading.Tasks;

namespace RestAPIXamarin
{
    public partial class App : Application
    {
        static TokenDatabaseController tokenDatabase;
        static UserDatabaseController userDatabase;
        static RestServices restServices;
        private static Label labelScreen;
        private static bool hasInternet;
        private static Page currentPage;
        private static Timer timer;
        private static bool noInterShow;

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public static UserDatabaseController UserDatabase{
            get{
                if(userDatabase == null){
                    userDatabase = new UserDatabaseController();
                }

                return userDatabase;
            }
        }

        public static TokenDatabaseController TokenDatabase
        {
            get{
                if (tokenDatabase == null){
                    tokenDatabase = new TokenDatabaseController();
                }

                return tokenDatabase;
            }
        }

        public static RestServices RestServices{
            get{
                if(restServices == null){
                    restServices = new RestServices();
                }
                return restServices;
            }
        }

        public static void StartCheckIfInternet(Label label, Page page){
            labelScreen = label;
            label.Text = Constants.noInternetText;
            label.IsVisible = false;
            hasInternet = true;
            currentPage = page;

            if(timer == null){
                timer = new Timer((e) =>
                {
                    CheckIfInternetOverTime();
                }, null, 10, (int)TimeSpan.FromSeconds(3).TotalMilliseconds);
            }
        }

        private static void CheckIfInternetOverTime(){
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (networkConnection.isConnected){
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (hasInternet)
                    {
                        if (!noInterShow)
                        {
                            hasInternet = false;
                            labelScreen.IsVisible = true;
                            await ShowDisplayAlert();
                        }
                    }
                });
            } else{
                Device.BeginInvokeOnMainThread(() =>
                {
                    hasInternet = false;
                    labelScreen.IsVisible = false;
                });
            }

        }

        public static async Task<bool> CheckIfInternet(){
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            return networkConnection.isConnected;
        }

        public static async Task<bool> CheckIfInternetAlert(){
            var networkConnection = DependencyService.Get<INetworkConnection>();
            networkConnection.CheckNetworkConnection();
            if (!networkConnection.isConnected){
                if (!noInterShow){
                    await ShowDisplayAlert();
                }
                return false;
            }
            return true;
        }

        private static async Task ShowDisplayAlert(){
            noInterShow = false;
            await currentPage.DisplayAlert("Internet", "Device has no internet, please reconnect!", "Ok!");
            noInterShow = false;
        }
    }
}
