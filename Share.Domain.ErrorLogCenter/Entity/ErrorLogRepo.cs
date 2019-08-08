using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Share.Domain.ErrorLogCenter.Entity
{
    /// <summary>
    /// errorlog
    /// </summary>
    [BsonIgnoreExtraElements]
    public class ErrorLogRepo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("ErrorContent")]
        public string ErrorContent { get; set; }
        [BsonElement("ErrorTime")]
        public DateTime ErrorTime { get; set; }
        [BsonElement("OperatorId")]
        public string OperatorId { get; set; }
    }
}
