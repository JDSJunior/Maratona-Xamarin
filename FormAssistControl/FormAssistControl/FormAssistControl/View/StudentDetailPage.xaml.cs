using FormAssistControl.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FormAssistControl.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage(Aluno selectedStudent)
        {
            InitializeComponent();
            this.BindingContext = selectedStudent;
        }
    }
}
