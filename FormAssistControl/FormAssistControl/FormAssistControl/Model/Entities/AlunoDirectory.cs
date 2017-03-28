using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAssistControl.Model.Entities
{
    public class AlunoDirectory : ObservableBaseObject
    {
        //metodo que instancia a classe aluno, insere e obtem os dados
        private ObservableCollection<Aluno> alunos = new ObservableCollection<Aluno>();

        public ObservableCollection<Aluno> Alunos
        {
            get
            {
                return alunos;
            }

            set
            {
                alunos = value;
                OnPropertyChenged();
            }
        }
    }
}
