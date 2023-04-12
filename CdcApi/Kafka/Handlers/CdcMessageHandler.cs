using EventBus.Kafka.Abstraction.Abstraction;

namespace EventBus.Kafka.KafkaHandlers
{
    public class CdcMessageHandler : IMessageHandler<string>
    {
        public async Task HandleAsync(string message)
        {
            //does nothing, added to see content of a message devezium puts into kafka
            var mes = message;    
        }
    }

}
