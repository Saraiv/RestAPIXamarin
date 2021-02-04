using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestAPIXamarin.Models;
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
            inputPassword.Completed += (s, e) => SignIn(s, e);
        }

        void SignIn(object sender, EventArgs e){
            User user = new User(inputUsername.Text, inputPassword.Text);
            if (user.CheckIfUserInputs()){
                DisplayAlert("Login", "Login Sucess", "Ok!");
                var result = App.RestServices.Login(user);
                if (result != null){
                    App.UserDatabase.SaveUser(user);
                }
            }else{
                DisplayAlert("Login", "Error On Login, empty username or password.", "Ok!");
            }
        }


    }
}