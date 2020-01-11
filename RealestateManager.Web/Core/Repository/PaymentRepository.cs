using System.Collections.Generic;
using System.Linq;
using RealestateManager.Web.Core.Entities;
using RealestateManager.Web.Core.Repository.Contracts;

namespace RealestateManager.Web.Core.Repository
{
    public class PaymentRepository: IPaymentRepository
    {
        private readonly RealEstateContext _db;

        public PaymentRepository(RealEstateContext db)
        {
            _db = db;
        }

        public IEnumerable<Payment> GetAllForProperty(int propertyId)
        {
            return _db.Payments.Where(x => x.PropertyId == propertyId);
        }
        public IEnumerable<Payment> GetAllForProperty(int propertyId, int lastAmount)
        {
            return _db.Payments.Where(x => x.PropertyId == propertyId)
                .OrderByDescending(x => x.DateCreated)
                .Take(lastAmount);
        }
    }
}
