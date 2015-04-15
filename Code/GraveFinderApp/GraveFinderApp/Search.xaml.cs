using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace GraveFinderApp
{
    public sealed partial class Search : Page
    {
        // Contains a list of graves for testing purposes
        List<Grave> graves = new List<Grave> 
        {
            new Grave() { Cemetery = "Glasnevin", RowID = "AA", GraveNumber = 15, Name = "Sean O'Neill", Gender = GenderType.Male, Address = "12 Johnstown Bridge", DOB = new DateTime(1975, 08, 12), DOD = new DateTime(2005, 04, 15), InGrave = "None" },
            new Grave() { Cemetery = "Deansgrange", RowID = "Michael", GraveNumber = 33, Name = "Rachel Smyth", Gender = GenderType.Female, Address = "13 Johns Road", DOB = new DateTime(1968, 06, 07), DOD = new DateTime(2003, 05, 21), InGrave = "None" }
        };

        public Search()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        // Called when the search button is pressed
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // Either dates have changed
            DateTimeOffset selectedDobDate = this.DateOfBirth.Date;
            DateTimeOffset selectedDodDate = this.DateOfDeath.Date;

            // Or only the years have changed
            int dobyear = selectedDobDate.Year;
            int dodyear = selectedDodDate.Year;

            // Checks if either of the years dont match the current year
            if (dobyear != DateTime.Now.Year || dodyear != DateTime.Now.Year)
            {
                var grave = graves.FirstOrDefault(g => g.Name.ToUpper() == DeceasedPerson.Text.ToUpper() && g.DOB.Year == dobyear || g.DOD.Year == dodyear);
                Frame.Navigate(typeof(ResultsPage), grave);
            }
            else
            {
                var grave = graves.FirstOrDefault(g => g.Name.ToUpper() == DeceasedPerson.Text.ToUpper() && DateTime.Compare(g.DOB.Date, selectedDobDate.Date) == 0 || DateTime.Compare(g.DOD.Date, selectedDodDate.Date) == 0);
                Frame.Navigate(typeof(ResultsPage), grave);
            }
        }

        // Called when the reset button is pressed
        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            DeceasedPerson.Text = "";
            CemeteryNames.SelectedValue = CemeteryNames.PlaceholderText;
            DateOfBirth.Date = DateTime.Now;
            DateOfDeath.Date = DateTime.Now;
        }
    }
}
