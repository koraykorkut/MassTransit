using MassTransit;
using MessageContracts;
using System;
using System.Threading.Tasks;

namespace MasstransitGrpcConsumerSample
{
    public class EventMessageConsumer : IConsumer<Message>
    {
        public async Task Consume(ConsumeContext<Message> context)
        {
            Console.WriteLine("Consumer Started");
            var message = context.Message;
            await Console.Out.WriteLineAsync($"Message from Producer : {message.Text}");
            // Do something useful with the message
            Console.WriteLine("Consumer Ended");
        }
    }
}
