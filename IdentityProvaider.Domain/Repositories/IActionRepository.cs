using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Action = IdentityProvaider.Domain.Entities.Action;

namespace IdentityProvaider.Domain.Repositories
{
    public interface IActionRepository
    {
        Task AddAction(Action action);
        Task<Action> GetActionById(ActionId Id);
        Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ActionType type);
        Task<List<Action_Product>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF);
        Task<List<Action_Product>> GetActionsByUserId(UserId id_user);
        Task UpdateActionStateById(ActionId Id, State state);
        Task RecordAction(Action_Product weak);
    }
}
