namespace Trade.Domain.Interfaces
{
    public interface ITrade
    {
        decimal Value { get; }
        string ClientSector { get; }
    }
}