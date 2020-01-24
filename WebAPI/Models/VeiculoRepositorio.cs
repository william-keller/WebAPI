using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Models
{
    public class VeiculoRepositorio : IVeiculoRepositorio
    {
        private List<Veiculo> veiculos = new List<Veiculo>();
        private int _nextId = 1;

        public VeiculoRepositorio()
        {
            Add(new Veiculo { Nome = "Cruze", Marca = "Chevrolet", Preco = 10000, Cor = "Vermelho" });
            Add(new Veiculo { Nome = "C4", Marca = "Citroen", Preco = 15000, Cor = "Amarelo" });
            Add(new Veiculo { Nome = "Punto", Marca = "Fiat", Preco = 13000, Cor = "Azul" });
            Add(new Veiculo { Nome = "Clio", Marca = "Renault", Preco = 14000, Cor = "Verde" });
        }

        public Veiculo Add(Veiculo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextId++;
            veiculos.Add(item);
            return item;
        }

        public Veiculo Get(int id)
        {
            return veiculos.Find(p => p.Id == id);
        }

        public IEnumerable<Veiculo> GetAll()
        {
            return veiculos;
        }

        public void Remove(int id)
        {
            veiculos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Veiculo item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            int index = veiculos.FindIndex(p => p.Id == item.Id);

            if (index == -1)
            {
                return false;
            }
            veiculos.RemoveAt(index);
            veiculos.Add(item);
            return true;
        }
    }
}