using FormAssistControl.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAssistControl.Model.Entities
{
    //modelo de dados
    public class Aluno : ObservableBaseObject, IKeyObject
    {
        private string name;
        private string sobrenome;
        private string turma;
        private string matricula;
        private double media;

        public string Key { get; set; }


        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChenged();
            }
        }

        public string Sobrenome
        {
            get
            {
                return sobrenome;
            }

            set
            {
                sobrenome = value;
                OnPropertyChenged();
            }
        }

        public string Turma
        {
            get
            {
                return turma;
            }

            set
            {
                turma = value;
                OnPropertyChenged();
            }
        }

        public string Matricula
        {
            get
            {
                return matricula;
            }

            set
            {
                matricula = value;
                OnPropertyChenged();
            }
        }

        public double Media
        {
            get
            {
                return media;
            }

            set
            {
                media = value;
                OnPropertyChenged();
            }
        }

    }
}
