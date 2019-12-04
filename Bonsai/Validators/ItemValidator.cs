using Bonsai.Domain;

namespace Bonsai.Validators
{
    public static class ItemValidator
    {

        public static bool NameIsEmpty(PantryItem item)
        {
            return string.IsNullOrWhiteSpace(item.Item.Name);
        }

        public static bool QuantityIsEmpty(PantryItem item)
        {
            return item.Quantity == null;
        }

        public static bool BuyDateIsEmpty(PantryItem item)
        {
            return item.BuyDate == null; 
        }

        public static bool ExpirationDateIsEmpty(PantryItem item)
        {
            return item.ExpirationDate == null;
        }

        public static bool ItemIsExpired(PantryItem item)
        {
            return item.ExpirationDate.Value.CompareTo(System.DateTime.UtcNow) >= 0;
        }

    }
}
