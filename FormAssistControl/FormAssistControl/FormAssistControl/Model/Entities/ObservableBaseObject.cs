using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FormAssistControl.Model.Entities
{
    //classe que implementa a interface INotifyPropertyChanged
    //que notifica quando uma alteração é feita nas propriedades da
    //nossa view e modelo
    //esta devem ser herdadas desta classe a propriedade set deve conter 
    //o metodo que retorna o nome da propriedade alterada
    public class ObservableBaseObject : INotifyPropertyChanged
    {
        public ObservableBaseObject()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged = delegate
        {

        };

        public void OnPropertyChenged([CallerMemberName] string name = "")
        {
            if(PropertyChanged == null)
            {
                return;
            }
            else
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
