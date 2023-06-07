using AutoMapper;
using DAL;
using Microsoft.EntityFrameworkCore;
using MVCAPP.BLL.Abstract;
using MVCAPP.DAL.Generic_Repository.Abstract;
using MVCAPP.DTOS.ShoppingCartDTOS;
using MVCAPP.Models;
using System.Security.Cryptography.X509Certificates;

namespace MVCAPP.BLL.Concrete
{
    public class ShoppingCartService : IShoppingCartService
    {
        IMapper _mapper;
        MyAppDbContext _context;
        private readonly IRepository<ShoppingCartItem> _repository;
        public ShoppingCartService(IMapper mapper, IRepository<ShoppingCartItem> repository, MyAppDbContext myAppDbContext)
        {

            _mapper = mapper;

            _repository = repository;
            _context = myAppDbContext;


        }
        public async Task AddItemToCart(int movieId, int id)
        {
            ShoppingCartItem shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(x => x.MovieId == movieId && x.UserId == id);
            Movie movie = _context.Movies.FirstOrDefault(x => x.Id == movieId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                   Price = movie.Price,
                    Movie = movie,
                    MovieId = movie.Id,
                    Amount = 1
                };
                ShoppingCartItem shoppingCartItemModel = _mapper.Map<ShoppingCartItem>(shoppingCartItem);
                await  _repository.AddAsync(shoppingCartItemModel);
            }
            else
            {
                shoppingCartItem.Movie = movie;
                shoppingCartItem.Amount++;
                shoppingCartItem.Price = movie.Price * shoppingCartItem.Amount;
                ShoppingCartItem shoppingCartItem1 = _mapper.Map<ShoppingCartItem>(shoppingCartItem);
                await _repository.UpdateAsync(shoppingCartItem1);   
            }
        
          
        }

        public async Task DeleteItemFromCart(int movieId, int id)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Movie.Id == movieId && n.UserId == id);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    await _repository.UpdateAsync(shoppingCartItem);
                }
                else
                {
                  await  _repository.DeleteAsync(shoppingCartItem.Id);
                }
            }
        }

      
        
        public async Task<List<ShoppingCartItem>> GetShoppingCartItems(int id)
        {
            List<ShoppingCartItem> list = await _context.ShoppingCartItems.Where(x => x.UserId == id).ToListAsync();
            return  list;
        }
        public async Task ClearShoppingCartAsync(int id)
        {
            var items = _context.ShoppingCartItems.Where(x => x.UserId == id).ToList();
            _context.ShoppingCartItems.RemoveRange(items);

            await _context.SaveChangesAsync();

        }
    }
}
