using HW.Application.Services.ImageLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HW.API.Controllers;

[ApiController]
[Route("image")]
public class ImageController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImageController(IImageService imageService) 
    {
        _imageService = imageService;
    }

    [HttpGet("show/{name}")]
    public async Task<IActionResult> ShowImage(string name)
    {
        var stream = await _imageService.DownloadFileAsync(name);
        return File(stream, "image/png");
    }
}
