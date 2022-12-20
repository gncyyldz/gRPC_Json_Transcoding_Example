using Grpc.Core;
using gRPC_Server;

namespace gRPC_Server.Services
{
    public class MessageService : Message.MessageBase
    {
        private readonly ILogger<MessageService> _logger;
        public MessageService(ILogger<MessageService> logger)
        {
            _logger = logger;
        }

        public override async Task SendMessage(MessageRequest request, IServerStreamWriter<MessageReply> responseStream, ServerCallContext context)
        {
            Console.WriteLine(request.Text);
            Random random = new();
            await Task.Run(async () =>
            {
                while (true)
                {
                    await responseStream.WriteAsync(new() { Text = (random.Next() * random.Next()).ToString() });
                    await Task.Delay(1000);
                }
            });
        }
    }
}