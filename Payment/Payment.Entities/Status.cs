using System.ComponentModel.DataAnnotations;

namespace Payments.Entities;

public enum Status
{
    [Display(Name = "Awaiting Approval")]
    Pending = 1,

    [Display(Name = "Confirmed")]
    Approved = 2,

    [Display(Name = "Declined")]
    Rejected = 3
}
