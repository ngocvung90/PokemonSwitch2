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
    public partial class WelcomePopupPage : PopupPage
    {
        public WelcomePopupPage()
        {
            InitializeComponent();
            Animation = new UserAnimation();

            ShowWelcomeSwitch.Toggled += ShowPopupSwitch_Toggled;
        }

        private async void ShowPopupSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            int ShowWelcomePopupVal = e.Value ? 1 : 0;
            Setting setting = App._dbHelper.GetSetting();
            setting.ShowWelcomePopup = ShowWelcomePopupVal;
            App._dbHelper.UpdateSetting(setting);

            await PopupNavigation.PopAsync();
        }
    }
}
