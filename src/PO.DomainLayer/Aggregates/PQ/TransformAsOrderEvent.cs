using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PQ
{
    // Farklı aggregateler arasında veri taşımak amaçlı kullandığımız nesneler.
    public record TransformAsOrderEvent(Guid PurchaseRequestId, Guid PurchaseQuoteId) : INotification;

}
