using TechMart.Domain.Entities.Base;
using TechMart.Domain.Enums;

namespace TechMart.Domain.Entities;

public class Payment : BaseEntity
{
    public int OrderId { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal Amount { get; set; }

    public string? TransactionId { get; set; }
    public string? PaymentGateway { get; set; }
    public string? AuthorizationCode { get; set; }
    public DateTime? PaymentDate { get; set; }

    public Order? Order { get; set; }
}