
namespace ImaginaryWebshop.API.Services
{
    public class UploadsService : IUploadsService
    {
        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png", ".webp", ".gif", ".bmp", ".tiff", ".jfif" };
        public async Task<string> SaveProductImageAsync(Stream content, string originalFileName, string webRootPath, string? oldUrl = null)
        {
            var ext = Path.GetExtension(originalFileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext))
            {
                throw new ArgumentException("Unsupported format.");
            }

            var root = Path.Combine(webRootPath ?? "wwwroot", "uploads", "products");
            Directory.CreateDirectory(root);

            if (!string.IsNullOrWhiteSpace(oldUrl))
            {
                var oldPath = Path.Combine(webRootPath ?? "wwwroot", oldUrl.TrimStart('/').Replace('/', Path.DirectorySeparatorChar));
                if (File.Exists(oldPath)) File.Delete(oldPath);
            }

            var filename = $"{Guid.NewGuid()}{ext}";
            var path = Path.Combine(root, filename);

            await using var fileStream = File.Create(path);
            await content.CopyToAsync(fileStream);

            return $"/uploads/products/{filename}";
        }
    }
}

