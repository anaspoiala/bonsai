using System;
using System.Linq;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Repositories
{
    public class PantryRepository : IPantryRepository
    {
        private PantryDbContext context;

        public PantryRepository(PantryDbContext context)
        {
            this.context = context;
        }


        public Domain.Pantry GetPantryByAccountId(long accountId)
        {
            return EntityMapper.ToDomainModel(context.Pantries
                .Include(p => p.UserData)
                    .ThenInclude(ud => ud.Account)
                .Include(p => p.Items)
                .SingleOrDefault(p => p.UserData.Account.Id == accountId));
        }

        public Domain.Item AddItem(long pantryId, Domain.Item item)
        {
            var dbItem = EntityMapper.ToDatabaseModel(item);
            var pantry = context.Pantries
                .Include(p => p.Items)
                .SingleOrDefault(p => p.Id == pantryId);

            if (pantry == null)
            {
                throw new Exception("Pantry does not exist");
            }

            pantry.Items.Add(dbItem);
            context.Items.Add(dbItem);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbItem);
        }

        public Domain.Item DeleteItem(long pantryId, long id)
        {
            throw new NotImplementedException();
        }


        public Domain.Item UpdateItem(long pantryId, long id, Domain.Item item)
        {
            throw new NotImplementedException();
        }
    }
}

