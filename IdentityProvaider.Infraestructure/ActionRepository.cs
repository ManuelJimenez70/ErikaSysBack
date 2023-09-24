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
        public async Task RecordAction(Action_Product weak)
        {
            await db.AddAsync(weak);
            await db.SaveChangesAsync();
        }

        public async Task<Action> GetActionById(ActionId Id)
        {
            return await db.Actions.FindAsync((int)Id);
        }

        public async Task<Module> GetModuleById(ModuleId moduleId)
        {
            return await db.Modules.FindAsync((int)moduleId);
        }

        public async Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ActionType type)
        {
            List<Action_Product> actionsInRange = await db.Action_Product
                           .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime() && action.action.type.value == type.value)
                           .ToListAsync();

            return actionsInRange;
        }

        public async Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ModuleId moduleId, ActionType type)
        {
            List<Action_Product> actionsInRange = await db.Action_Product
                           .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime() && action.action.type.value == type.value && action.id_module == moduleId.value)
                           .ToListAsync();

            return actionsInRange;
        }

        public async Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ModuleId moduleId)
        {
            List<Action_Product> actionsInRange = await db.Action_Product
                           .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime() && action.id_module == moduleId.value)
                           .ToListAsync();

            return actionsInRange;
        }

        public async Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF)
        {
            List<Action_Product> actionsInRange = db.Action_Product
                   .Where(action => action.creationDate.value.ToUniversalTime() >= dateI.value.ToUniversalTime() && action.creationDate.value.ToUniversalTime() <= dateF.ToUniversalTime())
                   .ToList();
            return actionsInRange;
        }

        public async Task<List<Action_Product>> GetActionsByUserId(UserId id_user)
        {
            List<Action_Product> actionsInRange = db.Action_Product
                   .Where(action => action.id_user == id_user.value)
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
