using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace GraveFinderApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Contains a list of graves for testing purposes
        List<Grave> graves = new List<Grave> 
        {
            new Grave() { Cemetery = "Glasnevin", RowID = "AA", GraveNumber = 15, Name = "Sean O'Neill", Gender = GenderType.Male, Address = "12 Johnstown Bridge", DOB = new DateTime(1975, 08, 12), DOD = new DateTime(2005, 04, 15), InGrave = "None" },
            new Grave() { Cemetery = "Deansgrange", RowID = "Michael", GraveNumber = 33, Name = "Rachel Smyth", Gender = GenderType.Female, Address = "13 Johns Road", DOB = new DateTime(1968, 06, 07), DOD = new DateTime(2003, 05, 21), InGrave = "None" }
        };

        public MainPage()
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
            // Sets DateTimeOffset variable to the date from the DatePicker DateOfBirth and the offset to 0
            DateTimeOffset selectedDobDate = this.DateOfBirth.Date;

            // Sets DateTimeOffset variable to the date from the DatePicker DateOfDeath and the offset to 0
            DateTimeOffset selectedDodDate = this.DateOfDeath.Date;

            // Sets selectedCemetery string to the cemetery name when the dropdown is closed
            String selectedCemetery = CemeteryNames.SelectionBoxItem.ToString();

            // Finds the first or default grave from the list based on the deceased person, cemetery name and either the dob or dod
            var grave = graves.FirstOrDefault(g => g.Name.ToUpper() == DeceasedPerson.Text.ToUpper() && g.Cemetery.ToUpper() == selectedCemetery.ToUpper() && DateTime.Compare(g.DOB.Date, selectedDobDate.Date) == 0 || DateTime.Compare(g.DOD.Date, selectedDodDate.Date) == 0);

            // It will pass the variable and navigate to the ResultsPage
            Frame.Navigate(typeof(ResultsPage), grave);
        }
    }
}
