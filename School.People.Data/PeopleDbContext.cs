using Microsoft.EntityFrameworkCore;

namespace School.People.Data
{
    public class PeopleDbContext : DbContext
    {
        internal DbSet<DbPerson> People { get; set; }

        internal DbSet<DbPersonDetails> PersonDetails { get; set; }
        internal DbSet<DbFamilyIds> FamilyIds { get; set; }
        internal DbSet<DbEducation> Educations { get; set; }
        internal DbSet<DbEligibility> Eligibilities { get; set; }
        internal DbSet<DbWork> Works { get; set; }
        internal DbSet<DbCivicWork> CivicWorks { get; set; }
        internal DbSet<DbTraining> Trainings { get; set; }
        internal DbSet<DbOtherInformation> OtherInformations { get; set; }
        internal DbSet<DbFaqs> Faqs { get; set; }
        internal DbSet<DbCharacterReferencesIds> CharacterReferencesIds { get; set; }
        internal DbSet<DbVerificationDetails> VerificationDetails { get; set; }

        internal DbSet<DbAgencyMemberDetails> AgencyMemberDetails { get; set; }
        internal DbSet<DbDateOfBirth> DateOfBirths { get; set; }
        internal DbSet<DbContactDetails> ContactDetails { get; set; }
        internal DbSet<DbCitizenship> Citizenships { get; set; }
        internal DbSet<DbAddressIds> AddressIds { get; set; }
        internal DbSet<DbIdPicture> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbPerson>().ToTable(Properties.Resources.PersonTableName);

            modelBuilder.Entity<DbPersonDetails>().ToTable(Properties.Resources.PersonDetailsTableName);
            modelBuilder.Entity<DbFamilyIds>().ToTable(Properties.Resources.FamilyIdsTableName);
            modelBuilder.Entity<DbEducation>().ToTable(Properties.Resources.EducationTableName);
            modelBuilder.Entity<DbEligibility>().ToTable(Properties.Resources.EligibilityTableName);
            modelBuilder.Entity<DbWork>().ToTable(Properties.Resources.WorkTableName);
            modelBuilder.Entity<DbCivicWork>().ToTable(Properties.Resources.CivicWorkTableName);
            modelBuilder.Entity<DbTraining>().ToTable(Properties.Resources.TrainingTableName);
            modelBuilder.Entity<DbOtherInformation>().ToTable(Properties.Resources.OtherInformationTableName);
            modelBuilder.Entity<DbFaqs>().ToTable(Properties.Resources.FaqsTableName);
            modelBuilder.Entity<DbCharacterReferencesIds>().ToTable(Properties.Resources.CharacterReferencesIdsTableName);
            modelBuilder.Entity<DbVerificationDetails>().ToTable(Properties.Resources.VerificationDetailsTableName);

            modelBuilder.Entity<DbAgencyMemberDetails>().ToTable(Properties.Resources.AgencyMemberDetailsTableName);
            modelBuilder.Entity<DbDateOfBirth>().ToTable(Properties.Resources.DateOfBirthTableName);
            modelBuilder.Entity<DbContactDetails>().ToTable(Properties.Resources.ContactDetailsTableName);
            modelBuilder.Entity<DbCitizenship>().ToTable(Properties.Resources.CitizenshipTableName);
            modelBuilder.Entity<DbAddressIds>().ToTable(Properties.Resources.AddressIdsTableName);
            modelBuilder.Entity<DbIdPicture>().ToTable(Properties.Resources.ImageTableName);
        }

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options)
            : base(options) { }
    }
}
