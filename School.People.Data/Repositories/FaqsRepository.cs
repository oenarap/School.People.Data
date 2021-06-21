using System;
using System.Linq;
using System.Threading.Tasks;
using School.People.Core.Attributes;
using School.People.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace School.People.Data.Repositories
{
    public class FaqsRepository : Repository<IFaqs, PeopleDbContext>, IFaqsRepository
    {
        public async Task<IFaqs> ReadAsync(Guid id)
        {
            try
            {
                var faqs = await Context.Faqs.Where(a => a.Id == id).FirstOrDefaultAsync().ConfigureAwait(false);
                return faqs;
            }
            catch
            {
                // TODO: log exception
                return null;
            }
        }

        public async Task<bool> UpdateAsync(IFaqs item)
        {
            try
            {
                var faqs = await Context.Faqs.Where(f => f.Id == item.Id).FirstOrDefaultAsync().ConfigureAwait(false);
                if (faqs != null)
                {
                    faqs.IsRelatedToAuthorityThirdDegree = item.IsRelatedToAuthorityThirdDegree;
                    faqs.IsRelatedToAuthorityFourthDegree = item.IsRelatedToAuthorityFourthDegree;
                    faqs.RelationshipToAuthorityDetails = item.RelationshipToAuthorityDetails;
                    faqs.IsGuiltyOfAdministrativeOffense = item.IsGuiltyOfAdministrativeOffense;
                    faqs.AdministrativeOffenseDetails = item.AdministrativeOffenseDetails;
                    faqs.WasCriminallyCharged = item.WasCriminallyCharged;
                    faqs.CriminalChargesFilingDate = item.CriminalChargesFilingDate;
                    faqs.CriminalChargesCaseStatus = item.CriminalChargesCaseStatus;
                    faqs.WasConvicted = item.WasConvicted;
                    faqs.ConvictionDetails = item.ConvictionDetails;
                    faqs.WasSeparatedFromService = item.WasSeparatedFromService;
                    faqs.SeparationFromServiceDetails = item.SeparationFromServiceDetails;
                    faqs.WasNatlOrLocalElectionCandidate = item.WasNatlOrLocalElectionCandidate;
                    faqs.NatlOrLocalElectionCandidacyDetails = item.NatlOrLocalElectionCandidacyDetails;
                    faqs.HasResignedForCandidacy = item.HasResignedForCandidacy;
                    faqs.ResignationForCandidacyDetails = item.ResignationForCandidacyDetails;
                    faqs.HasAcquiredImmigrantStatus = item.HasAcquiredImmigrantStatus;
                    faqs.OriginCountry = item.OriginCountry;
                    faqs.IsIndigenousGroupMember = item.IsIndigenousGroupMember;
                    faqs.IndigenousGroupMembershipDetails = item.IndigenousGroupMembershipDetails;
                    faqs.IsDifferentlyAbled = item.IsDifferentlyAbled;
                    faqs.DifferentlyAbledIdNumber = item.DifferentlyAbledIdNumber;
                    faqs.IsSoloParent = item.IsSoloParent;
                    faqs.SoloParentIdNumber = item.SoloParentIdNumber;
                    faqs.LastModifiedOn = DateTimeOffset.Now;
                }
                else if (item.Id != Guid.Empty)
                {
                    faqs = new DbFaqs()
                    {
                        Id = item.Id,
                        IsRelatedToAuthorityThirdDegree = item.IsRelatedToAuthorityThirdDegree,
                        IsRelatedToAuthorityFourthDegree = item.IsRelatedToAuthorityFourthDegree,
                        RelationshipToAuthorityDetails = item.RelationshipToAuthorityDetails,
                        IsGuiltyOfAdministrativeOffense = item.IsGuiltyOfAdministrativeOffense,
                        AdministrativeOffenseDetails = item.AdministrativeOffenseDetails,
                        WasCriminallyCharged = item.WasCriminallyCharged,
                        CriminalChargesFilingDate = item.CriminalChargesFilingDate,
                        CriminalChargesCaseStatus = item.CriminalChargesCaseStatus,
                        WasConvicted = item.WasConvicted,
                        ConvictionDetails = item.ConvictionDetails,
                        WasSeparatedFromService = item.WasSeparatedFromService,
                        SeparationFromServiceDetails = item.SeparationFromServiceDetails,
                        WasNatlOrLocalElectionCandidate = item.WasNatlOrLocalElectionCandidate,
                        NatlOrLocalElectionCandidacyDetails = item.NatlOrLocalElectionCandidacyDetails,
                        HasResignedForCandidacy = item.HasResignedForCandidacy,
                        ResignationForCandidacyDetails = item.ResignationForCandidacyDetails,
                        HasAcquiredImmigrantStatus = item.HasAcquiredImmigrantStatus,
                        OriginCountry = item.OriginCountry,
                        IsIndigenousGroupMember = item.IsIndigenousGroupMember,
                        IndigenousGroupMembershipDetails = item.IndigenousGroupMembershipDetails,
                        IsDifferentlyAbled = item.IsDifferentlyAbled,
                        DifferentlyAbledIdNumber = item.DifferentlyAbledIdNumber,
                        IsSoloParent = item.IsSoloParent,
                        SoloParentIdNumber = item.SoloParentIdNumber,
                        CreatedOn = DateTimeOffset.Now
                    };
                    await Context.Faqs.AddAsync(faqs);
                }
                return await Context.SaveChangesAsync() > 0;
            }
            catch
            {
                // TODO: log exception
                return false;
            }
        }

        public FaqsRepository(PeopleDbContext context)
            : base(context) { }
    }
}
