using PokemonSwitch.DB;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace PokemonSwitch
{
    public partial class SelectGatePopupPage : PopupPage , ISetting
    {
        private ISetting settingDelegate = null;
        public void SetSettingDelegate(ISetting s)
        {
            settingDelegate = s;
        }
        public SelectGatePopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();
            lvGate.ItemTemplate.SetBinding(SelectGateViewCellNative.GateIndexProperty, "GateIndex");
            lvGate.ItemTemplate.SetBinding(SelectGateViewCellNative.LevelDescriptionProperty, "LevelDescription");
            lvGate.ItemTemplate.SetBinding(SelectGateViewCellNative.StarOneProperty, "StarOne");
            lvGate.ItemTemplate.SetBinding(SelectGateViewCellNative.StarTwoProperty, "StarTwo");
            lvGate.ItemTemplate.SetBinding(SelectGateViewCellNative.StarThreeProperty, "StarThree");

            lvGate.ItemSelected += (sender, e) => {
                if (e.SelectedItem == null)
                    return;
                lvGate.SelectedItem = null; // deselect row
                if (e.SelectedItem is GateCell)
                {
                    OnGateChanged(((GateCell)e.SelectedItem));
                }
            };
        }

        public async void OnGateChanged(GateCell gateCell)
        {
            settingDelegate.OnGateChanged(gateCell);
            await PopupNavigation.PopAsync();
        }

        public void OnImageChanged(PairImageCell pairImage)
        {
            throw new NotImplementedException();
        }

        public void OnLevelChanged(Level level)
        {
            throw new NotImplementedException();
        }
    }
}
