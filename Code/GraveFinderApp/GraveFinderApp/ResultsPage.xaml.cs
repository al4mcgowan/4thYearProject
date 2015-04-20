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
        public ResultsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Grave g = e.Parameter as Grave;

            if (g == null)
            {
                Frame.Navigate(typeof(Search));
            }
            else
            {
                // if g is not empty, print the details
                DeceasedPerson.Text = "Deceased Person: " + g.Name;
                Gender.Text = "Gender: " + g.Gender;
                Cemetery.Text = "Buried in: " + g.Cemetery + ", row " + g.RowID + ", number: " + g.GraveNumber;
                LastAddress.Text = "Last Address: " + "\n" + g.Address;
                DOB.Text = "Born on: " + g.DOB.Date.ToString("dd/MM/yyyy");
                DOD.Text = "Died on: " + g.DOD.Date.ToString("dd/MM/yyyy");
                InGrave.Text = "Also in the grave: " + g.InGrave;
            }
        }

        private void BeginNewSearch(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Search));
        }
    }
}