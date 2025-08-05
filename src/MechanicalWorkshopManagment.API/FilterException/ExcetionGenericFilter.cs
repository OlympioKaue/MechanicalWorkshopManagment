using MechanicalWorkshopManagment.Communication.Responses.ResponseErro;
using MechanicalWorkshopManagment.Exception.BaseException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MechanicalWorkshopManagment.API.FilterException
{
    /// <summary>
    /// Classe responsável por tratar os erros modificados.
    /// </summary>
    public class ExcetionGenericFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ExceptionGeneric)
            {
                //Erro conhecido 400, 409, 404.
                KnownErrorException(context);
            }
            else
            {
                //Erro desconhecido 500. 
                UnknownErrorException(context);
            }
        }


        private void KnownErrorException(ExceptionContext context) 
        { 
            var exception = (ExceptionGeneric)context.Exception;
            var responseErrors = new GenericResponseErro(exception.ObterErros());

            context.HttpContext.Response.StatusCode = exception.StatusCode;
            context.Result = new ObjectResult(responseErrors);

        }

        private void UnknownErrorException(ExceptionContext context) 
        {
            var responseErrors = new GenericResponseErro("Unknown error - 500");
            context.Result = new ObjectResult(responseErrors);

        }
    }
}
