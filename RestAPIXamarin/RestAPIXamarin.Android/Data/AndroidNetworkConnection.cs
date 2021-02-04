using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using RestAPIXamarin.Data;
using Android.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestAPIXamarin.Droid.Data;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidNetworkConnection))]

namespace RestAPIXamarin.Droid.Data
{
    public class AndroidNetworkConnection : INetworkConnection{
        public bool isConnected { get; set; }

        public void CheckNetworkConnection(){
            var connectivityManager = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            var ActiveNetworkInfo = connectivityManager.ActiveNetworkInfo;
            //if(ActiveNetworkInfo == null && ActiveNetworkInfo.IsConnectedOrConnecting)
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M){
                if (!(ActiveNetworkInfo != null)){
                    isConnected = true;
                }
                else{
                    isConnected = false;
                }
            }
                
        }
    }
}