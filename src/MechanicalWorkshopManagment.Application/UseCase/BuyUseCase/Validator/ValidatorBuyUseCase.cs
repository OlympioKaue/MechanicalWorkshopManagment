using FluentValidation;
using MechanicalWorkshopManagment.Communication.Requests.RequestBuy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.BuyUseCase.Validator
{
    public class ValidatorBuyUseCase : AbstractValidator<RequestBuyDTO>
    {
        /// <summary>
        /// Valida os dados da enviados pelo cliente no momento da compra de peças.
        /// </summary>
        public ValidatorBuyUseCase()
        {

            RuleFor(y => y.CostPrice)
                .GreaterThan(0).WithMessage("O preço de custo tem que ser maior que zero.");
        }
    }
}
