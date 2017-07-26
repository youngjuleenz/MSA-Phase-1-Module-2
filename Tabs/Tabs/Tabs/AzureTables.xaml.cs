using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AzureTables : ContentPage
    {
        public AzureTables()
        {
            InitializeComponent();
        }

        async void Handle_ClickedAsync(object sender, System.EventArgs e)
        {
            List<YayOrNayModel> yayornayInformation = await AzureManager.AzureManagerInstance.GetEmotionInformation();

            EmotionList.ItemsSource = yayornayInformation;
        }
    }
}