using AutoMapper;
using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.CardDTOS;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using MVCAPP.BLL.Abstract;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DAL.Generic_Repository.Concrete;
using MVCAPP.Models;




namespace MVCAPP.BLL.Concrete
{
    public class OrderService : IOrderService
    {
        IMapper _mapper;
        MyAppDbContext _context;
        private readonly IRepository<Order> _repository;
        private readonly IRepository<ShoppingCartItem> _itemrepository;
        private readonly IRepository<PaymentDetail> _paymentrepository;

        ICardService _cardservice;
        public OrderService(IMapper mapper, IRepository<Order> repository, MyAppDbContext myAppDbContext, IRepository<ShoppingCartItem> itemrepository, ICardService cardService, IRepository<PaymentDetail> repository1)
        {

            _mapper = mapper;


            _context = myAppDbContext;
            _repository = repository;
            _itemrepository = itemrepository;
            _cardservice = cardService;
            _paymentrepository = repository1;



        }

        public async Task<List<Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orders = _context.Orders.Where(c => c.UserId == userId).ToListAsync();
            return await orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, int userId, CardToAddDTO dto)
        {
            DateTime currentDate = DateTime.Now;
            int dayOfMonth = currentDate.Day;
            await _cardservice.AddAsync(dto, userId);
            Card card = _context.Cards.FirstOrDefault(x => x.CardNumber == dto.CardNumber);
            var order = new Order()
            {
                UserId = userId,
                IsPayyed = true,
               CardId = card.Id


            };
            if (dayOfMonth == 4)
            {
                order.HasDiscount = true;
            }
            await _repository.AddAsync(order);
            foreach (var item in items)
            {

                item.Order = order;
                item.OrderId = order.Id;
                await _itemrepository.UpdateAsync(item);
            }

            var payment = new PaymentDetail()
            {
                Order = order,
                OrderId = order.Id,
                UserId = userId,
                PaymentDate = currentDate,
                TotalAmount = items.Sum(x => x.Price * x.Amount)
            };
          

        }

    }
}
