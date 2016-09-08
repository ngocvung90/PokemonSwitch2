using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch
{
    class FinishedPopupVM : ViewModelBase
    {
        private string _StarOne, _StarTwo, _StarThree ;
        public string StarOne
        {
            get { if (_StarOne == null) _StarOne = "";
                return _StarOne;
            }
            set
            {
                _StarOne = value;
                OnPropertyChanged("StarOne");
            }
        }
        public string StarTwo
        {
            get
            {
                if (_StarTwo == null) _StarTwo = "";
                return _StarTwo;
            }
            set
            {
                _StarTwo = value;
                OnPropertyChanged("StarTwo");
            }
        }

        public string StarThree
        {
            get
            {
                if (_StarThree == null) _StarThree = "";
                return _StarThree;
            }
            set
            {
                _StarThree = value;
                OnPropertyChanged("StarThree");
            }
        }

        public FinishedPopupVM()
        {
            StarOne = "";
            StarTwo = "";
            StarThree = "";
        }

        public void SetStar(int indexStar)
        {
            if (indexStar == 0) { StarOne = "StarNonSelect"; StarTwo = "StarNonSelect"; StarThree = "StarNonSelect"; }
            else if (indexStar == 1) { StarOne = "StarSelect"; StarTwo = "StarNonSelect"; StarThree = "StarNonSelect"; }
            else if (indexStar == 2) { StarOne = "StarSelect"; StarTwo = "StarSelect"; StarThree = "StarNonSelect"; }
            else if (indexStar == 3) { StarOne = "StarSelect"; StarTwo = "StarSelect"; StarThree = "StarSelect"; }
            OnPropertyChanged("StarOne");
            OnPropertyChanged("StarTwo");
            OnPropertyChanged("StarThree");
        }
    }
}
