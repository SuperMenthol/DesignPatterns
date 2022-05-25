using ProgramNamespace.Abstracts;
using ProgramNamespace.Commands;
using ProgramNamespace.Dto;
using ProgramNamespace.Enums;
using ProgramNamespace.Interfaces;

namespace ProgramNamespace
{
    public class CommandFactory : ICommandFactory
    {
        public BaseCommand GenerateCommand(PurchasingDocumentDto dto)
        {
            switch (dto.OperationStatus)
            {
                case (int)OperationStatus.New:
                    return new PurchaseConfirmationCommand(dto);
                case (int)OperationStatus.AcceptedOnWebsite:
                    return new PurchasePaymentCommand(dto);
                case (int)OperationStatus.PaidByCustomer:
                    return new WarehouseConfirmationCommand(dto);
                default:
                    return null;
            }
        }
    }
}