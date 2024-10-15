using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Bproduct
    {
        public List<Product> Get()
        {
            Dproduct datos = new Dproduct();
            var productos = datos.Get();
            return productos;

        }


    }
}
