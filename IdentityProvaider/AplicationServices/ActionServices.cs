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
        private readonly IProductRepository repository;
        private readonly IUserRepository userRepository;


        public ActionServices(IProductRepository repository, IUserRepository userRepository, IActionRepository actionRepository)
        {
            this.repository = repository;
            this.userRepository = userRepository;
            this.actionRepository = actionRepository;
        }

        public async Task<ContentResponse> HandleCommand(RecordSaleCommand recordSale)
        {
            try
            {
                var weak = new Action_Product();
                DateTime creationDate = DateTime.Now;
                weak.setCreationDate(CreationDate.create(creationDate));
                User user = await userRepository.GetUserById(UserId.create(recordSale.id_user));
                if (user == null)
                {
                    return ContentResponse.createResponse(false, "Error al generar Venta: no se encontro el usuario", "ERROR");
                }
                weak.setUser(user);
                Action action = await actionRepository.GetActionById(ActionId.create(recordSale.id_action));
                weak.setAction(action);
                Product product = await repository.GetProductById(ProductId.create(recordSale.id_product));
                if (product == null) {
                    return ContentResponse.createResponse(false, "Error al generar Venta: no se encontro el producto", "ERROR");
                }
                weak.setProduct(product);
                weak.setQuantity(Quantity.create(recordSale.quantity));
                weak.setState(State.create(string.IsNullOrEmpty(recordSale.state) ? "SUCCESS" : recordSale.state));
                if (action != null)
                {
                    if (action.type.value.ToUpper().Trim() == "IN")
                    {
                        product.setStock(Stock.create(product.stock.value + recordSale.quantity));
                        await actionRepository.RecordAction(weak);
                        return ContentResponse.createResponse(true, "Accion Registrada correctamente", "SUCCESS");
                    }
                    else if (action.type.value.ToUpper().Trim() == "OUT")
                    {
                        if ((product.stock.value - recordSale.quantity) < 0)
                        {
                            return ContentResponse.createResponse(false, "Error al generar Venta: No hay existencias suficientes para realizar la venta", "SUCCESS");

                        }
                        else
                        {
                            product.setStock(Stock.create(product.stock.value - recordSale.quantity));
                            await actionRepository.RecordAction(weak);
                            return ContentResponse.createResponse(true, "Venta Registrada correctamente", "SUCCESS");
                        }
                    }
                    else
                    {
                        return ContentResponse.createResponse(false, "Error al generar Venta: Tipo de Accion no soportada", "ERROR");
                    }
                }
                else {
                    return ContentResponse.createResponse(false, "Error al generar Venta: Tipo de Accion no soportada", "ERROR");
                }

            }
            catch (Exception ex)
            {

                return ContentResponse.createResponse(false, "Error al generar Venta:" + ex.Message, "ERROR");
            }

        }

        public async Task HandleCommand(CreateActionCommand createAction)
        {

            Action action = new Domain.Entities.Action();
            action.setTypeAction(ActionType.create(createAction.type));
            action.setDescription(Description.create(createAction.description));
            await actionRepository.AddAction(action);
        }

        public async Task<List<Action_Product>> GetActionsByRangeDate(DateTime dateI, DateTime dateF)
        {
            try
            {
                List<Action_Product> actions = await actionRepository.GetActionsByRangeDate(CreationDate.create(dateI), dateF);
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

        public async Task<List<Action_Product>> GetActionsByRangeDate(DateTime dateI, DateTime dateF, string type)
        {
            try
            {
                List<Action_Product> actions = await actionRepository.GetActionsByRangeDate(CreationDate.create(dateI), dateF, ActionType.create(type));
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

        public async Task<List<Action_Product>> GetActionsByUserId(int id_user)
        {
            try
            {
                List<Action_Product> actions = await actionRepository.GetActionsByUserId(UserId.create(id_user));
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
