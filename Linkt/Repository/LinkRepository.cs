using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace Linkt.Repository
{
    public class LinkRepository
    {
        private readonly IDynamoDBContext ddbContext;

        public LinkRepository(IDynamoDBContext ddbContext)
        {
            this.ddbContext = ddbContext;
        }

        public Task<List<LinkDto>> GetPage()
        {
            var search = ddbContext.ScanAsync<LinkDto>(null);
            return search.GetNextSetAsync();
        }

        public async Task<Result<LinkDto>> Get(Guid id)
        {
            return await ddbContext.LoadAsync<LinkDto>(id);
        }

        public Task Save(LinkDto link) => ddbContext.SaveAsync(link);

        public Task Delete(Guid id) => ddbContext.DeleteAsync<LinkDto>(id);
    }
}
