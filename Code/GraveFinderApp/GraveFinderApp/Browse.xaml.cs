using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GraveFinderApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Browse : Page
    {
        List<Grave> graves = new List<Grave>();

        public Browse()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            
        }

        public async void ReadData()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://gmanager.azurewebsites.net/");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // GET ../api/Graves/
                    HttpResponseMessage response = await client.GetAsync("api/Graves");
                    if (response.IsSuccessStatusCode)
                    {
                        // read result 
                        var entries = await response.Content.ReadAsAsync<IEnumerable<Grave>>();
                        foreach (var grave in entries)
                        {
                            graves.Add(grave);
                        }
                        ListOfGraves = new ListBox();
                        ListOfGraves.Width = 140;
                        ListOfGraves.ItemsSource = graves;
                    }
                    else
                    {
                        Debug.WriteLine(response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
    }
}
