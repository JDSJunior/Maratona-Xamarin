using System;
using FormAssistControl.ViewModel;
using Xamarin.Forms;
using FormAssistControl.Model.Entities;
using FormAssistControl.View;

namespace FormAssistControl
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new AlunoDirectoryVM();
            lvAlunos.ItemSelected += lvAlunos_ItemSelected;
        }

        private void lvAlunos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Aluno selectedAluno = (Aluno)e.SelectedItem;
            if(selectedAluno == null)
            {
                return;
            }
            else
            {
                Navigation.PushAsync(new StudentDetailPage(selectedAluno));
                lvAlunos.SelectedItem = null;
            }
        }
    }
}
