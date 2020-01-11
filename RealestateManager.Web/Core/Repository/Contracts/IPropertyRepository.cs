using System;
using System.Collections.Generic;
using System.Text;
using RealestateManager.Web.Core.Entities;

namespace RealestateManager.Web.Core.Repository.Contracts
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAll();
        Property GetById(int id);
        Property Add(Property property);
    }
}