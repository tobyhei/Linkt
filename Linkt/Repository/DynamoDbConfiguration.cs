using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.DependencyInjection;

namespace Linkt.Repository
{
    public static class DynamoDbConfiguration
    {
        public static void ConfigureDynamoDb(this IServiceCollection services, bool isDebug)
        {
            var tableName = Environment.GetEnvironmentVariable("LinkTable");
            AWSConfigsDynamoDB.Context.TypeMappings[typeof(LinkDto)] =
                new Amazon.Util.TypeMapping(typeof(LinkDto), tableName);

            var dbConfig = new AmazonDynamoDBConfig();

            if (isDebug)
            {
                //TODO parametrize
                dbConfig = new AmazonDynamoDBConfig
                {
                    RegionEndpoint = RegionEndpoint.APSoutheast2,
                    ServiceURL = "http://localhost:8000"
                };
            }

            var client = new AmazonDynamoDBClient(dbConfig);
            var config = new DynamoDBContextConfig { Conversion = DynamoDBEntryConversion.V2 };
            var ddbContext = new DynamoDBContext(client, config);

            services.AddSingleton<IDynamoDBContext>(ddbContext);
        }
    }
}