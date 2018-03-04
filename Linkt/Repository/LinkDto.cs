using System;
using Amazon.DynamoDBv2.DataModel;

namespace Linkt.Repository
{
    public class LinkDto
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }

        public Guid CollectionId { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public DateTime Timestamp { get; set; }

        public Link.Domain.Link ToDomainObject() => new Link.Domain.Link(Id, CollectionId, Url, Description, Timestamp);

        public static LinkDto FromDomainObject(Link.Domain.Link l)
        {
            return new LinkDto
            {
                Id = l.Id, CollectionId = l.CollectionId, Description = l.Description,
                Timestamp = l.Timestamp, Url = l.Url
            };
        }
    }
}