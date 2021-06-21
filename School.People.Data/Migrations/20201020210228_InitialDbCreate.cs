using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace School.People.Data.Migrations
{
    public partial class InitialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressIdsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    BirthAddressId = table.Column<Guid>(nullable: true),
                    ResidentialAddressId = table.Column<Guid>(nullable: true),
                    PermanentAddressId = table.Column<Guid>(nullable: true),
                    BusinessAddressId = table.Column<Guid>(nullable: true),
                    CommunityTaxCertificateIssuanceAddressId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressIdsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AgencyMemberDetailsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    AgencyId = table.Column<string>(maxLength: 16, nullable: true),
                    GsisIdNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PagIbigIdNumber = table.Column<string>(maxLength: 16, nullable: true),
                    PhilhealthNumber = table.Column<string>(maxLength: 16, nullable: true),
                    SssNumber = table.Column<string>(maxLength: 16, nullable: true),
                    Tin = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgencyMemberDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CharacterReferencesIdsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    ReferenceA = table.Column<Guid>(nullable: true),
                    ReferenceB = table.Column<Guid>(nullable: true),
                    ReferenceC = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterReferencesIdsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CitizenshipsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    DualCitizenshipMode = table.Column<string>(maxLength: 24, nullable: true),
                    DualCitizenship = table.Column<string>(maxLength: 64, nullable: true),
                    Country = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CitizenshipsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CivicWorksTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsOngoing = table.Column<bool>(nullable: false),
                    LocationAddressId = table.Column<Guid>(nullable: true),
                    PositionTitle = table.Column<string>(maxLength: 64, nullable: false),
                    EmployerOrganizationOrBusinessName = table.Column<string>(maxLength: 64, nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    TotalHoursWorked = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CivicWorksTable", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetailsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 64, nullable: true),
                    TelephoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    MobileNumber = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateOfBirthsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Birthdate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateOfBirthsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationsTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Level = table.Column<string>(maxLength: 32, nullable: false),
                    SchoolName = table.Column<string>(maxLength: 64, nullable: false),
                    DegreeCourse = table.Column<string>(maxLength: 64, nullable: false),
                    IfGraduatedYearGraduated = table.Column<string>(maxLength: 4, nullable: true),
                    IfNotGraduatedHighestLevelOrUnitsEarned = table.Column<string>(maxLength: 32, nullable: true),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    ScholarshipOrHonorsReceived = table.Column<string>(maxLength: 32, nullable: true),
                    IsOngoing = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationsTable", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "EligibilitiesTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    EligibilityName = table.Column<string>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    DateOfExamOrConferment = table.Column<DateTimeOffset>(nullable: true),
                    PlaceOfExamConferment = table.Column<Guid>(nullable: true),
                    LicenseNumberIfApplicable = table.Column<string>(nullable: true),
                    LicenseDateOfRelease = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EligibilitiesTable", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "FamilyIdsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    MotherId = table.Column<Guid>(nullable: true),
                    FatherId = table.Column<Guid>(nullable: true),
                    SpouseId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyIdsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FaqsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    IsRelatedToAuthorityThirdDegree = table.Column<bool>(nullable: false),
                    IsRelatedToAuthorityFourthDegree = table.Column<bool>(nullable: false),
                    RelationshipToAuthorityDetails = table.Column<string>(maxLength: 128, nullable: true),
                    IsGuiltyOfAdministrativeOffense = table.Column<bool>(nullable: false),
                    AdministrativeOffenseDetails = table.Column<string>(maxLength: 128, nullable: true),
                    WasCriminallyCharged = table.Column<bool>(nullable: false),
                    CriminalChargesFilingDate = table.Column<DateTimeOffset>(nullable: true),
                    CriminalChargesCaseStatus = table.Column<string>(maxLength: 128, nullable: true),
                    WasConvicted = table.Column<bool>(nullable: false),
                    ConvictionDetails = table.Column<string>(maxLength: 128, nullable: true),
                    WasSeparatedFromService = table.Column<bool>(nullable: false),
                    SeparationFromServiceDetails = table.Column<string>(maxLength: 128, nullable: true),
                    WasNatlOrLocalElectionCandidate = table.Column<bool>(nullable: false),
                    NatlOrLocalElectionCandidacyDetails = table.Column<string>(maxLength: 128, nullable: true),
                    HasResignedForCandidacy = table.Column<bool>(nullable: false),
                    ResignationForCandidacyDetails = table.Column<string>(maxLength: 128, nullable: true),
                    HasAcquiredImmigrantStatus = table.Column<bool>(nullable: false),
                    OriginCountry = table.Column<string>(maxLength: 64, nullable: true),
                    IsIndigenousGroupMember = table.Column<bool>(nullable: false),
                    IndigenousGroupMembershipDetails = table.Column<string>(maxLength: 128, nullable: true),
                    IsDifferentlyAbled = table.Column<bool>(nullable: false),
                    DifferentlyAbledIdNumber = table.Column<string>(maxLength: 16, nullable: true),
                    IsSoloParent = table.Column<bool>(nullable: false),
                    SoloParentIdNumber = table.Column<string>(maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaqsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImagesTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    RecentPhoto = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagesTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherInformationsTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(maxLength: 16, nullable: false),
                    DescriptiveName = table.Column<string>(maxLength: 64, nullable: false),
                    Details = table.Column<string>(maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherInformationsTable", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "PeopleTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 32, nullable: false),
                    NameExtension = table.Column<string>(maxLength: 16, nullable: true),
                    Title = table.Column<string>(maxLength: 16, nullable: true),
                    IsPersonnel = table.Column<bool>(nullable: false),
                    IsStudent = table.Column<bool>(nullable: false),
                    IsOther = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonDetailsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Sex = table.Column<string>(maxLength: 16, nullable: true),
                    CivilStatus = table.Column<string>(maxLength: 24, nullable: true),
                    OtherCivilStatus = table.Column<string>(maxLength: 24, nullable: true),
                    HeightInCentimeters = table.Column<double>(nullable: false),
                    WeightInKilograms = table.Column<double>(nullable: false),
                    BloodType = table.Column<string>(maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsOngoing = table.Column<bool>(nullable: false),
                    LocationAddressId = table.Column<Guid>(nullable: true),
                    TitleOfTrainingProgram = table.Column<string>(maxLength: 64, nullable: false),
                    DurationHours = table.Column<double>(nullable: false),
                    Sponsor = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsTable", x => x.Index);
                });

            migrationBuilder.CreateTable(
                name: "VerificationDetailsTable",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    CommunityTaxCertificateNumber = table.Column<string>(maxLength: 16, nullable: true),
                    CommunityTaxCertificateIssuanceDate = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerificationDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorksTable",
                columns: table => new
                {
                    Index = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    LastModifiedOn = table.Column<DateTimeOffset>(nullable: true),
                    LastModifiedBy = table.Column<Guid>(nullable: true),
                    Id = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTimeOffset>(nullable: true),
                    EndDate = table.Column<DateTimeOffset>(nullable: true),
                    IsOngoing = table.Column<bool>(nullable: false),
                    LocationAddressId = table.Column<Guid>(nullable: true),
                    PositionTitle = table.Column<string>(maxLength: 64, nullable: false),
                    EmployerOrganizationOrBusinessName = table.Column<string>(maxLength: 64, nullable: false),
                    TelephoneNumber = table.Column<string>(maxLength: 16, nullable: true),
                    MonthlySalary = table.Column<decimal>(nullable: false),
                    SalaryGradeAndStepIncrement = table.Column<string>(maxLength: 16, nullable: true),
                    StatusOfAppointment = table.Column<string>(maxLength: 24, nullable: true),
                    IsGovernmentService = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorksTable", x => x.Index);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressIdsTable");

            migrationBuilder.DropTable(
                name: "AgencyMemberDetailsTable");

            migrationBuilder.DropTable(
                name: "CharacterReferencesIdsTable");

            migrationBuilder.DropTable(
                name: "CitizenshipsTable");

            migrationBuilder.DropTable(
                name: "CivicWorksTable");

            migrationBuilder.DropTable(
                name: "ContactDetailsTable");

            migrationBuilder.DropTable(
                name: "DateOfBirthsTable");

            migrationBuilder.DropTable(
                name: "EducationsTable");

            migrationBuilder.DropTable(
                name: "EligibilitiesTable");

            migrationBuilder.DropTable(
                name: "FamilyIdsTable");

            migrationBuilder.DropTable(
                name: "FaqsTable");

            migrationBuilder.DropTable(
                name: "ImagesTable");

            migrationBuilder.DropTable(
                name: "OtherInformationsTable");

            migrationBuilder.DropTable(
                name: "PeopleTable");

            migrationBuilder.DropTable(
                name: "PersonDetailsTable");

            migrationBuilder.DropTable(
                name: "TrainingsTable");

            migrationBuilder.DropTable(
                name: "VerificationDetailsTable");

            migrationBuilder.DropTable(
                name: "WorksTable");
        }
    }
}
