using Microsoft.EntityFrameworkCore;
using Test0912.Data;

namespace Test0912.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _context;
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public static ShoppingCart GetCart(IServiceProvider services) 
        { 
            // Session is to store data under the time use is using
            ISession session = services
                .GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var appcontext = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(appcontext)
            {
                ShoppingCartId = cartId,
            };
        }

        // Method to the chosen candy to Shopping cart.
        public void AddToCart(Candy candy, int amount)
        {
            // if there are any items in cart.
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
                s => s.Candy.CandyId == candy.CandyId &&
                s.ShoppingCartId == ShoppingCartId);

            // If there is no item in cart, you add new items in cart.
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Candy = candy,
                    Amount = amount
                };

                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                // If there is items, you increse the amount.
                shoppingCartItem.Amount++;
            }

            _context.SaveChanges();
        }

        public int RemoveFromCart(Candy candy)
        {
            var shoppingCartItem = _context.ShoppingCartItems.SingleOrDefault(
              s => s.Candy.CandyId == candy.CandyId &&
              s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;
            if(shoppingCartItem != null)
            {
                if(shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else   // If there is just one candy, you need to remove it.
                {

                    _context.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _context.SaveChanges();
            return localAmount;

        }

        // Method to get and cash items.
        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            // When ShoppingCartItems is null, items will be called
            // from DB.
            return ShoppingCartItems ?? 
                (ShoppingCartItems = _context.ShoppingCartItems.Where(
                    c => c.ShoppingCartId == ShoppingCartId).
                    Include(s => s.Candy)
                    .ToList());
        }

        public void ClearCart()
        {
            var cartItems = _context.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId);

            _context.ShoppingCartItems.RemoveRange(cartItems);
            _context.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Candy.Price * c.Amount).Sum();

            return total;
        }
        
    }
}
