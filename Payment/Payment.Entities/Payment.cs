using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Payments.Entities;

public class Payment
{
    [Key]
    public Guid Id { get; set; }
    [Required]
    public Guid OrderId { get; set; }
    [Required]
    [Column(TypeName = "VARCHAR(20)")]
    public Status Status { get; set; }
    [Required]
    [Column(TypeName = "VARCHAR(20)")]
    public TypePayment TypePayment { get; set; }
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Amount { get; set; }
}
