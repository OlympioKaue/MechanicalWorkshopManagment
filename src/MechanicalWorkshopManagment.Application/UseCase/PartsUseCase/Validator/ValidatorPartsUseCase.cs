using FluentValidation;
using MechanicalWorkshopManagment.Communication.Requests.RequestParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsUseCase.Validator
{
    public class ValidatorPartsUseCase : AbstractValidator<RequestPartDTO>
    {
        /// <summary>
        /// Classe responsável por validar os dados de entrada para o registro de peças.
        /// </summary>
        public ValidatorPartsUseCase()
        {
            RuleFor(part => part.Name)
                .NotEmpty().WithMessage("O nome da peça é obrigatório.")
                .Length(2, 100).WithMessage("O nome da peça deve ter entre 2 e 100 caracteres.")
                .Matches(@"^[A-Za-zÀ-ÿ\s]+$").WithMessage("O nome da peça deve conter apenas letras e espaços.");


            RuleFor(part => part.Price)
                .GreaterThan(0).WithMessage("O preço não pode ser menor ou igual a zero."); 



            RuleFor(part => part.Quantity)
                .GreaterThan(0).WithMessage("A quantidade da peça não pode ser menor ou igual a zero.");
        }
    }
}
