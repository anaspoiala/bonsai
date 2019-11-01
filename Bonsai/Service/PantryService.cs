using System;
using Bonsai.Domain;
using Bonsai.Helpers;
using Bonsai.Persistence;
using Bonsai.Validators;

namespace Bonsai.Service
{
    public interface IPantryService
    {
        Pantry GetCurrentUserPantry();
        Item AddItem(Item item);
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

        public Item AddItem(Item item)
        {
            if (ItemValidator.NameIsEmpty(item))
            {
                throw new Exception("Item name cannot be empty!");
            }

            if (ItemValidator.QuantityIsEmpty(item))
            {
                throw new Exception("Item quantity cannot be empty!");
            }

            return repository.AddItem(item);
        }

        public Pantry GetCurrentUserPantry()
        {
            return repository.GetPantryOfCurrentAccount();
        }
    }
}
