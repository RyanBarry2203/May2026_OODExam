using May2026_OODExam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace May2026_OODExam
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClubData db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new ClubData();

            // query the database and display the members in the ListBox
            using (db)
            {
                // sort by last name and then first name
                var members = db.Members.OrderBy(m => m.Surname).ToList();
                lbxMembers.ItemsSource = members;
            }


        }

        private void AddTrainingSessionButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lbxMembers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                // fill text boxes with member data when selection chnaged
                if (lbxMembers.SelectedItem is Models.Member selectedMember)
                {
                    IDTextBox.Text = selectedMember.FirstName;
                    LastNameTextBox.Text = selectedMember.Surname;
                    DateOfBirthDatePicker.Text = selectedMember.DateOfBirth.ToShortDateString();
                    ContactNumberTextBox.Text = selectedMember.ContactNumber;
                    MembershipTypeTextBox.Text = selectedMember.MembershipType;
                }

            //display the training sessions for the selected member in the ListBox
            if (lbxMembers.SelectedItem is Models.Member selectedMember2)
            {
                var trainingSessions = db.TrainingSessions.Where(ts => ts.MemberId == selectedMember2.MemberId).ToList();
                TrainingSessionsListBox.ItemsSource = trainingSessions;
            }
            else
            {
                TrainingSessionsListBox.ItemsSource = new string[] { "No Sessions Found" };
            }

        }
    }
}
