using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace GraveFinderApp
{
    public sealed partial class ResultsPage : Page
    {
        static string GeneratedHTML = "";
        public ResultsPage()
        {
            this.InitializeComponent();
        }

        private async void LoadData()
        {
            try
            {
                await loadJsonLocalnew("default.html", "");
            }
            catch (Exception ex)
            {
                throw ex ;
            }
        }

        public async static Task loadJsonLocalnew(string url, object ClassName)
        {
            try
            {
                //*******************************************************
                //To pick up file from local folder in window store app
                //*******************************************************
                StorageFolder folder = await Package.Current.InstalledLocation.GetFolderAsync("htmlPage");
                StorageFile file = await folder.GetFileAsync(url);
                Stream stream = await file.OpenStreamForReadAsync();
                StreamReader reader = new StreamReader(stream);
                String html = reader.ReadToEnd();
                GeneratedHTML = html.ToString();
                //*******************************************************
                //*******************************************************
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            LoadData();
            //Setting the HTML content in the WebView control.
            MapWebView.NavigateToString(GeneratedHTML);

             // Takes the parameter passed from the Search in as a variable and stores it in g
            Grave g = e.Parameter as Grave;

            if (g == null)
            {
                DeceasedPerson.Text = "404 Not Found";
                Gender.Text = "";
                Cemetery.Text = "";
                LastAddress.Text = "";
                DOB.Text = "";
                DOD.Text = "";
                InGrave.Text = "";
            }
            else
            {
                // if g is not empty, print the details
                DeceasedPerson.Text = "Deceased Person: " + g.Name;
                Gender.Text = "Gender: " + g.Gender;
                Cemetery.Text = "Buried in: " + g.Cemetery + " on row: " + g.RowID + "\n\t at number " + g.GraveNumber;
                LastAddress.Text = "Last Address: " + "\n" + g.Address;
                DOB.Text = "Born on: " + g.DOB.Date.ToString("d");
                DOD.Text = "Died on: " + g.DOD.Date.ToString("d");
                InGrave.Text = "Also in the grave: " + g.InGrave;
            }
        }

        private void BeginNewSearch(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
    }
}