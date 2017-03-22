using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ConversaoMoeda
{
    [Activity(Label = "ConversaoMoeda", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            Button btnConverter = FindViewById<Button>
                (Resource.Id.btnconverter);
            EditText txtDolares = FindViewById<EditText>
                (Resource.Id.txtdolares);
            EditText txtPesos = FindViewById<EditText>
                (Resource.Id.txtpesos);

            double pesos, dolares;
            btnConverter.Click += delegate
            {
                try
                {
                    dolares = double.Parse(txtDolares.Text);
                    pesos = dolares * 19.5;
                    txtPesos.Text = pesos.ToString();
                }
                catch (System.Exception ex)
                {
                    Toast.MakeText
                    (this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
    }
}

