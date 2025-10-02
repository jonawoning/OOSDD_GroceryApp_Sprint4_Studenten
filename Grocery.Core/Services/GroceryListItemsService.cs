using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class GroceryListItemsService : IGroceryListItemsService
    {
        private readonly IGroceryListItemsRepository _groceriesRepository;
        private readonly IProductRepository _productRepository;

        public GroceryListItemsService(IGroceryListItemsRepository groceriesRepository, IProductRepository productRepository)
        {
            _groceriesRepository = groceriesRepository;
            _productRepository = productRepository;
        }

        public List<GroceryListItem> GetAll()
        {
            List<GroceryListItem> groceryListItems = _groceriesRepository.GetAll();
            FillService(groceryListItems);
            return groceryListItems;
        }

        public List<GroceryListItem> GetAllOnGroceryListId(int groceryListId)
        {
            List<GroceryListItem> groceryListItems = _groceriesRepository.GetAll().Where(g => g.GroceryListId == groceryListId).ToList();
            FillService(groceryListItems);
            return groceryListItems;
        }

        public GroceryListItem Add(GroceryListItem item)
        {
            return _groceriesRepository.Add(item);
        }

        public GroceryListItem? Delete(GroceryListItem item)
        {
            throw new NotImplementedException();
        }

        public GroceryListItem? Get(int id)
        {
            return _groceriesRepository.Get(id);
        }

        public GroceryListItem? Update(GroceryListItem item)
        {
            return _groceriesRepository.Update(item);
        }

        public List<BestSellingProducts> GetBestSellingProducts(int topX = 5)
        {
            List<GroceryListItem> groceryListItems = _groceriesRepository.GetAll();
            Dictionary<int, int> productAmounts = new();
            foreach (GroceryListItem g in groceryListItems)
            {
                if (productAmounts.ContainsKey(g.ProductId))
                {
                    productAmounts[g.ProductId] += g.Amount;
                }
                else
                {
                    productAmounts[g.ProductId] = g.Amount;
                }
            }
            // order the dictionary by value and take the top X
            var topProducts = productAmounts.OrderByDescending(x => x.Value).Take(topX);
            List<BestSellingProducts> bestSellingProducts = [];
            int rank = 1;
            foreach (var p in topProducts)
            {
                Product product = _productRepository.Get(p.Key) ?? new(0, "None", 0);
                bestSellingProducts.Add(new BestSellingProducts(product.Id, product.Name, product.Stock, p.Value, rank));
                rank++;
            }
            return bestSellingProducts;
        }

        private void FillService(List<GroceryListItem> groceryListItems)
        {
            foreach (GroceryListItem g in groceryListItems)
            {
                g.Product = _productRepository.Get(g.ProductId) ?? new(0, "", 0);
            }
        }
    }
}
