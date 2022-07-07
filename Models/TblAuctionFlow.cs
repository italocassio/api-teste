using System;
using System.Collections.Generic;

namespace api_auction.Models
{
    public partial class TblAuctionFlow
    {
        public long Id { get; set; }
        public string AuctionNumber { get; set; }
        public string BuyerUnit { get; set; }
        public string Account { get; set; }
        public string Portal { get; set; }
        public string StatusName { get; set; }
        public string PublishAuctionStateInitials { get; set; }
        public string AuctionConfig { get; set; }
        public DateTime CreatedAt { get; set; }
        public string LastUsernameModifier { get; set; }
        public string AltAuctionNumber { get; set; }
    }
}
