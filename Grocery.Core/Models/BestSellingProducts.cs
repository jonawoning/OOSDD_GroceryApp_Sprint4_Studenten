
using CommunityToolkit.Mvvm.ComponentModel;

namespace Grocery.Core.Models
{
    public partial class BestSellingProducts : Model
    {
        // public int ProductId { get; set; }
        // public string Name {get; set;}
        public int Stock { get; set; }
        [ObservableProperty]
        public int nrOfSells;
        [ObservableProperty]
        public int ranking;

        public BestSellingProducts(int productId, string name, int stock, int nrOfSells, int ranking) : base(productId, name)
        {
            // ProductId=productId;
            // Name=name;
            Stock=stock;
            NrOfSells=nrOfSells;
            Ranking=ranking;
        }
    }
}
