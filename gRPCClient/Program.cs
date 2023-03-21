using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using gRPCClient;

// create channel
GrpcChannel channel = GrpcChannel.ForAddress("http://localhost:5198");

// create client
//var client = new Greeter.GreeterClient(channel);

//HelloRequest request = new HelloRequest() { Name = "Dilakshan" };
//HelloReply response = client.SayHello(request);

//Console.WriteLine(response.Message);


// create client
var client = new StockServer.StockServerClient(channel);


// method 1
ValueByNameRequest request = new ValueByNameRequest() { StockName = "Test1" };
StockResult response = client.GetValueByName(request);

Console.WriteLine(string.Format("Stock {0} value is {1}", response.Name, response.Value));

// method 2
//var reply = client.GetAllStockValues(new Empty());

//foreach (var stResult in reply.Result)
//{

//    Console.WriteLine(string.Format("Stock {0} value is {1}", stResult.Name, stResult.Value));
//}

// method 3
//ValueByNameRequest streamRequest = new ValueByNameRequest() { StockName = "Test2" };
//var response1 = client.GetStockValue(streamRequest);

//while (await response1.ResponseStream.MoveNext())
//{
//    Console.WriteLine(string.Format("Stock {0} value is {1} on {2}",
//        response1.ResponseStream.Current.Name,
//        response1.ResponseStream.Current.Value,
//        DateTime.Now.ToString()));
//}

Console.WriteLine("gRPC Call Completed!!!");

// call the service
Console.ReadLine();