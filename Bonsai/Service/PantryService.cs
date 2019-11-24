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
        Item GetItem(int itemId);
        Item AddItem(Item item);
        Item UpdateItem(int itemId, Item item);
        Item DeleteItem(int itemId);
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

        public Item GetItem(int itemId)
        {
            return repository.GetItem(itemId);
        }

        public Item AddItem(Item item)
        {
            ValidateItem(item);

            return repository.AddItem(item);
        }

        public Item UpdateItem(int itemId, Item item)
        {
            ValidateItem(item);

            return repository.UpdateItem(itemId, item);
        }

        public Item DeleteItem(int itemId)
        {
            return repository.DeleteItem(itemId);
        }


        private static void ValidateItem(Item item)
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
