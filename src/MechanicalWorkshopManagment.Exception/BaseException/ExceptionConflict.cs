using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Exception.BaseException
{
    /// <summary>
    /// Expcetion do tipo string / Erro 409 Conflict.
    /// </summary>
    public class ExceptionConflict : ExceptionGeneric
    {
       
        public ExceptionConflict(string error) : base(error)
        {
        }

        public override int StatusCode =>(int) HttpStatusCode.Conflict;

        public override List<string> ObterErros()
        {
            return new List<string> { Message };
        }
    }
}
