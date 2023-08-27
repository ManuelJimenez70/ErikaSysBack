using IdentityProvaider.API.Commands;
using IdentityProvaider.API.Queries;
using IdentityProvaider.Domain.Entities;
using IdentityProvaider.Domain.Repositories;
using IdentityProvaider.Domain.ValueObjects;
using IdentityProvaider.Infraestructure;
using Action = IdentityProvaider.Domain.Entities.Action;

namespace IdentityProvaider.API.AplicationServices
{
    public class ActionServices
    {

        private readonly IActionRepository actionRepository;
        public ActionServices(IActionRepository actionRepository)
        {
            this.actionRepository = actionRepository;
   
        }

        public async Task HandleCommand(CreateActionCommand createAction)
        {

            Action action = new Domain.Entities.Action();
            action.setTypeAction(ActionType.create(createAction.type));
            action.setDescription(Description.create(createAction.description));
            await actionRepository.AddAction(action);
        }

        public async Task<List<Action>> GetActionsByRangeDate(DateTime dateI, DateTime dateF)
        {
            try
            {
                List<Action> actions = await actionRepository.GetActionsByRangeDate(CreationDate.create(dateI), dateF);
                if (actions == null)
                {
                    throw new ArgumentNullException("No existen acciones en ese rango de tiempo");
                }
                return actions;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Error al encontrar acciones: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al buscar acciones: " + ex.Message);
            }
        }

        public async Task<List<Action>> GetActionsByRangeDate(DateTime dateI, DateTime dateF, string type)
        {
            try
            {
                List<Action> actions = await actionRepository.GetActionsByRangeDate(CreationDate.create(dateI), dateF, ActionType.create(type));
                if (actions == null)
                {
                    throw new ArgumentNullException("No existen acciones en ese rango de tiempo");
                }
                return actions;
            }
            catch (ArgumentNullException ex)
            {
                throw new ArgumentNullException("Error al encontrar acciones: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al buscar acciones: " + ex.Message);
            }

        }

    }
}
