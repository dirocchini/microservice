namespace Rocchini.Common.Events.Interfaces
{
    public interface IRejectedEvent : IEvent
    {
        string Reason { get; }
        string Code { get; }
    }
}
