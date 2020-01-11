
using System.Collections.Generic;
using System.Linq;
using RealestateManager.Web.Core.Entities;
using RealestateManager.Web.Core.Repository.Contracts;

namespace RealestateManager.Web.Core.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly RealEstateContext _db;

        public PropertyRepository(RealEstateContext db)
        {
            _db = db;
        }

        public IEnumerable<Property> GetAll()
        {
            return _db.Properties;
        }

        public Property GetById(int id)
        {
            return _db.Properties.SingleOrDefault(x => x.Id == id);
        }

        public Property Add(Property property)
        {
            _db.Properties.Add(property);
            _db.SaveChanges();
            return property;
        }
    }
}
