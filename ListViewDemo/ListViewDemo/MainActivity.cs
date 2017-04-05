using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ListViewDemo
{
    [Activity(Label = "ListViewDemo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            EmployeeList employeeList = new EmployeeList();
            var employes = employeeList.GetEmployees(20);

            //atribui o controle de Listiew pelo Id
            ListView lvEmployess = FindViewById<ListView>(Resource.Id.lvEmployee);
            //adaptador para inserir os dados no listview
            //ArrayAdapter<Employee> adapter = new ArrayAdapter<Employee>(this, Android.Resource.Layout.SimpleListItem1, employes);
            //atribiu o adaptador na propriedade de adaptador do listview
            EmployeeAdapter adapter = new EmployeeAdapter(employes);
            lvEmployess.Adapter = adapter;
        }
    }
}

