using System;

namespace Order.Enums
{
    public enum OrderType
    {
        Accepted,
        Processing,
        Paid,
        Cancelled,
        ShipmentAllowed,
        DeliveryAllowed,
        DeliveredToThePointOfIssue,
        BuyerGot
    }
}
