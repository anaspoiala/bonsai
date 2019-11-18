using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IPantryRepository
    {
        Pantry GetPantryOfCurrentAccount();
        Item GetItem(long itemId);
        Item AddItem(Item item);
        Item DeleteItem(long itemId);
        Item UpdateItem(long itemId, Item item);
    }
}
