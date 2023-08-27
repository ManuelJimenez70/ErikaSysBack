using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = IdentityProvaider.Domain.Entities.Action;

namespace IdentityProvaider.Infraestructure
{
    public class ActionRepository : IActionRepository
    {

        DatabaseContext db;

        public ActionRepository(DatabaseContext db)
        {
            this.db = db;
        }
        public async Task AddAction(Action action)
        {
            await db.AddAsync(action);
            await db.SaveChangesAsync();
        }

        public async Task<Action> GetActionById(ActionId Id)
        {
            return await db.Actions.FindAsync((int)Id);
        }

        public async Task<List<Action>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ActionType type)
        {
            List<Action> actionsInRange = await db.Actions
                           .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime() && action.type.value == type.value && action.state.value == "Activo")
                           .ToListAsync();

            return actionsInRange;
        }

        public async Task<List<Action>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF)
        {
            List<Action> actionsInRange = db.Actions
                   .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime() && action.state.value == "Activo")
                   .ToList();
            return actionsInRange;
        }

        public async Task UpdateActionStateById(ActionId Id, State state)
        {
            Action action = await db.Actions.FindAsync((int)Id);
            if (action == null) {
                if (action.state.value == "Activo")
                {
                    action.setState(state);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
