
using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService(
        IGroceryListItemsRepository groceryListItemsRepository,
        IGroceryListRepository groceryListRepository,
        IClientRepository clientRepository,
        IProductRepository productRepository)
        : IBoughtProductsService
    {
        public List<BoughtProducts> Get(int productId)
        {
            var groceryListItems = groceryListItemsRepository.GetByProductId(productId);
            var product = productRepository.Get(productId);

            if (product == null)
                return new List<BoughtProducts>();

            var result = new List<BoughtProducts>();

            foreach (var groceryListItem in groceryListItems)
            {
                var groceryList = groceryListRepository.Get(groceryListItem.GroceryListId);
                if (groceryList == null) continue;

                var client = clientRepository.Get(groceryList.ClientId);
                if (client == null) continue;

                result.Add(new BoughtProducts(client, groceryList, product));
            }

            return result;
        }
    }

}
