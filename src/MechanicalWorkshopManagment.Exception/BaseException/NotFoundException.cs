using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Exception.BaseException
{
    /// <summary>
    /// Exception do tipo string e List / Erro 404 NotFound.
    /// </summary>
    public class NotFoundException : ExceptionGeneric
    {
        
        public NotFoundException(string MessageError) : base(MessageError) { }
        

        public NotFoundException(List<string> message) : base($"{message}") { }
        
        public override int StatusCode => (int)HttpStatusCode.NotFound;


        public override List<string> ObterErros()
        {
            return new List<string> { Message };
        }
    }
}
