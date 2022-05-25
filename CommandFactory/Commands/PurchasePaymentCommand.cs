using ProgramNamespace.Abstracts;
using ProgramNamespace.Dto;
using ProgramNamespace.Enums;

namespace ProgramNamespace.Commands
{
    public class PurchasePaymentCommand : BaseCommand
    {
        private FakeData _data;
        protected override bool _isValidForOperation => _sourceDocument.PaymentId is null;

        protected override OperationStatus _successStatus => OperationStatus.PaidByCustomer;
        protected override OperationStatus _failureStatus => OperationStatus.ErrorPayment;

        public PurchasePaymentCommand(PurchasingDocumentDto document) : base(document) 
        {
            _data = new FakeData();
            if (!_isValidForOperation)
            {
                DocumentAfterOperation.OperationStatus = (int)_successStatus;
            }
        }

        public override void Execute()
        {
            try
            {
                var paymentGuid = _data.PaymentInformation.Where(x => x.OrderId == _sourceDocument.Id).FirstOrDefault();

                if (paymentGuid is null)
                {
                    return;
                }

                DocumentAfterOperation.PaymentId = paymentGuid.PaymentId;
                DocumentAfterOperation.OperationStatus = (int)_successStatus;
            }
            catch (Exception ex)
            {
                DocumentAfterOperation.OperationStatus = (int)_failureStatus;
            }
        }

        public override void Revert()
        {
            DocumentAfterOperation = _sourceDocument;
        }
    }
}