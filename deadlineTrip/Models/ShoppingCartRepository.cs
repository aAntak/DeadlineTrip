using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {

        private readonly AppDbContext _appDbContext;

        public List<ShoppingCartItem> shoppingCartListItems { get; set; }
        
        public ShoppingCartRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public ShoppingCart GetShoppingCart(string userId)
        {
           ShoppingCart cart =  _appDbContext.ShoppingCart.FirstOrDefault(x => x.account.Id == userId);
           return cart;
        }
        public IEnumerable<ShoppingCartItem> GetShoppingCartItems(int cartId)
        {
            var allCards = _appDbContext.Card;
            var items = shoppingCartListItems ??
                   (shoppingCartListItems =
                       _appDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId.ShoppingCartId == cartId)
                           .ToList());

            return items;
        }
        
        public void AddToCart(Advertisement ad, ShoppingCart ShoppingCartId)
        {
            var shoppingCartItem =
                     _appDbContext.ShoppingCartItem.SingleOrDefault(
                         s => s.adId == ad.Id && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    ad = ad,
                    quantity = 1
                };

                _appDbContext.ShoppingCartItem.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.quantity++;
            }
            _appDbContext.SaveChanges();

        }

        public void Delete(int id)
        {

            ShoppingCartItem ad = _appDbContext.ShoppingCartItem.Find(id);

            _appDbContext.Remove(ad);

            _appDbContext.SaveChanges();

        }



    }
}
