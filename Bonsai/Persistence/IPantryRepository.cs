using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IPantryRepository
    {
        Pantry GetPantryOfCurrentAccount();
        PantryItem GetItem(long itemId);
        PantryItem AddItem(PantryItem item);
        PantryItem DeleteItem(long itemId);
        PantryItem UpdateItem(long itemId, PantryItem item);
        bool ItemExists(long id);
    }
}
