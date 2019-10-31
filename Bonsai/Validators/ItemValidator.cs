using Bonsai.Domain;

namespace Bonsai.Validators
{
    public static class ItemValidator
    {

        public static bool NameIsEmpty(Item item)
        {
            return string.IsNullOrWhiteSpace(item.Name);
        }

        public static bool QuantityIsEmpty(Item item)
        {
            return item.Quantity == null;
        }

        public static bool BuyDateIsEmpty(Item item)
        {
            return item.BuyDate == null; 
        }

        public static bool ExpirationDateIsEmpty(Item item)
        {
            return item.ExpirationDate == null;
        }

        public static bool ItemIsExpired(Item item)
        {
            return item.ExpirationDate.Value.CompareTo(System.DateTime.UtcNow) >= 0;
        }

    }
}
