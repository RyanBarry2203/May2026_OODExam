using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2026_OODExam.Models
{
    public class TrainingSession
    {

        // properties for TrainingSession class
        public int SessionId { get; set; }
        public DateTime SessionDate { get; set; }
        public string SessionType { get; set; }
        public int DurationMinutes { get; set; }
        public string CoachNotes { get; set; }

        // foreign key to Member class
        public virtual int MemberId { get; set; }

        public virtual Member Member { get; set; }

        // constructor for TrainingSession class
        public TrainingSession()
        {
            
        }

        // methods for TrainingSession class

        public override string ToString()
        {
            return $"{SessionType} on {SessionDate.ToShortDateString()} for {DurationMinutes} minutes";
        }
    }
}
