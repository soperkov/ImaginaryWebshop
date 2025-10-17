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

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }
            if (orderCreateDto.Items == null || orderCreateDto.Items.Count == 0)
            {
                throw new InvalidOperationException("Order must have at least one item.");
            }

            var productIds = orderCreateDto.Items.Select(p => p.ProductId).ToList();

            var products = await _context.Products
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();

            var warehouse = await _context.Warehouse
                .Where(w => productIds.Contains(w.ProductId))
                .ToListAsync();

            double totalAmount = 0;

            foreach (var item in orderCreateDto.Items)
            {
                var product = products.FirstOrDefault(p => p.Id == item.ProductId);
                if (product == null)
                {
                    throw new KeyNotFoundException("Product not found.");
                }
                var stockItem = warehouse.FirstOrDefault(w => w.ProductId == item.ProductId);
                if (stockItem == null || stockItem.StockQuantity < item.Quantity)
                {
                    throw new InvalidOperationException("Not enough products in stock.");
                }

                totalAmount += product.Price * item.Quantity;
                stockItem.StockQuantity -= item.Quantity;
            }

            var random = new Random();
            var orderNumber = DateTime.UtcNow.ToString("yyyyMMddHHmmss") + "-" + random.Next(1000, 9999);

            var order = new OrderModel
            {
                Id = Guid.NewGuid(),
                UserId = orderCreateDto.UserId,
                Amount = totalAmount,
                OrderDate = DateTime.UtcNow,
                OrderNumber = orderNumber,
                Products = orderCreateDto.Items.Select(p => new ProductOrderModel
                {
                    Id = Guid.NewGuid(),
                    ProductId = p.ProductId,
                    Quantity = p.Quantity
                }).ToList()
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order.Id;
        }

        public async Task<List<OrderDetailsDto>> GetAllOrdersAsync(Guid userId)
        {
            var orders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.Products)
                .ThenInclude(po => po.Product)
                .Include(o => o.User)
                .AsNoTracking()
                .ToListAsync();

            return orders.Select(o => new OrderDetailsDto
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                OrderDate = o.OrderDate,
                Amount = o.Amount,
                User = new UserDetailsDto
                {
                    Id = o.UserId,
                    Username = o.User.Username,
                    Email = o.User.Email
                },
                Products = o.Products.Select(po => new ProductOrderDetailsDto
                {
                    ProductId = po.ProductId,
                    ProductName = po.Product.Name,
                    Price = po.Product.Price,
                    Quantity = po.Quantity
                }).ToList(),
            }).ToList();
        }

        public async Task<OrderDetailsDto> GetOrderDetailsAsync(Guid orderId, Guid userId)
        {
            var order = await _context.Orders
                .Where(o => o.Id == orderId && o.UserId == userId)
                .Include(o => o.Products)
                .ThenInclude(po => po.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (order == null)
                throw new KeyNotFoundException("Order not found");

            return new OrderDetailsDto
            {
                Id = order.Id,
                OrderNumber = order.OrderNumber,
                OrderDate = order.OrderDate,
                Amount = order.Amount,
                Products = order.Products.Select(po => new ProductOrderDetailsDto
                {
                    ProductId = po.ProductId,
                    ProductName = po.Product.Name,
                    Price = po.Product.Price,
                    Quantity = po.Quantity
                }).ToList(),
            };
        }

        public async Task<ProductOrderDetailsDto> GetOrderItemAsync(Guid orderId, Guid productId, Guid userId)
        {
            var item = await _context.ProductsInOrder
                .Include(po => po.Product)
                .Include(po => po.Order)
                .Where(po => po.OrderId == orderId
                          && po.ProductId == productId
                          && po.Order.UserId == userId)
                .AsNoTracking()
                .FirstOrDefaultAsync();

            if (item == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return new ProductOrderDetailsDto
            {
                ProductId = item.ProductId,
                ProductName = item.Product.Name,
                Price = item.Product.Price,
                Quantity = item.Quantity
            };
        }
    }
}
