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
    public partial class TipPopupPage : PopupPage 
    {
        public TipPopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();

            var tapImageSaveImage = new TapGestureRecognizer();
            tapImageSaveImage.Tapped += Save_Handler;
            imgSave.GestureRecognizers.Add(tapImageSaveImage);

            ShowPopupSwitch.Toggled += ShowPopupSwitch_Toggled;
        }

        private void ShowPopupSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int ShowTipPopupVal = e.Value ? 1 : 0;
            Setting setting = App._dbHelper.GetSetting();
            setting.ShowTipPopup = ShowTipPopupVal;
            App._dbHelper.UpdateSetting(setting);
        }

        public void SetToggle(bool val)
        {
            ShowPopupSwitch.IsToggled = val;
        }
        private async void Save_Handler(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync();
        }
    }
}
