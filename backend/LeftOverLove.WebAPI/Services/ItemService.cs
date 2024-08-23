using LeftOverLove.Common.Entities;
using LeftOverLove.Common.Exceptions;
using LeftOverLove.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LeftOverLove.WebAPI.Services;

public class ItemService
{
    private readonly AppDbContext _dbContext;

    public ItemService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddPictures(IFormFileCollection images, int itemId)
    {
        Item? item = await _dbContext.Items.FirstOrDefaultAsync(i => i.Id == itemId);

        if (item == null)
            throw new NotFoundException<Item>();

        foreach (IFormFile image in images)
        {
            string path = GetPicturePath(image, item);

            Console.WriteLine(path);

            await SavePicture(image, path);

            item.PicturePaths.Add(path);
        }

        _dbContext.Items.Update(item);
        await _dbContext.SaveChangesAsync();
    }

    private async Task SavePicture(IFormFile image, string path)
    {
        string? basePath = Path.GetDirectoryName(path);

        if (basePath == null)
            throw new Exception("Could not get directory name");

        if (!Directory.Exists(basePath))
            Directory.CreateDirectory(basePath);

        await image.CopyToAsync(new FileStream(path, FileMode.Create));
    }

    private string GetPicturePath(IFormFile image, Item item)
    {
        string basePath = Path.Combine(Environment.CurrentDirectory, "wwwroot", "Images");
        basePath = Path.Combine(basePath);

        string fileName = $"{item.Id}__{item.PicturePaths.Count}";
        fileName = Path.ChangeExtension(fileName, GetFileExtension(image.ContentType));

        string path = Path.Combine(basePath, fileName);


        return path;
    }

    private string GetFileExtension(string contentType)
    {
        switch (contentType)
        {
            case "image/jpeg":
                return ".jpg";
            case "image/png":
                return ".png";
            case "image/gif":
                return ".gif";
            default:
                throw new ArgumentException("File type not supported");
        }
    }
}
