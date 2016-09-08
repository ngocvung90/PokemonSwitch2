using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using PokemonSwitch.DB;
using Rg.Plugins.Popup.Services;

namespace PokemonSwitch
{
    public partial class SelectLevelPopupPage : PopupPage, ISetting
    {
        private ISetting settingDelegate = null;
        public void SetSettingDelegate(ISetting s)
        {
            settingDelegate = s;
        }

        public void OnImageChanged(PairImageCell pairImage)
        {
            throw new NotImplementedException();
        }

        public void OnGateChanged(GateCell gateCell)
        {
            throw new NotImplementedException();
        }

        public async void OnLevelChanged(Level level)
        {
            settingDelegate.OnLevelChanged(level);
            await PopupNavigation.PopAsync();
        }

        public SelectLevelPopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();

            lvLevel.ItemTemplate.SetBinding(SelectLevelViewCellNative.LevelIDProperty, "SolveStep");
            lvLevel.ItemTemplate.SetBinding(SelectLevelViewCellNative.LevelDescriptionProperty, "Description");
            lvLevel.ItemTemplate.SetBinding(SelectLevelViewCellNative.GateNumberProperty, "GateNumber");

            lvLevel.ItemSelected += (sender, e) => {
                if (e.SelectedItem == null)
                    return;
                lvLevel.SelectedItem = null; // deselect row
                if (e.SelectedItem is Level)
                {
                    OnLevelChanged(((Level)e.SelectedItem));
                }
            };
        }
    }
}
