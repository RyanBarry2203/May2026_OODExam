using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2026_OODExam.Models
{
    public class Member
    {
        // properties for Member class
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; }
        public string MembershipType { get; set; }

        //foerign key to TrainingSession class
        public virtual List<TrainingSession> TrainingSessions { get; set; }

        // constructor for Member class
        public Member()
        {
            TrainingSessions = new List<TrainingSession>();
        }

        // methods for Member class

        public override string ToString()
        {
            return $"{FirstName} {Surname} - {MembershipType}";
        }
    }
}
