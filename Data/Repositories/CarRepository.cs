using Data.Abstracts;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CarRepository : GeneralRepository<Car>, ICar
    {
        private readonly CarContext _context = new CarContext();

        public List<Car> GetByCategoryId(int id)
        {
            return _context.Cars.Where(i => i.CategoryId == id).ToList();
        }

        public List<Car> GetByCategoryIdList(int categoryId,int page)
        {
            var cars = GetByCategoryId(categoryId);
            return cars.Skip((page - 1) * 4).Take(4).ToList();
        }
    }
}
