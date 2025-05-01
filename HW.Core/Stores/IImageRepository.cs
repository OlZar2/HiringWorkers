using HW.Core.Entities;

namespace HW.Core.Stores;

public interface IImageRepository
{
    Task AddImageAsync(Image image);
}
