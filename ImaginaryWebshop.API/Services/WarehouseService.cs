namespace ImaginaryWebshop.API.Services
{
    public class WarehouseService : IWarehouseService
    {
        Task<Guid> IWarehouseService.CreateWarehouseItemAsync(WarehouseCreateDto createDto)
        {
            throw new NotImplementedException();
        }

        Task<List<WarehouseDetailsDto>> IWarehouseService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<WarehouseDetailsDto> IWarehouseService.GetWarehouseItemDetailsAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task IWarehouseService.UpdateWarehouseItemAsync(Guid id, WarehouseUpdateDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
