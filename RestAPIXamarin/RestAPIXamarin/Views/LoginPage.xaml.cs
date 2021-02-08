using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIXamarin.Models;
using RestAPIXamarin.Views.Menu;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RestAPIXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            Init();
        }

        void Init(){
            BackgroundColor = Constants.BackgroundColor;
            labelUsername.TextColor = Constants.MainTextColor;
            labelPassword.TextColor = Constants.MainTextColor;
            ActivitySpinner.IsVisible = false;
            LoginIcon.HeightRequest = Constants.LoginIconHeight;
            App.StartCheckIfInternet(labelNoInternet, this);

            inputUsername.Completed += (s, e) => inputPassword.Focus();
            inputPassword.Completed += (s, e) => SignInAsync(s, e);
        }

        async void SignInAsync(object sender, EventArgs e){
            User user = new User(inputUsername.Text, inputPassword.Text);
            if (user.CheckIfUserInputs()){
                await DisplayAlert("Login", "Login Sucess", "Ok!");
                //var result = await App.RestServices.Login(user);
                var result = new Token();
                //if (result.accessToken != null)
                if (result != null){
                    //App.UserDatabase.SaveUser(user);
                    //App.TokenDatabase.SaveToken(result);
                    if(Device.OS == TargetPlatform.Android){
                        Application.Current.MainPage = new NavigationPage(new MasterDetail());
                    } else if(Device.OS == TargetPlatform.iOS){
                        await Navigation.PushModalAsync(new NavigationPage(new MasterDetail()));
                    }
                }
            }else{
                await DisplayAlert("Login", "Error On Login, empty username or password.", "Ok!");
            }
        }


    }
}