using api_auction.Models;
using Microsoft.EntityFrameworkCore;
using static api_auction.BLL.Opportunity;

namespace api_auction.Data.Opportunity
{
    public class OpportunityRepository : IOpportunityRepository
    {
        public async Task<List<GetAllFromAccountsWithStatusObject>> GetAllFromAccountsWithStatus(JaspionDbContext Context)
        {
            var pReturn = await (from f in Context.TblAuctionFlow
                                 join o in Context.TblOpportunity
                                 on new { f.AuctionNumber, f.BuyerUnit, f.Account }
                                 equals new { o.AuctionNumber, o.BuyerUnit, o.Account }                                
                                 orderby o.TargetProposal ascending
                                 select new { o, f.AltAuctionNumber, f.StatusName }).ToListAsync();

            var groupsOpportunities = pReturn.GroupBy(opportunity => new { opportunity.o.AuctionNumber, opportunity.o.BuyerUnit });

            List<GetAllFromAccountsWithStatusObject> pReturnList = new List<GetAllFromAccountsWithStatusObject>();

            bool file = true;
            bool answer = true;
            
            foreach (dynamic groupOpp in groupsOpportunities)
            {
                foreach (dynamic pOpp in groupOpp)
                {
                    
                   
                    pReturnList.Add(new GetAllFromAccountsWithStatusObject()
                    {
                        opportunity = pOpp.o,
                        alternativeAuctionNumber = pOpp.AltAuctionNumber,
                        statusName = pOpp.StatusName,
                        hasAttachment = file,
                        hasAnswer = answer,
                    });
                    break;
                }

                file = !file;
                answer = !answer;
            }


            return pReturnList;
        }

        public async Task<TblOpportunity> GetOpportunity(JaspionDbContext Context, string account, string auctionNumber, string buyerUnit, string portal)
        {
            return await Context.Set<TblOpportunity>().Where(x => x.Account == account && x.AuctionNumber == auctionNumber && x.BuyerUnit == buyerUnit && x.Portal == portal).FirstOrDefaultAsync();
        }
    }
}