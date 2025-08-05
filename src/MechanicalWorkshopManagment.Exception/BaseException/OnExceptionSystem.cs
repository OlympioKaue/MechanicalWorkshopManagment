using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Exception.BaseException
{
    /// <summary>
    /// Exception do tipo string e List/ Erro 400 BadRequest.
    /// </summary>
    public class OnExceptionSystem : ExceptionGeneric
    {
        private readonly List<string> _erros;


        public OnExceptionSystem(List<string> erros) : base(string.Empty)
        {
            _erros = erros;
        }

        public OnExceptionSystem(string erros) : base(erros)
        {
            _erros = [erros];
        }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> ObterErros()
        {
            return _erros;
        }
    }
}
