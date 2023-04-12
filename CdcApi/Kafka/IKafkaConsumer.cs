namespace EventBus.Kafka.Abstraction
{
    public interface IKafkaConsumer<TMessage>
    {
        Task Consume(CancellationToken cancellationToken);

        Task Consume(int? partition, int? offset, CancellationToken stoppingToken);
    }
}
