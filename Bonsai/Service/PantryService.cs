using System;
using Bonsai.Domain;
using Bonsai.Exceptions;
using Bonsai.Helpers;
using Bonsai.Persistence;
using Bonsai.Validators;

namespace Bonsai.Service
{
    public interface IPantryService
    {
        Pantry GetCurrentUserPantry();
        PantryItem GetItem(int itemId);
        PantryItem AddItem(PantryItem item);
        PantryItem UpdateItem(int itemId, PantryItem item);
        PantryItem DeleteItem(int itemId);
        bool ItemExists(long id);
    }

    public class PantryService : IPantryService
    {
        private IPantryRepository repository;
        private UserInformation userInformation;

        public PantryService(IPantryRepository repository, UserInformation userInformation)
        {
            this.repository = repository;
            this.userInformation = userInformation;
        }

        public Pantry GetCurrentUserPantry()
        {
            return repository.GetPantryOfCurrentAccount();
        }

        public PantryItem GetItem(int itemId)
        {
            return repository.GetItem(itemId);
        }

        public bool ItemExists(long id)
        {
            return repository.ItemExists(id);
        }

        public PantryItem AddItem(PantryItem item)
        {
            ValidateItem(item);

            return repository.AddItem(item);
        }

        public PantryItem UpdateItem(int itemId, PantryItem item)
        {
            ValidateItem(item);

            return repository.UpdateItem(itemId, item);
        }

        public PantryItem DeleteItem(int itemId)
        {
            return repository.DeleteItem(itemId);
        }


        private static void ValidateItem(PantryItem item)
        {
            if (ItemValidator.NameIsEmpty(item))
            {
                throw new ValidationException("Item name cannot be empty!");
            }

            if (ItemValidator.QuantityIsEmpty(item))
            {
                throw new ValidationException("Item quantity cannot be empty!");
            }
        }
    }
}
