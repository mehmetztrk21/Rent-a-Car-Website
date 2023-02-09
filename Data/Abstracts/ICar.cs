using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstracts
{
    public interface ICar:IGeneral<Car>
    {
        List<Car> GetByCategoryId(int id);
        List<Car> GetByCategoryIdList(int CategoryId,int page);
    }
}
