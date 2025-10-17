namespace ImaginaryWebshop.API.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateOrderAsync(OrderCreateDto orderCreateDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == orderCreateDto.UserId);
            var product = await _context.Users.FirstOrDefaultAsync(p => p.Id ==  orderCreateDto.ProductId);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            var warehouseItem = await _context.Warehouse.FirstOrDefaultAsync(w => w.ProductId ==  orderCreateDto.ProductId);
            if (warehouseItem == null || orderCreateDto.Quantity > warehouseItem.StockQuantity)
            {
                throw new InvalidOperationException("Not enough product for this order");
            }

            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                UserId = orderCreateDto.UserId,
                ProductId = orderCreateDto.ProductId,
                Quantity = orderCreateDto.Quantity,
                OrderDate = DateTime.UtcNow
            };

            warehouseItem.StockQuantity -= orderCreateDto.Quantity;

            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderDetailsDto>> GetAllOrdersAsync(Guid userId)
        {
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .AsNoTracking()
                .ToListAsync();

            return orders.Select(o => new OrderDetailsDto
            {
                Id = o.Id,
                Quantity = o.Quantity,
                OrderDate = o.OrderDate,
                User = new UserDetailsDto
                {
                    Id = o.User.Id,
                    Name = o.User.Username, 
                    Email = o.User.Email
                },
                Product = new ProductDetailsDto
                {
                    Id = o.Product.Id,
                    Name = o.Product.Name,
                    Description = o.Product.Description,
                    Price = o.Product.Price,
                    Category = o.Product.Category
                }
            }).ToList();
        }

        public async Task<OrderDetailsDto> GetOrderDetailsAsync(Guid orderId, Guid userId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == orderId && o.UserId == userId)
                .Include(o => o.Product)
                .Include(o => o.User)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            return new OrderDetailsDto
            {
                Id = order.Id,
                Quantity = order.Quantity,
                OrderDate = order.OrderDate,
                User = new UserDetailsDto
                {
                    Id = order.User.Id,
                    Name = order.User.Username,
                    Email = order.User.Email
                },
                Product = new ProductDetailsDto
                {
                    Id = order.Product.Id,
                    Name = order.Product.Name,
                    Description = order.Product.Description,
                    Price = order.Product.Price,
                    Category = order.Product.Category
                }
            };
        }
    }
}
