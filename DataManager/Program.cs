using May2026_OODExam.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using May2026_OODExam.Models;
using System.Data.Entity;

namespace DataManager
{
    internal class Program
    {
        static void Main(string[] args)
        {     
            ClubData db = new ClubData();

            using (db)
            {
                //create instances of the data
                Member member1 = new Member
                {
                    FirstName = "John",
                    Surname = "Doe",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    ContactNumber = "1234567890",
                    MembershipType = "Gold",
                    TrainingSessions = new List<TrainingSession>()

                };

                // add the data to the database
                db.Members.Add(member1);
                Console.WriteLine("Member1 added");

                // save the changes to the database
                db.SaveChanges();
                Console.WriteLine("Saved Memeber1 to db");


                //create a training session and add it to the member
                TrainingSession session1 = new TrainingSession
                {
                    SessionType = "Morning Swim",
                    SessionDate = new DateTime(2026, 05, 20),
                    DurationMinutes = 60,
                    CoachNotes = "Pool A",
                    MemberId = member1.MemberId,
                    Member = member1
                };

                // add the training session to the database
                db.TrainingSessions.Add(session1);
                Console.WriteLine("Session1 added");

                // save the changes to the database
                db.SaveChanges();
                Console.WriteLine("Saved Session1 to db");


            }
        }
    }
}
