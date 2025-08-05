using FluentValidation;
using MechanicalWorkshopManagment.Communication.Requests.RequestPartsBudget;

namespace MechanicalWorkshopManagment.Application.UseCase.PartsBudgetUseCase.Validator
{
    public class ValidatorPartsBudgetUseCase : AbstractValidator<RequestPartBudgetListDTO>
    {
        /// <summary>
        /// Valida os dados enviados via request pelo cliente.
        /// </summary>
        public ValidatorPartsBudgetUseCase()
        {
            RuleForEach(b => b.partBudget).ChildRules(it =>
            {
                it.RuleFor(b => b.PartsId)
                .GreaterThan(0)
                .WithMessage("O ID da peça deve ser maior que zero, erro de digitação.");     

                it.RuleFor(b => b.Quantity)
                .GreaterThan(0).WithMessage("A quantidade deve ser maior que zero.");
            });
                

            
        }
    }
}
