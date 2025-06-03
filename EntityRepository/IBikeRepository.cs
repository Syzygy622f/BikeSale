using DtoModel;
using Model;

namespace EntityRepository
{
    public interface IBikeRepository
    {
        Task<bool> createBikeAsync(BikeDto CreateBike);
        Task<bool> DeleteBikeAsync(int id);
        Task<Bike> GetBikeAsync(int id);
        Task<List<Bike>> GetBikesAsync();
        Task<bool> UpdateBikeAsync(BikeDto updatebike);
    }
}