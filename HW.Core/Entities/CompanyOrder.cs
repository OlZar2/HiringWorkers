namespace HW.Core.Entities;

public class CompanyOrder
{
    public Guid CompanyId { get; }

    public Company? Company { get; }

    public Guid OrderId { get; }

    public Order? Order { get; }
}