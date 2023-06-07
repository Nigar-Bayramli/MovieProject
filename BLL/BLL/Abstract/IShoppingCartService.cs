

using MVCAPP.DTOS.ShoppingCartDTOS;
using MVCAPP.Models;

namespace MVCAPP.BLL.Abstract
{
    public interface IShoppingCartService
    {
        Task AddItemToCart(int movieid, int id);
        Task DeleteItemFromCart(int movieid, int id);
       
        Task<List<ShoppingCartItem>> GetShoppingCartItems(int id);
        Task ClearShoppingCartAsync(int id);
    }
}
