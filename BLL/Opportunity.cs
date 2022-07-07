using api_auction._Base;
using api_auction.Data.Opportunity;
using api_auction.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api_auction.BLL
{
    public class Opportunity
    {
        public static async Task<GetOpportunities> ListAllOportunities(JaspionDbContext context, IOpportunityRepository pOpportunityRepo)
        {
           
            using (var transaction = context.Database.BeginTransaction())
            {   
               
                var opportunities = await pOpportunityRepo.GetAllFromAccountsWithStatus(context);

                GetOpportunities pResult = new GetOpportunities();
                pResult.Total = opportunities.Count;

                List<Auction> pAuctions = new List<Auction>();
                foreach (Opportunity.GetAllFromAccountsWithStatusObject pOpportunity in opportunities)
                {
                    pAuctions.Add(new Auction()
                    {
                        Account = pOpportunity.opportunity.Account,
                        AuctionDate = pOpportunity.opportunity.AuctionDate,
                        AuctionDescription = pOpportunity.opportunity.AuctionDescription,
                        AuctionMode = pOpportunity.opportunity.AuctionMode,
                        AuctionNumber = pOpportunity.opportunity.AuctionNumber,
                        AuctionType = pOpportunity.opportunity.AuctionType,
                        BuyerUnit = pOpportunity.opportunity.BuyerUnit,
                        Portal = pOpportunity.opportunity.Portal,
                        PublishDate = pOpportunity.opportunity.PublishDate,
                        TargetClient = pOpportunity.opportunity.TargetClient,
                        TargetOperational = pOpportunity.opportunity.TargetOperational,
                        TargetProposal = pOpportunity.opportunity.TargetProposal,
                        AuctionStatusFlow = pOpportunity.statusName,
                        HasAttachment = pOpportunity.hasAttachment,
                        HasAnswers = pOpportunity.hasAnswer,
                        AlternativeAuctionNumber = pOpportunity.alternativeAuctionNumber
                    });
                }

                pResult.Auctions = pAuctions.ToArray();

                return pResult;
                         
            }
        }

        public static async Task<ActionResult> GetOpportunityDetails(JaspionDbContext context, IOpportunityRepository opportunityRepository, string account, string buyerUnit, string auctionNumber, string portal)
        {
            RuleValidator.New()
                   .When(string.IsNullOrWhiteSpace(account), "Necessário campo accout")
                   .When(string.IsNullOrWhiteSpace(buyerUnit), "Necessário campo buyer_unit")
                   .When(string.IsNullOrWhiteSpace(auctionNumber), "Necessário campo auction_number")
                   .When(string.IsNullOrWhiteSpace(portal), "Necessário campo portal")
                   .ThrowExceptionIfExists();

            using (var transaction = context.Database.BeginTransaction())
            {
                var opportunity = await opportunityRepository.GetOpportunity(context, account, auctionNumber, buyerUnit, portal);
              
                if (opportunity == null)
                    throw new DomainException(new List<string>() { "Oportunidade não encontrada"});

                List<FinalItem> finalItems =  JsonSerializer.Deserialize<List<FinalItem>>(opportunity.ItemsOdin);
               
               return new OkObjectResult(finalItems);
            }
            
        }

        public class GetAllFromAccountsWithStatusObject
        {
            public TblOpportunity opportunity { get; set; }
            public string alternativeAuctionNumber { get; set; }
            public string statusName { get; set; }
            public bool hasAttachment { get; set; }
            public bool hasAnswer { get; set; }

        }
        
    }
}