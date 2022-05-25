namespace ProgramNamespace.Enums
{
    public enum OperationStatus
    {
        New = 0,
        AcceptedOnWebsite = 1,
        PaidByCustomer = 2,
        ConfirmedInWarehouse = 3,
        Sent = 4,
        Received = 5,
        RatingSent = 6,
        RatingReceived = 7,
        ErrorAcceptance = 901,
        ErrorPayment = 902,
        ErrorWarehouseConfirmation = 903,
        ErrorSend = 904,
        ErrorReceiving = 905,
        ErrorRatingSent = 906,
        ErrorRatingReceived = 907
    }
}