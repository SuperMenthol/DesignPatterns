using ProgramNamespace.Abstracts;
using ProgramNamespace.Dto;

namespace ProgramNamespace.Interfaces
{
    public interface ICommandFactory
    {
        public BaseCommand GenerateCommand(PurchasingDocumentDto dto);
    }
}