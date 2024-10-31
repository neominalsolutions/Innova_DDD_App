﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PO
{
  public record PurchaseOrderCanceled(Guid PurchaseRequestId):INotification;
 
}
