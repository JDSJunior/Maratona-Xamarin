using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.IO;
using SQLite;

namespace appContabil
{
    [Activity(Label = "ResultCapital")]
    public class ResultCapital : Activity
    {
        double defautValue;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Result);
            EditText txtCapitalMex = FindViewById<EditText>
                (Resource.Id.txtResulMex);
            EditText txtCapitalCol = FindViewById<EditText>
                (Resource.Id.txtCapCol);
            ImageView imgCol = FindViewById<ImageView>
                (Resource.Id.imgCol);
            ImageView imgMex = FindViewById<ImageView>
                (Resource.Id.imgMex);
            Button btnSair = FindViewById<Button>
                (Resource.Id.btnSair);

            btnSair.Click += delegate
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            };

            try
            {
                txtCapitalMex.Text = Intent.GetDoubleExtra("CapitalMex", defautValue).ToString();
                txtCapitalCol.Text = Intent.GetDoubleExtra("CapitalCol", defautValue).ToString();
                imgMex.SetImageResource(Resource.Drawable.mexico);
                imgCol.SetImageResource(Resource.Drawable.Colombia);

                var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                path = Path.Combine(path, "Base.bd3");

                var conn = new SQLiteConnection(path);
                var elements = from s in conn.Table<Informacao>()
                               select s;

                foreach (var item in elements)
                {
                    Toast.MakeText(this, item.EntradaMexico.ToString(),
                        ToastLength.Short).Show();
                    Toast.MakeText(this, item.SaidaMexico.ToString(),
                        ToastLength.Short).Show();
                    Toast.MakeText(this, item.EntradaColombia.ToString(),
                        ToastLength.Short).Show();
                    Toast.MakeText(this, item.SaidaColombia.ToString(),
                        ToastLength.Short).Show();
                }

            }
            catch (Exception ex)
            {
                Toast.MakeText(
                    this, ex.Message,
                    ToastLength.Short).Show();
            }

        }
    }
}