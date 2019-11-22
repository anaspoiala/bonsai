using System;
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


        public Domain.Pantry GetPantryOfCurrentAccount()
        {
            var dbPantry = GetDbPantryOfCurrentAccount();
            return EntityMapper.ToDomainModel(dbPantry);
        }

        public Item GetItem(long itemId)
        {
            var dbPantry = GetDbPantryOfCurrentAccount();
            var item = dbPantry.Items.SingleOrDefault(i => i.Id == itemId);

            return EntityMapper.ToDomainModel(item);
        }

        public Domain.Item AddItem(Domain.Item item)
        {
            var dbItem = EntityMapper.ToDatabaseModel(item);
            var dbPantry = GetDbPantryOfCurrentAccount();

            dbPantry.Items.Add(dbItem);
            context.Items.Add(dbItem);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem);
        }

        public Item UpdateItem(long itemId, Item item)
        {
            //var dbItem = GetDbItem(itemId);

            //if (!string.IsNullOrWhiteSpace(item.Name)) dbItem.Name = item.Name;
            //if (item.Quantity != null)
            //{
            //    dbItem.Quantity.Amount = item.Quantity.Amount;
            //    dbItem.Quantity.Unit = item.Quantity.Unit;
            //}
            //if (item.BuyDate.HasValue) dbItem.BuyDate = item.BuyDate.Value;
            //if (item.ExpirationDate.HasValue) dbItem.ExpirationDate = item.ExpirationDate.Value;

            //context.SaveChanges();

            //return EntityMapper.ToDomainModel(dbItem);


            throw new NotImplementedException();
        }

        public Item DeleteItem(long itemId)
        {
            var dbItem = GetDbItem(itemId);
            var dbPantry = GetDbPantryOfCurrentAccount();

            dbPantry.Items.Remove(dbItem);
            context.SaveChanges();
            return EntityMapper.ToDomainModel(dbItem); ;
        }


        private DB.Pantry GetDbPantryOfCurrentAccount()
        {
            var pantry = context.Pantries.Include(p => p.Items)
                .SingleOrDefault(p => p.UserData.Account.Id == userInformation.CurrentUserId);

            if (pantry == null)
            {
                throw new PantryNotFoundException();
            }

            return pantry;
        }


        private DB.Item GetDbItem(long itemId)
        {
            var item = GetDbPantryOfCurrentAccount().Items.SingleOrDefault(i => i.Id == itemId);

            if (item == null)
            {
                throw new ItemNotFoundException();
            }

            return item;
        }

    }
}

