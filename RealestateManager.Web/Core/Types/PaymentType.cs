using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using RealestateManager.Web.Core.Entities;

namespace RealestateManager.Web.Core.Types
{
    public class PaymentType : ObjectGraphType<Payment>
    {
        public PaymentType()
        {
            Field(x => x.Id);
            Field(x => x.Value);
            Field(x => x.DateCreated);
            Field(x => x.DateOverdue);
            Field(x => x.Paid);
        }
    }
}