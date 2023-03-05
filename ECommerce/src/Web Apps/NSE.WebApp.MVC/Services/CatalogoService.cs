using Microsoft.Extensions.Options;

using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Services
{
    public class CatalogoService : Service, ICatalogoService
    {
        private readonly HttpClient _httpClient;

        public CatalogoService(HttpClient httpClient, IOptions<AppSettings> settings)
        {
            httpClient.BaseAddress = new Uri(settings.Value.CatalogoUrl);
            _httpClient = httpClient;
        }

        public async Task<ProdutoViewModel> ObterPorId(Guid id)
        {
            var response = await _httpClient.GetAsync($"/catalogo/produtos/{id}");
            TratarErrosResponse(response);
            var result = await DeserializarObjetoResponse<ProdutoViewModel>(response);
            return result ?? new ProdutoViewModel();
        }

        public async Task<IEnumerable<ProdutoViewModel>> ObterTodos()
        {
            var response = await _httpClient.GetAsync("/catalogo/produtos");
            TratarErrosResponse(response);
            var result = await DeserializarObjetoResponse<IEnumerable<ProdutoViewModel>>(response);
            return result ?? Enumerable.Empty<ProdutoViewModel>();
        }
    }
}
