using ProgramNamespace.Dto;
using ProgramNamespace.Enums;
using ProgramNamespace.Interfaces;

namespace ProgramNamespace.Abstracts
{
    public abstract class BaseCommand : ICommand
    {
        public BaseCommand(PurchasingDocumentDto dto)
        {
            _sourceDocument = dto;
            DocumentAfterOperation = new PurchasingDocumentDto(dto);
        }
        protected PurchasingDocumentDto _sourceDocument { get; private set; }
        public PurchasingDocumentDto DocumentAfterOperation { get; protected set; }
        protected abstract OperationStatus _successStatus { get; }
        protected abstract OperationStatus _failureStatus { get; }

        protected abstract bool _isValidForOperation { get; }
        public abstract void Execute();
        public abstract void Revert();
    }
}