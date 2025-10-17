namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IWarehouseService
    {
        Task<Guid> CreateWarehouseItemAsync(WarehouseCreateDto createDto);
        Task UpdateWarehouseItemAsync(Guid id, WarehouseUpdateDto updateDto);
        Task<WarehouseDetailsDto> GetWarehouseItemDetailsAsync (Guid id);
        Task<List<WarehouseDetailsDto>> GetAllAsync();
    }
}
        