using System;
using System.Collections.Generic;

namespace App.DataAccess.DbModels
{
    public partial class RefreshToken
    {
        public int Id { get; set; }
        public DateTime? IssuedUtc { get; set; }
        public DateTime? ExpiresUtc { get; set; }
        public string Token { get; set; }
        public string UserId { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string CreatedUsedId { get; set; }
        public DateTimeOffset? UpdatedDateTime { get; set; }
        public string UpdatedUserId { get; set; }
    }
}
