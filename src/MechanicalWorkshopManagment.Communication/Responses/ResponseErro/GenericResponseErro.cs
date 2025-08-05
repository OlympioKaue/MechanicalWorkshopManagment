using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Communication.Responses.ResponseErro
{
    /// <summary>
    /// Classe responsável por retornar as respostas de erros ao usuário.
    /// </summary>
    public class GenericResponseErro
    {
        public List<string> ResponseErros { get; set; } = []; // LIST DE ERROS.

       
        public GenericResponseErro(string erros)
        {
            ResponseErros = [erros];
        }

        public GenericResponseErro(List<string> erros)
        {
            ResponseErros = erros;
        }
    }
}
