using System;
using System.Collections.Generic;

namespace api_auction.Models
{
    public partial class TblOpportunity
    {
        public long Id { get; set; }
        public string BuyerUnit { get; set; }
        public string AuctionNumber { get; set; }
        public string Account { get; set; }
        public string Portal { get; set; }
        public string ItemsOdin { get; set; }
        public string Answers { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string AuctionPropertiesOdin { get; set; }
        public bool Declined { get; set; }
        public string AuctionMode { get; set; }
        public string AuctionType { get; set; }
        public string AuctionDescription { get; set; }
        public DateTime TargetProposal { get; set; }
        public DateTime? TargetOperational { get; set; }
        public DateTime? TargetClient { get; set; }
        public DateTime AuctionDate { get; set; }
        public string Observatrion { get; set; }
        public DateTime InitialTargetProposal { get; set; }
    }
}
