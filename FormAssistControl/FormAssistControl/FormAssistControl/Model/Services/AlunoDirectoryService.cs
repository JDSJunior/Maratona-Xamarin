using FormAssistControl.Model.Entities;
using FormAssistControl.Storage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormAssistControl.Model.Services
{
    public class AlunoDirectoryService
    {
        //metodo que popula a classe model com dados
        public static AlunoDirectory CarregarAlunoDirectory()
        {
            DatabaseManager dbManager = new DatabaseManager();
            ObservableCollection<Aluno> alunos = new ObservableCollection<Aluno>(dbManager.GetAllItems<Aluno>());
            AlunoDirectory alunodirectory = new AlunoDirectory();

            if (alunos.Any())
            {
                alunodirectory.Alunos = alunos;
                return alunodirectory;
            }

            alunos = new ObservableCollection<Aluno>();

            string[] nome = { "José Luis", "Miguel Angel", "José Francisco", "Jesus Antonio", "Sofia", "Camila", "Valentina", "Isabella", "Ximena" };
            string[] sobrenome = {"Hernandez", "Garcia", "Martinez", "Lopez", "Gonzalez"};

            Random rdn = new Random(DateTime.Now.Millisecond);

            alunos = new ObservableCollection<Aluno>();

            for (int i = 0; i < 20; i++)
            {
                Aluno aluno = new Aluno();
                aluno.Name = nome[rdn.Next(0, 8)];
                aluno.Sobrenome = $"{sobrenome[rdn.Next(0, 5)]} {sobrenome[rdn.Next(0, 5)]}";
                string turma = rdn.Next(456, 458).ToString();
                aluno.Turma = turma;
                aluno.Matricula = rdn.Next(12384748, 32384748).ToString();
                aluno.Media = rdn.Next(100, 1000) / 10;
                aluno.Key = aluno.Matricula;
                alunos.Add(aluno);
                dbManager.SaveValue<Aluno>(aluno);

            }

            alunodirectory.Alunos = alunos;
            return alunodirectory;
        }
    }
}
