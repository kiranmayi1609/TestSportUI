using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportTestAPI.DataModels;

namespace SportTestAPI.Database
{
    public class ApplicationDbContext:IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options) 
        {
            
        }

        public DbSet<AgeGroup> AgeGroups { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Tournment> Tournaments { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedRoles(modelBuilder);


            // Seeding data for AgeGroup
            modelBuilder.Entity<AgeGroup>().HasData(
                new AgeGroup { AgeGroupID = 1, GroupName = "Under 18" ,AvailableDays="12"},
                new AgeGroup { AgeGroupID = 2, GroupName = "18-35", AvailableDays = "12" },
                new AgeGroup { AgeGroupID = 3, GroupName= "36-50", AvailableDays = "12" },
                new AgeGroup { AgeGroupID = 4, GroupName = "Above 50", AvailableDays = "12" }
            );



            // Seeding data for ApplicationUser (assuming this entity has basic properties like ID and Name)
            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser { Id = "123", UserName = "johndoe", FullName = "John Doe",Contact="",Gender="m",Email="KK@GMAIL.COM",Role="Admin" },
                new ApplicationUser { Id = "143", UserName = "janedoe", FullName = "Jane Doe",Contact="" ,Gender= "f",Email= "KK@GMAIL.COM",Role="User" }


            );

            // Seeding data for Coach
            modelBuilder.Entity<Coach>().HasData(
                new Coach { CoachID = 1, Name = "Coach John" ,ProfilePic="",Specialty=""},
                new Coach { CoachID = 2, Name = "Coach Lisa",ProfilePic="",Specialty= "" }
            );

            // Seeding data for Court
            modelBuilder.Entity<Court>().HasData(
                new Court { CourtID = 1, Name = "Court 1", Location = "Building A" ,Picture=""},
                new Court { CourtID = 2, Name = "Court 2", Location = "Building B",Picture = "" }
            );

            // Seeding data for Booking (Book courts for users)
            modelBuilder.Entity<Booking>().HasData(
                new Booking
                {
                    BookingID = 1,
                    UserID = "123",  // Reference to ApplicationUser with Id "123"
                    CourtID = 1,    // Reference to Court with CourtID = 1
                    Date = new DateTime(2025, 03, 11, 10, 0, 0)  // Example Date and Time
                },
                new Booking
                {
                    BookingID = 2,
                    UserID = "143",  // Reference to ApplicationUser with Id "143"
                    CourtID = 2,    // Reference to Court with CourtID = 2
                    Date = new DateTime(2025, 03, 12, 11, 30, 0)  // Example Date and Time
                }
            );



            // Seeding data for Invoice
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceID = 1, UserID = "123", Amount = 100, DateIssued = DateTime.Now,PaymentMethod="",Status="Active"},
                new Invoice { InvoiceID = 2, UserID ="143", Amount = 150, DateIssued = DateTime.Now ,PaymentMethod= "",Status="DeActive" }
            );

            // Seeding data for Tournament
            modelBuilder.Entity<Tournment>().HasData(
                new Tournment { TournamentID = 1, Name = "Summer Open",EventPic="" },
                new Tournment { TournamentID = 2, Name = "Winter Championship",EventPic="" }
            );

            // Seeding data for TrainingSession
            modelBuilder.Entity<TrainingSession>().HasData(
                new TrainingSession { SessionID = 1, AgeGroupID = 1, UserID = "123", CoachID = 1, InvoiceID = 1, Date = DateTime.Now ,DayOfWeek="1",Location="A"},
                new TrainingSession { SessionID = 2, AgeGroupID = 2, UserID = "143", CoachID = 2, InvoiceID = 2, Date = DateTime.Now,DayOfWeek="1",Location="B" }
            );

            // Seeding data for Match
            modelBuilder.Entity<Match>().HasData(
                new Match { MatchID = 1, Date = DateTime.Now, Player1ID = "123", Player2ID = "143", Score = "20", TournamentID = 1 }
            );

            modelBuilder.Entity<TrainingSession>()
       .HasOne(ts => ts.AgeGroup)
       .WithMany(ag => ag.TrainingSessions)
       .HasForeignKey(ts => ts.AgeGroupID)
       .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.User)
                .WithMany(u => u.TrainingSessions)
                .HasForeignKey(ts => ts.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.Coach)
                .WithMany(c => c.TrainingSessions)
                .HasForeignKey(ts => ts.CoachID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TrainingSession>()
                .HasOne(ts => ts.Invoice)
                .WithMany()
                .HasForeignKey(ts => ts.InvoiceID)
                .OnDelete(DeleteBehavior.Restrict);  // Prevent multiple cascade paths

            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.User)
                .WithMany(u => u.Invoices)
                .HasForeignKey(i => i.UserID)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid cycle issue


           modelBuilder.Entity<Match>()
           .HasOne(m => m.Player1)
              .WithMany()
          .HasForeignKey(m => m.Player1ID)
          .OnDelete(DeleteBehavior.Restrict);  // Avoid multiple cascade paths

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Player2)
                .WithMany()
                .HasForeignKey(m => m.Player2ID)
                .OnDelete(DeleteBehavior.Restrict);  // Avoid multiple cascade paths

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentID)
                .OnDelete(DeleteBehavior.Cascade);







        }

        private void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(

                new IdentityRole() { Name="Admin",ConcurrencyStamp="1",NormalizedName="Admin"},
                new IdentityRole() { Name="Coach",ConcurrencyStamp="2",NormalizedName="Coach"},
                new IdentityRole() { Name="Player",ConcurrencyStamp="3",NormalizedName="Player"}


             );
        }
    }
        


}

