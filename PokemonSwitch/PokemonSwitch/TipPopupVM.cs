using PokemonSwitch.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch
{
    public class TipPopupVM : ViewModelBase
    {
        private string _TipBalance = "";
        public string TipBalance
        {
            get { return _TipBalance; }
            set
            {
                _TipBalance = value;
                OnPropertyChanged("TipBalance");
            }
        }

        private string _RemainSteps = "";
        public string RemainSteps
        {
            get { return _RemainSteps; }
            set
            {
                _RemainSteps = value;
                OnPropertyChanged("RemainSteps");
            }
        }

        private bool _IsOn = true;
        public bool IsOn
        {
            get { return _IsOn; }
            set
            {
                _IsOn = value;
                OnPropertyChanged("IsOn");
            }
        }
    }
}
