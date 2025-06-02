using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DtoModel;
using DataBaseContext;
using Microsoft.EntityFrameworkCore;

namespace EntityRepository
{
    public class BikeRepository : IBikeRepository
    {
        private readonly Database _db;

        public BikeRepository(Database db)
        {
            _db = db;
        }

        public async Task<List<Bike>> GetBikesAsync()
        {
            List<Bike> bikes = new List<Bike>();
            try
            {
                bikes = await _db.bikes.ToListAsync();
            }
            catch (Exception)
            {
                return null;
            }
            return bikes;
        }

        public async Task<Bike> GetBikeAsync(int id)
        {
            Bike bike = new Bike();

            try
            {
                bike = await _db.bikes.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
            return bike;
        }

        public async Task<bool> createBikeAsync(Bike CreateBike)
        {
            try
            {
                await _db.bikes.AddAsync(CreateBike);
            }
            catch (Exception)
            {
                return false;
            }
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBikeAsync(Bike updatebike)
        {
            //updatebike har alle values, ændret og ikke ændret
            Bike bike = new Bike
            {
                Id = updatebike.Id,
                Brand = updatebike.Brand,
                Model = updatebike.Model,
                Year = updatebike.Year,
                Horsepower = updatebike.Horsepower,
                Description = updatebike.Description,
                Colour = updatebike.Colour,
                Userid = updatebike.Userid
            };


            _db.bikes.Update(bike);
            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> DeleteBikeAsync(int id)
        {
            Bike bike = new Bike { Id = id };

            _db.bikes.Remove(bike);

            try
            {
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
