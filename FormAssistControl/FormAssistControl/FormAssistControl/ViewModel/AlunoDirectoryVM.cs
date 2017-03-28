using FormAssistControl.Model.Entities;
using FormAssistControl.Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FormAssistControl.ViewModel
{
    class AlunoDirectoryVM : ObservableBaseObject
    {

        public ObservableCollection<Aluno> Alunos { get; set; }

        bool isBusy = false;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }

            set
            {
                isBusy = value;
                OnPropertyChenged();
            }
        }

        public Command LoadDirectoryComand { get; set; }

        public AlunoDirectoryVM()
        {
            Alunos = new ObservableCollection<Aluno>();
            isBusy = false;
            LoadDirectoryComand = new Command((obj) => LoadDirectory());
        }

        async void LoadDirectory()
        {
            if (!IsBusy)
            {
                IsBusy = true;

                await Task.Delay(3000);

                var loadDirectory = AlunoDirectoryService.CarregarAlunoDirectory();

                foreach (var alunos in loadDirectory.Alunos)
                {
                    Alunos.Add(alunos);
                }

                IsBusy = false;
            }
        }
    }
}
