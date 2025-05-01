using HW.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HW.Application.Services.ImageLogic.Interfaces;

public interface IImageService
{
    Task<List<Image>> CreateImagesAsync(IFormFile[] imageFormFiles);

    Task<Stream> DownloadFileAsync(string name);
}
