using ProgramNamespace.Dto;
using ProgramNamespace.Enums;

namespace ProgramNamespace
{
    public class FakeData
    {
        public List<PurchasingDocumentDto> PurchasingDocuments = new List<PurchasingDocumentDto>()
        {
            new PurchasingDocumentDto()
            {
                Id = 1,
                CreatedAt = new DateTime(2022,5,15,23,14,19),
                ConfirmedByCustomer = false,
                CustomerId = 1,
                OperationStatus = (int)OperationStatus.New,

                OrderItems = new List<PurchasingDocumentItemDto>()
                {
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 1,
                        OrderId = 1,
                        ItemId = 1,
                        Quantity = 2
                    },
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 2,
                        OrderId = 1,
                        ItemId = 2,
                        Quantity = 1
                    },
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 3,
                        OrderId = 1,
                        ItemId = 1,
                        Quantity = 2
                    },
                }
            },
            new PurchasingDocumentDto()
            {
                Id = 2,
                CreatedAt = new DateTime(2022,5,17,11,02,19),
                ConfirmedByCustomer = true,
                CustomerId = 1,
                OperationStatus = (int)OperationStatus.AcceptedOnWebsite,

                OrderItems = new List<PurchasingDocumentItemDto>()
                {
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 4,
                        OrderId = 2,
                        ItemId = 3,
                        Quantity = 2
                    }
                }
            },
            new PurchasingDocumentDto()
            {
                Id = 3,
                CreatedAt = new DateTime(2022,5,23,16,00,16),
                ConfirmedByCustomer = true,
                CustomerId = 1,
                OperationStatus = (int)OperationStatus.PaidByCustomer,
                PaymentId = new Guid(),

                OrderItems = new List<PurchasingDocumentItemDto>()
                {
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 5,
                        OrderId = 3,
                        ItemId = 1,
                        Quantity = 4
                    },
                    new PurchasingDocumentItemDto()
                    {
                        OrderPositionId = 6,
                        OrderId = 3,
                        ItemId = 4,
                        Quantity = 1
                    }
                }
            },
        };

        public List<WarehouseStateDto> WarehouseStates = new List<WarehouseStateDto>()
                {
                    new WarehouseStateDto()
                    {
                        ItemId = 1,
                        Quantity = 3,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 2,
                        Quantity = 5,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 3,
                        Quantity = 0,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 4,
                        Quantity = 15,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 5,
                        Quantity = 7,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 6,
                        Quantity = 0,
                    },
                    new WarehouseStateDto()
                    {
                        ItemId = 7,
                        Quantity = 1,
                    },
                };

        public List<PaymentInfoDto> PaymentInformation = new List<PaymentInfoDto>()
        {
            new PaymentInfoDto()
            {
                PaymentId = new Guid(),
                OrderId = 1,
                Amount = 223.91M
            },
            new PaymentInfoDto()
            {
                PaymentId = new Guid(),
                OrderId = 3,
                Amount = 71M
            },
            new PaymentInfoDto()
            {
                PaymentId = new Guid(),
                OrderId = 4,
                Amount = 18.16M
            },
        };

        public List<ItemInfoDto> ItemsInfo = new List<ItemInfoDto>()
        {
            new ItemInfoDto()
            {
                ItemId = 1,
                UnitPrice = 120M
            },
            new ItemInfoDto()
            {
                ItemId = 2,
                UnitPrice = 71.13M
            },
            new ItemInfoDto()
            {
                ItemId = 3,
                UnitPrice = 391.15M
            },
            new ItemInfoDto()
            {
                ItemId = 4,
                UnitPrice = 23.40M
            },
            new ItemInfoDto()
            {
                ItemId = 5,
                UnitPrice = 19.23M
            },
            new ItemInfoDto()
            {
                ItemId = 6,
                UnitPrice = 1600M
            },
            new ItemInfoDto()
            {
                ItemId = 7,
                UnitPrice = 604.15M
            },
        };

        public FakeData()
        {
            foreach (var order in PurchasingDocuments)
            {
                foreach (var item in order.OrderItems)
                {
                    item.ItemInfo = ItemsInfo.Where(x => x.ItemId == item.ItemId).FirstOrDefault();
                }
            }
        }
    }
}