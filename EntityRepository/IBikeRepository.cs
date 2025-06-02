using Model;

namespace EntityRepository
{
    public interface IBikeRepository
    {
        Task<bool> createBikeAsync(Bike CreateBike);
        Task<bool> DeleteBikeAsync(int id);
        Task<Bike> GetBikeAsync(int id);
        Task<List<Bike>> GetBikesAsync();
        Task<bool> UpdateBikeAsync(Bike updatebike);
    }
}