using PokemonSwitch.DB;
using PokemonSwitch.Interface;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PokemonSwitch
{
    public interface ISetting
    {
        void OnImageChanged(PairImageCell pairImage);
        void OnGateChanged(GateCell gateCell);
        void OnLevelChanged(Level level);
    }
    public partial class SettingPopupPage : PopupPage, ISetting, IMapDelegate
    {
        IMapDelegate mapDelegate;
        SettingPopupVM _vm;
        FinishedPopupPage finishPage;
        SelectLevelPopupPage selectLevelPopup;
        SelectGatePopupPage selectGatePopup;
        SelectImagePopupPage selectImagePopup;

        public void SetMapDelegate(IMapDelegate m)
        {
            mapDelegate = m;
        }
        public SettingPopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();

            finishPage = new FinishedPopupPage();
            selectLevelPopup = new SelectLevelPopupPage();
            selectLevelPopup.SetSettingDelegate(this);

            selectGatePopup = new SelectGatePopupPage();
            selectGatePopup.SetSettingDelegate(this);

            selectImagePopup = new SelectImagePopupPage();
            selectImagePopup.SetSettingDelegate(this);
            var tapImage = new TapGestureRecognizer();
            tapImage.Tapped += SettingLevel_Handler;
            imgSettingLevel.GestureRecognizers.Add(tapImage);

            var tapImageSettingGate = new TapGestureRecognizer();
            tapImageSettingGate.Tapped += SettingGate_Handler;
            imgSettingGate.GestureRecognizers.Add(tapImageSettingGate);

            var tapImageSettingImage= new TapGestureRecognizer();
            tapImageSettingImage.Tapped += SettingImage_Handler;
            imgSettingImage.GestureRecognizers.Add(tapImageSettingImage);

            var tapImageSaveImage = new TapGestureRecognizer();
            tapImageSaveImage.Tapped += Save_Handler;
            imgSave.GestureRecognizers.Add(tapImageSaveImage);
        }

        private async void Save_Handler(object sender, EventArgs e)
        {
            Setting setting = App._dbHelper.GetSetting();
            setting.LevelID = LevelTextToInt(_vm.Level);
            setting.GateIndex = Int32.Parse(_vm.RealGate);
            setting.GateIndex--;
            setting.PairImageName = _vm.ImageSource1 + "|" + _vm.ImageSource2;
            App._dbHelper.UpdateSetting(setting);
            await PopupNavigation.PopAsync();
            SettingSaved();
        }

        public void SetContext(SettingPopupVM vm)
        {
            this.BindingContext = vm;
            _vm = vm;
        }
        private async void SettingLevel_Handler(object sender, EventArgs e)
        {
            //finishPage.SetStar(2);
            ObservableCollection<Level> ListLevel = new ObservableCollection<Level>(App._dbHelper.GetLevels());
            _vm.ListLevel = ListLevel;
            selectLevelPopup.BindingContext = _vm;
            await PopupNavigation.PushAsync(selectLevelPopup);
        }

        private async void SettingImage_Handler(object sender, EventArgs e)
        {
            //finishPage.SetStar(2);
            ObservableCollection<PairImage> ListPairImage = new ObservableCollection<PairImage>(App._dbHelper.GetPairImages());
            ObservableCollection<PairImageCell> listImageCell = new ObservableCollection<PairImageCell>();
            int pairIndex = 1;
            foreach (var pairImage in ListPairImage)
            {
                PairImageCell pair = new PairImageCell();
                pair.PairIndex = pairIndex;
                string[] arr = pairImage.PairName.Split('|');
                pair.PairName = arr[0] + " vs " + arr[1];
                pair.Image1 = arr[0];
                pair.Image2 = arr[1];
                listImageCell.Add(pair);
                pairIndex++;
            }
            _vm.ListImage = listImageCell;
            selectImagePopup.BindingContext = _vm;
            await PopupNavigation.PushAsync(selectImagePopup);
        }

        private int LevelTextToInt(string strLevel)
        {
            int Level = -1;
            switch (strLevel)
            {
                case "Very Easy":
                    Level = 2; break;
                case "Easy":
                    Level = 3; break;
                case "Hard":
                    Level = 4; break;
                case "Very Hard":
                    Level = 5; break;
                default:
                    Level = 6; break;
            }
            return Level;
        }
        private async void SettingGate_Handler(object sender, EventArgs e)
        {
            int levelID = LevelTextToInt(_vm.Level);
            //finishPage.SetStar(2);
            ObservableCollection<Gate> ListGate = new ObservableCollection<Gate>(App._dbHelper.GetGatesFromLevel(levelID));
            ObservableCollection<GateCell> ListGateCell = new ObservableCollection<GateCell>();
            foreach(Gate gate in ListGate)
            {
                GateCell gateCell = new GateCell();
                gateCell.GateIndex = gate.GateIndex + 1;
                gateCell.Star = gate.Star;
                gateCell.LevelDescription = "Easy";
                if (gateCell.Star == 0) { gateCell.StarOne = "StarNonSelect"; gateCell.StarTwo = "StarNonSelect"; gateCell.StarThree = "StarNonSelect"; }
                else if (gateCell.Star == 1) { gateCell.StarOne = "StarSelect"; gateCell.StarTwo = "StarNonSelect"; gateCell.StarThree = "StarNonSelect"; }
                else if (gateCell.Star == 2) { gateCell.StarOne = "StarSelect"; gateCell.StarTwo = "StarSelect"; gateCell.StarThree = "StarNonSelect"; }
                else if (gateCell.Star == 3) { gateCell.StarOne = "StarSelect"; gateCell.StarTwo = "StarSelect"; gateCell.StarThree = "StarSelect"; }
                ListGateCell.Add(gateCell);
            }
            _vm.ListGate = ListGateCell;
            selectGatePopup.BindingContext = _vm;
            await PopupNavigation.PushAsync(selectGatePopup);
        }

        public void OnImageChanged(PairImageCell pairImage)
        {
            _vm.ImageSource1 = pairImage.Image1;
            _vm.ImageSource2 = pairImage.Image2;
            this.BindingContext = _vm;
        }

        public void OnGateChanged(GateCell gateCell)
        {
            _vm.Gate = gateCell.GateIndex.ToString();
            this.BindingContext = _vm;
        }

        public void OnLevelChanged(Level level)
        {
            _vm.Level = level.Description;
            _vm.TotalGate = level.GateNumber.ToString();
            _vm.Gate = "1";
        }

        public void TipForUser()
        {
            throw new NotImplementedException();
        }

        public void ResetMap()
        {
            throw new NotImplementedException();
        }

        public void SettingSaved()
        {
            mapDelegate.SettingSaved();
        }
    }
}
