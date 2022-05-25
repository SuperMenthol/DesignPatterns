using ProgramNamespace.Abstracts;
using ProgramNamespace.Dto;
using ProgramNamespace.Enums;

namespace ProgramNamespace.Commands
{
    public class PurchaseConfirmationCommand : BaseCommand
    {
        protected override bool _isValidForOperation => _sourceDocument.ConfirmedByCustomer is false;

        protected override OperationStatus _successStatus => OperationStatus.AcceptedOnWebsite;
        protected override OperationStatus _failureStatus => OperationStatus.ErrorAcceptance;

        public PurchaseConfirmationCommand(PurchasingDocumentDto document) : base(document) 
        {
            if (!_isValidForOperation)
            {
                DocumentAfterOperation.OperationStatus = (int)_successStatus;
            }
        }

        public override void Execute()
        {
            if (_isValidForOperation)
            {
                try
                {
                    DocumentAfterOperation.ConfirmedByCustomer = true;
                    DocumentAfterOperation.OperationStatus = (int)_successStatus;
                }
                catch (Exception ex)
                {
                    // log exception here
                    Revert();
                    DocumentAfterOperation.OperationStatus = (int)_failureStatus;
                }
            }
        }

        public override void Revert()
        {
            DocumentAfterOperation = _sourceDocument;
        }
    }
}