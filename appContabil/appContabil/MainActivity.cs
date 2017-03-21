using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace appContabil
{
    [Activity(Label = "appContabil", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        double txtEntradaMex, txtEntradaCol, txtSaidaMex, txtSaidaCol, capitalMex, capitalCol;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //caminho do banco de dados
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //cria o arquivo de bd
            path = Path.Combine(path, "Base.db3");
            var conn = new SQLiteConnection(path);
            //cria a tabela no bd

            conn.CreateTable<Informacao>();

            Button btnCalcular = FindViewById<Button>
                (Resource.Id.btnCalc);

            EditText txtEntMex = FindViewById<EditText>
                (Resource.Id.txtEntMex);

            EditText txtSaiMex = FindViewById<EditText>
                (Resource.Id.txtSaidaMex);

            EditText txtEntCol = FindViewById<EditText>
                (Resource.Id.txtEntCol);

            EditText txtSaiCol = FindViewById<EditText>
                (Resource.Id.txtSaiCol);

            

            btnCalcular.Click += delegate
            {

                try
                {
                    txtEntradaMex = double.Parse(txtEntMex.Text);
                    txtEntradaCol = double.Parse(txtEntCol.Text);
                    txtSaidaMex = double.Parse(txtSaiMex.Text);
                    txtSaidaCol = double.Parse(txtSaiCol.Text);
                    capitalCol = txtEntradaCol - txtSaidaCol;
                    capitalMex = txtEntradaMex - txtSaidaMex;

                    //variavel d tipo da classe informacao que recebe so dados
                    var Inserir = new Informacao();
                    Inserir.EntradaColombia = txtEntradaCol;
                    Inserir.SaidaColombia = txtSaidaCol;
                    Inserir.EntradaMexico = txtEntradaMex;
                    Inserir.SaidaMexico = txtSaidaMex;
                    //inser a classe na tabela
                    conn.Insert(Inserir);

                    Toast.MakeText(this, "Salvando no Sqlite", ToastLength.Long).Show();

                    Carregar();

                }
                catch (System.Exception ex)
                {
                    Toast.MakeText
                    (this, ex.Message, ToastLength.Short).Show();
                }
            };
        }
        public void Carregar()
        {
            Intent objIntent = new Intent(this,
                typeof(ResultCapital));
            objIntent.PutExtra("CapitalMex", capitalMex);
            objIntent.PutExtra("CapitalCol", capitalCol);
            StartActivity(objIntent);
        }
    }

    //classe que servira de modelo para a tabela no bd
    public class Informacao
    {
        private double entradaMexico;
        private double saidaMexico;
        private double entradaColombia;
        private double saidaColombia;

        public double EntradaMexico
        {
            get
            {
                return entradaMexico;
            }

            set
            {
                entradaMexico = value;
            }
        }

        public double SaidaMexico
        {
            get
            {
                return saidaMexico;
            }

            set
            {
                saidaMexico = value;
            }
        }

        public double EntradaColombia
        {
            get
            {
                return entradaColombia;
            }

            set
            {
                entradaColombia = value;
            }
        }

        public double SaidaColombia
        {
            get
            {
                return saidaColombia;
            }

            set
            {
                saidaColombia = value;
            }
        }
    }
}

