using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deadlineTrip.Models
{
    public interface IShoppingCartRepository
    {
        void AddToCart(Advertisement ad, ShoppingCart ShoppingCartId);
        ShoppingCart GetShoppingCart(string userId);
        List<ShoppingCartItem> shoppingCartListItems { get; set; }
        IEnumerable<ShoppingCartItem> GetShoppingCartItems(int cartId);
        void Delete(int id);
    }
}
