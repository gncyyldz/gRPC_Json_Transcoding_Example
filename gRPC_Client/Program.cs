using Grpc.Net.Client;
using gRPC_Client;

#region Message Client
//var channel = GrpcChannel.ForAddress("https://localhost:7018");
//var messageClient = new Message.MessageClient(channel);
//var response = messageClient.SendMessage(new() { Text = "Mesajlar alınamaya başlıyor." });

//CancellationTokenSource cancellationToken = new();
//await Task.Run(async () =>
//{
//    while (await response.ResponseStream.MoveNext(cancellationToken.Token))
//        Console.WriteLine($"-> {response.ResponseStream.Current.Text}");
//});
#endregion
#region Person Client
var channel = GrpcChannel.ForAddress("https://localhost:7018");
var personClient = new Person.PersonClient(channel);
var response = await personClient.CreatePersonAsync(new() { Name = "Gençay", Surname = "Yıldız" });
Console.WriteLine(response.Message);
#endregion