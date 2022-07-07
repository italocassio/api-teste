using System;
using System.Collections.Generic;

namespace api_auction.Models
{
    public partial class TblUser
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime PwdUpdatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DisabledAt { get; set; }
        public bool? Enabled { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public string ResetToken { get; set; }
        public Guid Identifier { get; set; }
    }
}
