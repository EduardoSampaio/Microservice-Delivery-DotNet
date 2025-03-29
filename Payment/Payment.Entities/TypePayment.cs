using System.ComponentModel.DataAnnotations;

namespace Payments.Entities;

public enum TypePayment
{
    [Display(Name = "Credit Card")]
    CreditCard,
    [Display(Name = "Debit Card")]
    DebitCard,
}
