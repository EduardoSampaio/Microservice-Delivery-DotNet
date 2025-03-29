using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Payments.Entities;

namespace Payments.Data.Repository;

public interface IPaymentRepository
{
    Task<Payment> GetPaymentByIdAsync(Guid id);
    Task<IEnumerable<Payment>> GetPaymentsAsync();
    Task CreatePaymentAsync(Payment payment);
    Task UpdatePaymentAsync(Payment payment);
    Task DeletePaymentAsync(Guid id);
    Task<Payment> GetPaymentByOrderIdAsync(Guid id);
}
