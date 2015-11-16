using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace AppServiceOverview.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Define a member variable for storing the signed-in user. 
        private MobileServiceUser user;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void GetRankButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentRank.Text = "Loading";
            var teamNumber = Int32.Parse(TeamNumber.Text);

            var client = new FrcRank.Frcrankapi01();
            var team = await client.Teams.GetByIdWithOperationResponseAsync(teamNumber);
            if(team.Response.IsSuccessStatusCode)
            {
                CurrentRank.Text = team.Body.Rank.ToString();
            }
            else
            {
                CurrentRank.Text = "Could not load";
            }
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            await AuthenticateAsync();
        }

        private async System.Threading.Tasks.Task AuthenticateAsync()
        {
            while (user == null)
            {
                string message;
                try
                {
                    // Change 'MobileService' to the name of your MobileServiceClient instance.
                    // Sign-in using Facebook authentication.
                    user = await App.MobileService
                        .LoginAsync(MobileServiceAuthenticationProvider.Twitter);
                    message =
                        string.Format("You are now signed in - {0}", user.UserId);
                }
                catch (InvalidOperationException)
                {
                    message = "You must log in. Login Required";
                }

                var dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand("OK"));
                await dialog.ShowAsync();
            }
        }
    }
}
