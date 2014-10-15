using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Xml.Linq;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Reactive;
using Microsoft.Phone.Shell;
using WPLiveTiles.Resources;

namespace WPLiveTiles
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void UpdateTile_OnTap(object sender, GestureEventArgs e)
        {


              string tileXmlString = 
                @"<tile>
                     <visual>
                        <binding template='TileSquareText02'>
                         <text id='1'>Time is</text>
                          <text id='2'>" + DateTime.Now.ToShortTimeString() + @"</text>
                        </binding>
                      </visual>
                  </tile>
";

            var tileXml = new XmlDocument();
            tileXml.LoadXml(tileXmlString);

            
            var tile = new TileNotification(tileXml);

            TileUpdateManager.CreateTileUpdaterForApplication().Update(tile);

        }

        private void CreateToast_OnTap(object sender, GestureEventArgs e)
        {
            string toastXmlString =
                @"<toast>
                     <visual>
                        <binding template='ToastText02'>
                         <text id='1'>Hello from scheduled toast!</text>
                        </binding>
                      </visual>
                  </toast>
";

            var toastXml = new XmlDocument();
            toastXml.LoadXml(toastXmlString);


            var toast = new ScheduledToastNotification(toastXml, DateTime.Now.AddSeconds(5));

            ToastNotificationManager.CreateToastNotifier().AddToSchedule(toast);

        }
    }
}