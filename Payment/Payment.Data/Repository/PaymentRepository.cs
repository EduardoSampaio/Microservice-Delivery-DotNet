using Payments.Data.Data;
using Payments.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using BuildingBlocks.Exceptions;

namespace Payments.Data.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;

    public PaymentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Payment> GetPaymentByIdAsync(Guid id)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(p => p.Id == id) ?? throw new EntityNotFoundException();
    }

    public async Task<IEnumerable<Payment>> GetPaymentsAsync()
    {
        return await _context.Payments.ToListAsync();
    }

    public async Task CreatePaymentAsync(Payment payment)
    {
        await _context.Payments.AddAsync(payment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdatePaymentAsync(Payment payment)
    {
        _context.Payments.Update(payment);
        await _context.SaveChangesAsync();
    }

    public async Task DeletePaymentAsync(Guid id)
    {
        var payment = await _context.Payments.FindAsync(id) ?? throw new EntityNotFoundException();
      
       _context.Payments.Remove(payment);
       await _context.SaveChangesAsync();
        
    }

    public async Task<Payment> GetPaymentByOrderIdAsync(Guid id)
    {
        return await _context.Payments
            .FirstOrDefaultAsync(p => p.OrderId == id) ?? throw new EntityNotFoundException();
    }
}
