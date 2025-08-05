using FluentValidation;
using MechanicalWorkshopManagment.Communication.Requests.RequestCustomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalWorkshopManagment.Application.UseCase.CustomerUseCase.Validator
{
    /// <summary>
    /// Valida os dados enviados pelo usuário.
    /// </summary>
    public class ValidatorCustomerUseCase : AbstractValidator<RequestCustomerDTO>
    {
        public ValidatorCustomerUseCase()
        {
            RuleFor(customer => customer.ClientName)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .Length(3, 100).WithMessage("O nome do cliente deve ter entre 3 e 100 caracteres.");

            RuleFor(customer => customer.VehiclePlate)
               .NotEmpty().WithMessage("A placa do veiculo é obrigatória.")
               .Matches(@"^[A-Z]{3}[0-9]{4}$").WithMessage("A placa deve ser seguida por 3 Caractere Maiúsculo e 4 Númericos ex:(ABC0123).");

            RuleFor(customer => customer.CepClient)
              .NotEmpty().WithMessage("O código postal é obrigatório.")
              .Matches(@"^\d{8}$").WithMessage("Apenas 8 dígitos numéricos são aceitos.");
        }
    }
}
