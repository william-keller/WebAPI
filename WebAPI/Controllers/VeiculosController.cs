using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;
//rgetrhrthrty
namespace WebAPI.Controllers
{
    public class VeiculosController : ApiController
    {
        static readonly IVeiculoRepositorio repositorio = new VeiculoRepositorio();

        public IEnumerable<Veiculo> GetAllVeiculos()
        {
            return repositorio.GetAll();
        }

        public Veiculo GetVeiculo(int id)
        {
            Veiculo item = repositorio.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Veiculo> GetVeiculosPorMarca(string marca)
        {
            return repositorio.GetAll().Where(
                p => string.Equals(p.Marca, marca, StringComparison.OrdinalIgnoreCase));
        }

        public HttpResponseMessage PostVeiculo(Veiculo item)
        {
            item = repositorio.Add(item);
            var response = Request.CreateResponse<Veiculo>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutVeiculo(int id, Veiculo veiculo)
        {
            veiculo.Id = id;
            if (!repositorio.Update(veiculo))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteVeiculo(int id)
        {
            Veiculo item = repositorio.Get(id);

            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repositorio.Remove(id);
        }
    }
}
