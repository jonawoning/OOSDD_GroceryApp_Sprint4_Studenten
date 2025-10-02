
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
            List<GroceryListItem> groceryListItems = groceryListItemsRepository.GetAll().Where(g => g.ProductId == productId).ToList();
            List<BoughtProducts> boughtProducts = new List<BoughtProducts>();

            foreach (GroceryListItem groceryListItem in groceryListItems)
            {
                GroceryList groceryList = groceryListRepository.Get(groceryListItem.GroceryListId);
                Client client = clientRepository.Get(groceryList.ClientId);
                Product product = productRepository.Get(productId);
                boughtProducts.Add(new BoughtProducts(client, groceryList, product));
            }
            
            return boughtProducts;
        }
    }
}
