namespace HW.Core.Entities;

public class CandidateOrder
{
    public Guid CandidateId { get; }

    public Account? Candidate { get; }

    public Guid OrderId { get; }

    public Order? Order { get; }

    public DateTime CreatedAt { get; }
}