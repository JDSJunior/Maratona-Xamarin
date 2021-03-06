﻿using Android.App;
using Android.Widget;
using Android.OS;

namespace HelloXamarin.Android
{
    [Activity(Label = "HelloXamarin.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int cuont = 0;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button button = FindViewById<Button>(Resource.Id.button1);
            button.Click += delegate { button.Text = string.Format("{0} clicks!", cuont++); };

        }
        
        
    }
}

