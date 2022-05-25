using ProgramNamespace.Abstracts;
using ProgramNamespace.Dto;
using ProgramNamespace.Enums;

namespace ProgramNamespace.Commands
{
    public class WarehouseConfirmationCommand : BaseCommand
    {
        private FakeData _data;

        protected override OperationStatus _successStatus => OperationStatus.ConfirmedInWarehouse;
        protected override OperationStatus _failureStatus => OperationStatus.ErrorWarehouseConfirmation;

        protected override bool _isValidForOperation => CheckIfAllItemsExist() 
            && (_sourceDocument.OperationStatus > (int)OperationStatus.PaidByCustomer && _sourceDocument.OperationStatus != (int)_failureStatus);

        private List<WarehouseStateDto> _warehouseStates;

        public WarehouseConfirmationCommand(PurchasingDocumentDto document) : base(document)
        {
            _data = new FakeData();
            if (!_isValidForOperation)
            {
                if (!CheckIfAllItemsExist())
                {
                    DocumentAfterOperation.OperationStatus = (int)_failureStatus;
                    throw new Exception("Some items from this order do not exist in the database");
                }
            }
        }

        public override void Execute()
        {
            if (_isValidForOperation)
            {
                try
                {
                    foreach (var item in DocumentAfterOperation.OrderItems)
                    {
                        _data.WarehouseStates.Where(x => x.ItemId == item.ItemInfo.ItemId).First().Quantity -= item.Quantity;
                    }
                    DocumentAfterOperation.OperationStatus = (int)_successStatus;
                }
                catch (Exception ex)
                {
                    DocumentAfterOperation.OperationStatus = (int)_failureStatus;
                }
            }
        }

        public override void Revert()
        {
            DocumentAfterOperation = _sourceDocument;

            foreach (var warehouseState in _warehouseStates)
            {
                _data.WarehouseStates.Where(x => x.ItemId == warehouseState.ItemId).First().Quantity = warehouseState.Quantity;
            }
        }

        private bool CheckIfAllItemsExist()
        {
            _warehouseStates = _data.WarehouseStates.Join(_sourceDocument.OrderItems.Select(x => x.ItemInfo.ItemId)
                , x => x.ItemId
                , y => y
                , (x, y) => x).ToList();
            return _warehouseStates.Count() == _sourceDocument.OrderItems.Count;
        }
    }
}