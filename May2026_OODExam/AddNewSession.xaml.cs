using May2026_OODExam.Models;
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
using System.Windows.Shapes;

namespace May2026_OODExam
{
    /// <summary>
    /// Interaction logic for AddNewSession.xaml
    /// </summary>
    public partial class AddNewSession : Window
    {
        private Member _member;
        private TrainingSession _session;
        public AddNewSession()
        {
            InitializeComponent();
        }
        public AddNewSession(Member member) : this()
        {
            _member = member;

        }

        private void SaveSessionButton_Click(object sender, RoutedEventArgs e)
        {
            // create a new training session based on details entered in the form
            _session = new TrainingSession
            {
                SessionType = SessionTypeComboBox.Text,
                SessionDate = SessionDateDatePicker.SelectedDate ?? DateTime.Now,
                DurationMinutes = int.TryParse(DurationNumericUpDown.ToString(), out int duration) ? duration : 0,
                CoachNotes = CoachNotesTextBox.Text,
                MemberId = _member.MemberId
            };

            // add the new session to the member's list of training sessions
            _member.TrainingSessions.Add(_session);

            // save the new session to the database
            using (var db = new Data.ClubData())
            {
                db.TrainingSessions.Add(_session);
                db.SaveChanges();
            }

            MessageBox.Show("Training session added successfully!");
            this.Close();

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // close the window without saving
            this.Close();

        }
    }
}
