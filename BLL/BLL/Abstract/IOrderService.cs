using DTOS.DTOS.CardDTOS;
using MVCAPP.Models;

namespace MVCAPP.BLL.Abstract
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, CardToAddDTO dto);
        Task<List<Order>> GetOrdersByUserIdAsync(int userId);
    }
}
