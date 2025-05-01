using Amazon.S3;
using Amazon.S3.Model;
using HW.Application.Services.ImageLogic.Configurations;
using HW.Application.Services.ImageLogic.Interfaces;
using HW.Application.Services.SharedLogic.Exceptions;
using HW.Core.Entities;
using HW.Core.Stores;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace HW.Application.Services.ImageLogic.Implementations;

public class YandexCloudImageService : IImageService
{
    private readonly IAmazonS3 _s3Client;
    private readonly string _bucketName;
    private readonly IImageRepository _imageRepository;

    public YandexCloudImageService(IOptions<S3StorageConfiguration> options, IImageRepository imageRepository)
    {
        var config = new AmazonS3Config
        {
            ServiceURL = options.Value.ServiceURL,
            ForcePathStyle = true,
            AuthenticationRegion = options.Value.Region
        };

        _s3Client = new AmazonS3Client(
            options.Value.AccessKey,
            options.Value.SecretKey,
            config
        );

        _bucketName = options.Value.BucketName;

        _imageRepository = imageRepository;
    }

    // TODO: удаление файла в случае ошибки в бд
    public async Task<List<Image>> CreateImagesAsync(IFormFile[] imageFormFiles)
    {
        //TODO: заменить на IEnumerable?
        var imagesList = new List<Image>();

        var extensions = imageFormFiles.Select(image => Path.GetExtension(image.FileName)).ToArray();
        var allowedExtensions = new[] { ".jpg", ".jpeg" };
        if (extensions.Any(e => !allowedExtensions.Contains(e)))
        {
            throw new WrongDataException("Можно загружать только .jpg и .jpeg");
        }

        // TODO: оптимизировать с помощью Task.WhenAll()
        foreach (var imageFormFile in imageFormFiles) 
        {
            var image = await CreateImageAsync(imageFormFile);
            imagesList.Add(image);
        }

        return imagesList;
    }

    private async Task<Image> CreateImageAsync(IFormFile imageFormFile)
    {
        var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFormFile.FileName);

        using MemoryStream memoryStream = new();
        imageFormFile.CopyTo(memoryStream);

        var request = new PutObjectRequest
        {
            BucketName = _bucketName,
            Key = fileName,
            InputStream = memoryStream,
        };

        var image = Image.Create(fileName);

        await _s3Client.PutObjectAsync(request);
        await _imageRepository.AddImageAsync(image);

        return image;
    }

    public async Task<Stream> DownloadFileAsync(string name)
    {
        var request = new GetObjectRequest
        {
            BucketName = _bucketName,
            Key = name
        };

        var response = await _s3Client.GetObjectAsync(request);
        return response.ResponseStream;
    }
}