namespace EventBus.Kafka.Abstraction.Abstraction
{
    public interface IMessageHandler<TMessage>
    {
        Task HandleAsync(TMessage message);
    }
}
