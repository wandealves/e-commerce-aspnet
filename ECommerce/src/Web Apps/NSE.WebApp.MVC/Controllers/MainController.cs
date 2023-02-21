using Microsoft.AspNetCore.Mvc;

using NSE.WebApp.MVC.Models;

namespace NSE.WebApp.MVC.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult? responseResult)
        {
            if (responseResult != null && responseResult.Errors.Messagens.Any())
            {
                foreach (var mensagem in responseResult.Errors.Messagens)
                {
                    ModelState.AddModelError(string.Empty, mensagem);
                }
                return true;
            }

            return false;
        }
    }
}
