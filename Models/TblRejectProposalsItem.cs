using System;
using System.Collections.Generic;

namespace api_auction.Models
{
    public partial class TblRejectProposalsItem
    {
        public long Id { get; set; }
        public string AuctionNumber { get; set; }
        public string WhoReject { get; set; }
        public string UserEmailReject { get; set; }
        public string Portal { get; set; }
        public string Observation { get; set; }
        public string AuctionItemNumber { get; set; }
        public string AuctionGroupNumber { get; set; }
        public string RejectCategory { get; set; }
        public string Account { get; set; }
        public DateTime CreatedAt { get; set; }
        public string BuyerUnit { get; set; }
    }
}
