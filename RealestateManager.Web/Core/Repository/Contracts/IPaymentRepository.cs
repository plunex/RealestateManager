using System;
using System.Collections.Generic;
using System.Text;
using RealestateManager.Web.Core.Entities;

namespace RealestateManager.Web.Core.Repository.Contracts
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAllForProperty(int propertyId);
        IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount);

    }
}