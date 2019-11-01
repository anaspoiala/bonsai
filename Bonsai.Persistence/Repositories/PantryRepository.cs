using System;
using System.Linq;
using Bonsai.Helpers;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using DB = Bonsai.Persistence.Model;
using Microsoft.EntityFrameworkCore;
using Bonsai.Domain;

namespace Bonsai.Persistence.Repositories
{
    public class PantryRepository : IPantryRepository
    {
        private PantryDbContext context;
        private UserInformation userInformation;

        public PantryRepository(PantryDbContext context, UserInformation userInformation)
        {
            this.context = context;
            this.userInformation = userInformation;
        }


        public Domain.Pantry GetPantryOfCurrentAccount()
        {
            return EntityMapper.ToDomainModel(context.Pantries
                .Include(p => p.Items)
                .SingleOrDefault(p => p.UserData.Account.Id == userInformation.CurrentUserId));
        }

        public Domain.Item AddItem(Domain.Item item)
        {
            var dbItem = EntityMapper.ToDatabaseModel(item);
            var dbPantry = GetDbPantryOfCurrentAccount();

            if (dbPantry == null)
            {
                throw new Exception("Pantry does not exist");
            }

            dbPantry.Items.Add(dbItem);
            context.Items.Add(dbItem);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem);
        }

        public Item DeleteItem(long itemId)
        {
            throw new NotImplementedException();
        }

        public Item UpdateItem(long itemId, Item item)
        {
            throw new NotImplementedException();
        }


        private DB.Pantry GetDbPantryOfCurrentAccount()
        {
            return context.Pantries
                .Include(p => p.Items)
                .SingleOrDefault(p => p.UserData.Account.Id == userInformation.CurrentUserId);
        }

    }
}

