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
    public partial class SelectImagePopupPage : PopupPage, ISetting
    {
        private ISetting settingDelegate = null;
        public void SetSettingDelegate(ISetting s)
        {
            settingDelegate = s;
        }
        public SelectImagePopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();

            lvImage.ItemTemplate.SetBinding(SelectImageViewCellNative.PairIndexProperty, "PairIndex");
            lvImage.ItemTemplate.SetBinding(SelectImageViewCellNative.PairNameProperty, "PairName");
            lvImage.ItemTemplate.SetBinding(SelectImageViewCellNative.Image1Property, "Image1");
            lvImage.ItemTemplate.SetBinding(SelectImageViewCellNative.Image2Property, "Image2");

            lvImage.ItemSelected += (sender, e) => {
                if (e.SelectedItem == null)
                    return;
                lvImage.SelectedItem = null; // deselect row
                if(e.SelectedItem is PairImageCell)
                {
                    OnImageChanged(((PairImageCell)e.SelectedItem));
                }
            };
        }

        public void OnGateChanged(GateCell gateCell)
        {
        }

        public async void OnImageChanged(PairImageCell pairImage)
        {
            settingDelegate.OnImageChanged(pairImage);
            await PopupNavigation.PopAsync();
        }

        public void OnLevelChanged(Level level)
        {
            throw new NotImplementedException();
        }
    }
}
