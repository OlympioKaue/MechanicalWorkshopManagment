using MechanicalWorkshopManagment.Communication.Requests;
using MechanicalWorkshopManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Domain.Repositories
{
    public interface IParts 
    {
        /// <summary>
        /// Adiciona no banco de dados.
        /// </summary>
        /// <param name="createPart"></param>
        /// <returns></returns>
        Task AddPartAsync(Parts createPart); 


        /// <summary>
        /// Atualiza o registro da peça no banco de dados.
        /// </summary>
        /// <param name="updatePart"></param>
        /// <returns></returns>
        void UpdatePart(Parts updatePart); 



        /// <summary>
        /// Obter todas as peças cadastradas no sistema.
        /// </summary>
        /// <returns></returns>
        Task<List<Parts>> GetPartsAllAsync();



        /// <summary>
        /// Obter uma peça pelo ID informado.
        /// </summary>
        /// <param name="idParts"></param>
        /// <returns></returns>
        Task<Parts?> GetPartsByIdAsync(int idParts);


        /// <summary>
        /// Deleta a peça do sistema, não precisa retornar nada.
        /// </summary>
        /// <param name="deletePart"></param>
        void DeletePart(Parts deletePart); 





        /// <summary>
        /// A peça ja existe no sistema com este nome ?.
        /// </summary>
        /// <param name="partExists"></param>
        /// <returns></returns>
        Task<bool?> ThePartsNameExists(string partsName); 



        /// <summary>
        /// Retorne se a peça existe no sistema com o ID informado.
        /// </summary>
        /// <param name="idParts"></param>
        /// <returns></returns>
        Task<Parts?> ThisPartsExistsWithID(int idParts); 




    }
}
