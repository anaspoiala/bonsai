using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Model;

namespace Bonsai.Persistence.Repositories
{
    public class PantryRepository
    {
        private PantryDbContext context;

        public PantryRepository(PantryDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Pantry> GetAll()
        {
            return context.Pantries.ToList();
        }

        public Pantry GetById(long id)
        {
            return context.Pantries.SingleOrDefault(p => p.Id == id);
        }

        public Pantry Create(Pantry pantry, long accountDataId)
        {
            var userData = context.UsersData.SingleOrDefault(ud => ud.Id == accountDataId);

            if (userData == null)
                throw new Exception("User data could not be found!");

            if (userData.Pantry != null)
                throw new Exception("A pantry for this user has already been created!");

            pantry.UserData = userData;
            context.Pantries.Add(pantry);
            userData.Pantry = pantry;
            context.SaveChanges();

            return pantry;
        }

        public Pantry Delete(long id)
        {
            var pantry = context.Pantries.SingleOrDefault(p => p.Id == id);
            if (pantry == null)
                throw new Exception("A pantry with the given ID does not exist!");

            context.Pantries.Remove(pantry);
            context.SaveChanges();

            return pantry;
        }
    }
}

