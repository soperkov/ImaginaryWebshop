namespace ImaginaryWebshop.Data.Interfaces
{
    public interface IUploadsService
    {
        Task<string> SaveProductImageAsync(Stream content, string originalFileName, string webRootPath, string? oldUrl = null);
    }
}
