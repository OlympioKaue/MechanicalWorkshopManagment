using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Exception.BaseException
{
     /// <summary>
     /// Exception do tipo Generico, Herda de SystemException
     /// </summary>
    public abstract class  ExceptionGeneric : SystemException
    {
        protected ExceptionGeneric(string MessageError) : base(MessageError)
        {
        }
       
        /// <summary>
        /// Atributo abstrato que revela o Status Code = 400, 404, 409 e 500.
        /// </summary>
        public abstract int StatusCode { get; }
        /// <summary>
        /// Atributo que obtem o erros no formato de List.
        /// </summary>
        /// <returns></returns>
        public abstract List<string> ObterErros();
    }
}
