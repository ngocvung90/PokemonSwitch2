using PokemonSwitch.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch
{
    public class SettingPopupVM : ViewModelBase
    {
        #region Setting popup
        private string _level = "";
        public string Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged("Level");
            }
        }
        private string _gate = "";
        public string Gate
        {
            get { return _gate; }
            set
            {
                _realgate = value;
                _gate = value + "/" + _totalGate;
                OnPropertyChanged("Gate");
            }
        }

        private string _realgate = "";
        public string RealGate
        {
            get { return _realgate; }
            set
            {
                _realgate = value;
                OnPropertyChanged("RealGate");
            }
        }

        private string _totalGate = "";
        public string TotalGate
        {
            get { return _totalGate; }
            set
            {
                _totalGate = value;
                OnPropertyChanged("TotalGate");
            }
        }
        private string _imageSource1 = "";
        public string ImageSource1
        {
            get { return _imageSource1; }
            set
            {
                _imageSource1 = value;
                OnPropertyChanged("ImageSource1");
            }
        }

        private string _imageSource2 = "";
        public string ImageSource2
        {
            get { return _imageSource2; }
            set
            {
                _imageSource2 = value;
                OnPropertyChanged("ImageSource2");
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

        private bool _IsOnWelcome = true;
        public bool IsOnWelcome
        {
            get { return IsOnWelcome; }
            set
            {
                IsOnWelcome = value;
                OnPropertyChanged("IsOnWelcome");
            }
        }
        #endregion
        #region Select Level popup
        private ObservableCollection<Level> _listLevel = new ObservableCollection<Level>();
        public ObservableCollection<Level> ListLevel
        {
            get { return _listLevel; }
            set
            {
                _listLevel = value;
                OnPropertyChanged("ListLevel");
            }
        }
        #endregion
        #region Select gate popup

        private ObservableCollection<GateCell> _listGate = new ObservableCollection<GateCell>();
        public ObservableCollection<GateCell> ListGate
        {
            get { return _listGate; }
            set
            {
                _listGate = value;
                OnPropertyChanged("ListGate");
            }
        }
        #endregion
        #region Select Image popup
        private ObservableCollection<PairImageCell> _listImage = new ObservableCollection<PairImageCell>();
        public ObservableCollection<PairImageCell> ListImage
        {
            get { return _listImage; }
            set
            {
                _listImage = value;
                OnPropertyChanged("ListImage");
            }
        }
        #endregion
    }
}
