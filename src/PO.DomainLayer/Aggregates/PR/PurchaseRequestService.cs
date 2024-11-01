using Innova.Infra.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PO.DomainLayer.Aggregates.PR
{
  public class PurchaseRequestService
  {

    private readonly IUnitOfWork unitOfWork;
    private readonly IPurchaseRequestRepository purchaseRequestRepository;

    public PurchaseRequestService(IUnitOfWork unitOfWork, IPurchaseRequestRepository purchaseRequestRepository)
    {
      this.unitOfWork = unitOfWork;
      this.purchaseRequestRepository = purchaseRequestRepository;
    }

    public void Create(PurchaseRequest purchaseRequest)
    {
      purchaseRequestRepository.Add(purchaseRequest);
      this.unitOfWork.Commit();
    }


  }
}
