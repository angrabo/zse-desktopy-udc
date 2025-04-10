namespace UCDCourseEditor.Infrastructure.FileStorage;

public class ImageService
{
    public async Task<string> SaveImageAsync(Stream imageStream, string imageDirectory, string fileName)
    {
        var filePath = Path.Combine(imageDirectory, fileName);
        await using var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
        await imageStream.CopyToAsync(fileStream);
        return filePath;
    }

    public async Task<Stream?> GetImageAsync(string imageDirectory, string fileName)
    {
        var filePath = Path.Combine(imageDirectory, fileName);
        if (!File.Exists(filePath))
            return null;

        return await Task.FromResult(new FileStream(filePath, FileMode.Open, FileAccess.Read));
    }
}