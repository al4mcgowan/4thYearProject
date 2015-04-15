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

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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
                Cemetery.Text = "Buried in: " + g.Cemetery + " on row: " + g.RowID + " at number " + g.GraveNumber;
                LastAddress.Text = "Last Address: " + g.Address;
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