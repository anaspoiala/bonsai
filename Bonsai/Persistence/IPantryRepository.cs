using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IPantryRepository
    {
        Pantry GetPantryByAccountId(long accountId);
        Item AddItem(long pantryId, Item item);
        Item DeleteItem(long pantryId, long id);
        Item UpdateItem(long pantryId, long id, Item item);
    }
}
