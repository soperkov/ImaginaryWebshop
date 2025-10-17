namespace ImaginaryWebshop.API.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly AppDbContext _context;
        public WarehouseService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> CreateWarehouseItemAsync(WarehouseCreateDto createDto)
        {
            var warehouseItem = new WarehouseModel
            {
                Id = Guid.NewGuid(),
                ProductId = createDto.ProductId,
                StockQuantity = createDto.StockQuantity,
                Position = createDto.Position
            };
            _context.Add(warehouseItem);
            await _context.SaveChangesAsync();
            return warehouseItem.Id;
        }
        public async Task UpdateWarehouseItemAsync(Guid id, WarehouseUpdateDto updateDto)
        {
            var item = await _context.Warehouse.FirstOrDefaultAsync(w => w.Id == id);
            if (item == null)
            {
                throw new KeyNotFoundException("Warehouse item not found.");
            }

            if (updateDto.StockQuantity.HasValue)
            {
                item.StockQuantity = updateDto.StockQuantity.Value;
            }
            if (updateDto.Position.HasValue)
            {
                item.Position = updateDto.Position.Value;
            }

            await _context.SaveChangesAsync();
            }

        public async Task<List<WarehouseDetailsDto>> GetAllAsync()
        {
            var items = await _context.Warehouse
                .AsNoTracking()
                .ToListAsync();

            return items.Select(w => new WarehouseDetailsDto
            {
                Id = w.Id,
                ProductId = w.ProductId,
                StockQuantity = w.StockQuantity,
                Position = w.Position
            }).ToList();
        }

        public async Task<WarehouseDetailsDto> GetWarehouseItemDetailsAsync(Guid id)
        {
            var item = await _context.Warehouse
                .AsNoTracking()
                .FirstOrDefaultAsync(w => id == w.Id);

            if (item == null)
                throw new KeyNotFoundException("Warehouse item not found.");

            return new WarehouseDetailsDto
            {
                Id = item.Id,
                ProductId = item.ProductId,
                StockQuantity = item.StockQuantity,
                Position = item.Position
            };
        }
    }
}
