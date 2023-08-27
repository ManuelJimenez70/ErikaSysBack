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
        Task<List<Action>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF, ActionType type);
        Task<List<Action>> GetActionsByRangeDate(CreationDate dateI, DateTime dateF);

        Task UpdateActionStateById(ActionId Id, State state);

    }
}
