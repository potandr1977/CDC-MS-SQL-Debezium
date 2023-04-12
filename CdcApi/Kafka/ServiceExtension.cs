using EventBus.Kafka.Abstraction.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace EventBus.Kafka.Abstraction
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddKafkaConsumer<TMessage, TMessageHandler>(
            this IServiceCollection serviceCollection,
            string TopicName,
            string GroupdId) where TMessage : class where TMessageHandler : class, IMessageHandler<TMessage>
        {
            serviceCollection.AddSingleton<IMessageHandler<TMessage>, TMessageHandler>();

            var consumer = new KafkaConsumer<string, TMessage>(
                GroupdId,
                TopicName,
                 (key,value) => {
                    var messageHandler = serviceCollection.BuildServiceProvider().GetRequiredService<IMessageHandler<TMessage>>();
                    
                    messageHandler.HandleAsync(value);
                });

            CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            consumer.Consume(token);

            return serviceCollection;
        }

    }
}
