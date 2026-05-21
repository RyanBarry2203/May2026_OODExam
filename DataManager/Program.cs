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
    // couldnt get database up and running for some reason, never happened before so i had to continue without being able to test anything, i have added the code to add data to the database but i have not been able to test it, i have also added some console writelines to show where the code is up to but again i have not been able to test it so it may not work as intended
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
                    MembershipType = "Gold"

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
                    //Member = member1
                };

                // add the training session to the database
                db.TrainingSessions.Add(session1);
                Console.WriteLine("Session1 added");

                // save the changes to the database
                db.SaveChanges();
                Console.WriteLine("Saved Session1 to db");

                //using (db)
                //{
                //    //create a new movie
                //    var m1 = new Member
                //    {
                //        FirstName = "Joe",
                //        Surname = "The Simpleton",
                //        DateOfBirth = new DateTime(2026, 05, 20),
                //        ContactNumber = "1234567",
                //        MembershipType = "Elite 2"
                //    };

                //    //add the movie to the database
                //    db.Members.Add(m1);
                //    Console.WriteLine($"Added Member");

                //    //save the changes to the database
                //    db.SaveChanges();
                //    Console.WriteLine($"Saved changes to db");

                //    //create a new booking for the movie
                //    var t1 = new TrainingSession
                //     {
                //         SessionType = "Morning Swim",
                //         SessionDate = new DateTime(2026, 05, 20),
                //         DurationMinutes = 60,
                //         CoachNotes = "Pool A",
                //         MemberId = m1.MemberId,
                //         //Member = m1
                //     };

                //    //add the booking to the database
                //    db.TrainingSessions.Add(t1);
                //    Console.WriteLine($"Added new Session");

                //    //save the changes to the database
                //    db.SaveChanges();
                //    Console.WriteLine($"Saved changes to db");
                //}


            }
        }
        
    }
}
