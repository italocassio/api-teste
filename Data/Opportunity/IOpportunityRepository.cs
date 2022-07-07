using System.Collections.Generic;
using System.Threading.Tasks;
using api_auction._Base;
using api_auction.Models;
using static api_auction.BLL.Opportunity;

namespace api_auction.Data.Opportunity
{
    public interface IOpportunityRepository : IRepository<TblOpportunity>
    {
       Task<List<GetAllFromAccountsWithStatusObject>> GetAllFromAccountsWithStatus(JaspionDbContext Context);
       Task<TblOpportunity> GetOpportunity(JaspionDbContext Context, string account, string auctionNumber, string buyerUnit, string portal);
    }
}