using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonSwitch
{
    public class WelcomePopupVM : ViewModelBase
    {
        private string _LawGuide = "";
        public string LawGuide
        {
            get { return _LawGuide; }
            set
            {
                _LawGuide = value;
                OnPropertyChanged("LawGuide");
            }
        }

        private string _LawGuide1 = "";
        public string LawGuide1
        {
            get { return _LawGuide1; }
            set
            {
                _LawGuide1 = value;
                OnPropertyChanged("LawGuide1");
            }
        }

        private string _LawGuide2 = "";
        public string LawGuide2
        {
            get { return _LawGuide2; }
            set
            {
                _LawGuide2= value;
                OnPropertyChanged("LawGuide2");
            }
        }

        private string _SettingGuide = "";
        public string SettingGuide
        {
            get { return _SettingGuide; }
            set
            {
                _SettingGuide = value;
                OnPropertyChanged("SettingGuide");
            }
        }

        private string _RetryGuide = "";
        public string RetryGuide
        {
            get { return _RetryGuide; }
            set
            {
                _RetryGuide = value;
                OnPropertyChanged("RetryGuide");
            }
        }

        private string _HelpGuide = "";
        public string HelpGuide
        {
            get { return _HelpGuide; }
            set
            {
                _HelpGuide = value;
                OnPropertyChanged("HelpGuide");
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
