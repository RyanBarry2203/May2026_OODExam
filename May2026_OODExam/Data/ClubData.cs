using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace May2026_OODExam.Data
{
    public class ClubData : DbContext
    {
        public ClubData() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OODExam_RyanBarry_v2;Integrated Security=True;") { }

        public DbSet<Models.Member> Members { get; set; }
        public DbSet<Models.TrainingSession> TrainingSessions { get; set; }
    }
}
