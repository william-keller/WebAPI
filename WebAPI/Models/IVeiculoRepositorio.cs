using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    interface IVeiculoRepositorio
    {
        IEnumerable<Veiculo> GetAll();
        Veiculo Get(int id);
        Veiculo Add(Veiculo item);
        void Remove(int id);
        bool Update(Veiculo item);
    }
}
