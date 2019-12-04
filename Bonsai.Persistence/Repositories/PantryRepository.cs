using System.Linq;
using Bonsai.Domain;
using Bonsai.Exceptions;
using Bonsai.Helpers;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using DB = Bonsai.Persistence.Model;

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


        public Pantry GetPantryOfCurrentAccount()
        {
            var dbPantry = GetDbPantryOfCurrentAccount();
            return EntityMapper.ToDomainModel(dbPantry);
        }

        public PantryItem GetItem(long itemId)
        {
            var dbPantry = GetDbPantryOfCurrentAccount();
            var item = dbPantry.Items.SingleOrDefault(i => i.Id == itemId);

            return EntityMapper.ToDomainModel(item);
        }

        public bool ItemExists(long itemId)
        {
            var item = GetDbPantryOfCurrentAccount().Items.SingleOrDefault(i => i.Id == itemId);
            return item != null;
        }

        public PantryItem AddItem(Domain.PantryItem item)
        {
            var dbItem = EntityMapper.ToDatabaseModel(item);
            var dbPantry = GetDbPantryOfCurrentAccount();

            dbPantry.Items.Add(dbItem);
            //context.Items.Add(dbItem);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem);
        }

        public PantryItem UpdateItem(long itemId, PantryItem item)
        {
            var dbItem = GetDbItem(itemId);

            //dbItem.Name = item.Name;
            dbItem.Quantity.Amount = item.Quantity.Amount;
            dbItem.Quantity.Unit = item.Quantity.Unit;
            dbItem.BuyDate = item.BuyDate;
            dbItem.ExpirationDate = item.ExpirationDate;

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem);
        }

        public PantryItem DeleteItem(long itemId)
        {
            var dbItem = GetDbItem(itemId);
            var dbPantry = GetDbPantryOfCurrentAccount();

            dbPantry.Items.Remove(dbItem);
            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem); ;
        }


        private DB.Items.Pantry GetDbPantryOfCurrentAccount()
        {
            var pantry = context.Pantries.Include(p => p.Items)
                .SingleOrDefault(p => p.UserData.Account.Id == userInformation.CurrentUserId);

            return pantry ?? throw new PantryNotFoundException();
        }

        private DB.Items.PantryItem GetDbItem(long itemId)
        {
            var item = GetDbPantryOfCurrentAccount().Items.SingleOrDefault(i => i.Id == itemId);

            return item ?? throw new ItemNotFoundException();
        }

    }
}

