using Microsoft.EntityFrameworkCore;
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
        public IEnumerable<ShoppingCartItem> GetShoppingCartListItems(int cartId)
        {
            var allCards = _appDbContext.Card;
            var items = shoppingCartListItems ??
                   (shoppingCartListItems =
                       _appDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId.ShoppingCartId == cartId)
                           .ToList());

            return items;
        }
        //public ShoppingCartItem GetItem(int id)
        //{
        //    ShoppingCartItem item = _appDbContext.ShoppingCartItem.FirstOrDefault(x => x.ShoppingCartItemId == id);
        //    return item;
        //}
        
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
        public void ClearCart(ShoppingCart cart)
        {
            int cartId = cart.ShoppingCartId;
            //var ads = _appDbContext.Advertisements;
 
            shoppingCartListItems = _appDbContext
            .ShoppingCartItem.Where(x => x.ShoppingCartId.ShoppingCartId == cart.ShoppingCartId).Include(ad => ad.ad).ToList();
           

            foreach (var item in shoppingCartListItems)
            {
                if(item.ad.Quantity > item.quantity)
                {
                    item.ad.Quantity -= item.quantity;
                }
                else
                {
                    _appDbContext.Remove(item.ad);
                }
            }

            _appDbContext.ShoppingCartItem.RemoveRange(shoppingCartListItems);

            _appDbContext.SaveChanges();

        }



    }
}
