using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using static gRPCServer.StockServer;

namespace gRPCServer.Services
{
    public class StockService : StockServerBase
    {
        public Dictionary<string, int> Source = new Dictionary<string, int>()
        {
            {"Test1", 890 },
            {"Test2", 100 },
            {"Test3", 90 },
            {"Test4", 45 },
            {"Test5", 897 }
        };
        public override Task<StockResult> GetValueByName(ValueByNameRequest request, ServerCallContext context)
        {
            StockResult response = new StockResult
            {
                Value = Source[request.StockName],
                Name = request.StockName
            };


            return Task.FromResult(response);
        }

        public override Task<StockResponses> GetAllStockValues(
            Empty request, ServerCallContext context)
        {
            StockResponses response = new StockResponses();

            foreach (var key in Source)
            {
                response.Result.Add(new StockResult()
                {
                    Value = key.Value,
                    Name = key.Key
                }
                    );
            }

            return Task.FromResult(response);
        }
        public override async Task GetStockValue(
            ValueByNameRequest request,
            IServerStreamWriter<StockResult> responseStream,
            ServerCallContext context)
        {
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                await responseStream.WriteAsync(
                    new StockResult
                    {
                        Value = Source[request.StockName] ,
                        Name = request.StockName
                    }
                    );
                await Task.Delay(1000);
        }
    }
}
}
