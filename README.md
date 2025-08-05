° PROJETO DE (GESTÃO DE OFICINA MECÂNICA) °

# 🚗 Sistema de Orçamento e Vendas - Oficina Mecânica

Este projeto simula o fluxo completo de atendimento de uma oficina mecânica, desde o cadastro do cliente até a finalização da compra e entrega das peças.

## 🛠️ Funcionalidades Principais:

- **Cadastro do Cliente:** O sistema permite que o cliente se cadastre com nome, placa do veículo e CEP.
- **Cadastro de Peças:** O vendedor cadastra previamente as peças disponíveis no sistema, informando nome, preço e quantidade em estoque.
- **Criação de Orçamento:** 
  - O cliente pode montar um orçamento selecionando múltiplas peças e suas respectivas quantidades.
  - O orçamento é fechado após a finalização e não pode mais ser alterado.
  - Orçamento com quantidade de peças acima de (3 uinidades), o sistema calcula 10% em cada peça adquirida, e atualiza o orçamento. 
- **Finalização da Compra:**
  - A compra só é efetivada se o valor pago for igual ou superior ao valor do orçamento.
  - Pagamentos inferiores resultam em rejeição automática da compra.
  - Após finalizaçaõ da compra, o sistema se encarrega de atualizar quantidade da peça comprada.
  - A movimentação de entrada e saída é controlada pelo sistema.
- **Entrega e Localização:**
  - Após a conclusão da compra, o sistema busca automaticamente a localização do cliente via integração com uma API externa de CEP.
  - A entrega é registrada e finalizada, garantindo controle de pedidos entregues.

## 🔐 Regras de Negócio e Segurança:

- Cada orçamento pode conter múltiplas peças, mas só pode ser finalizado uma única vez.
- Após a finalização, o orçamento se torna **imutável**.
- Compras com valor inferior ao orçamento são **negadas automaticamente**.
- O sistema **impede fraudes** bloqueando múltiplas compras ou edições indevidas em orçamentos já finalizados.
- A cada nova compra e entrega, o sistema garante **rastreabilidade completa** das ações realizadas pelo cliente.

## 🧪 Testes Automatizados

- Testes unitários implementados utilizando a biblioteca `xUnit`.
- Cobertura dos principais cenários:
  - Criação de orçamento com múltiplas peças.
  - Tentativas de compra com valor insuficiente.
  - Simulações de entrega.
  - Validações de exceções (ex: cliente inexistente, peça não encontrada, etc.).

## ❗ Tratamento de Erros:

- Uso de **exceptions customizadas** para retorno de mensagens claras ao usuário:
  - `NotFoundException`.
  - `BadRequestException`.
  - `ConflictException`.

## 📐 Arquitetura e Boas Práticas

- Aplicação desenvolvida seguindo o padrão **DDD (Domain-Driven Design)**:
  - Separação clara entre camadas: `Application`, `Domain`, `Infrastructure`.

- Uso do princípio **SOLID**, com destaque para:
  - **Single Responsibility**: Cada classe possui uma responsabilidade bem definida.
  - **Dependency Inversion**: Uso intensivo de interfaces para inversão de dependência.
  - **Injeção de Dependência** aplicada em todos os serviços e repositórios.
  - **Interfaces** utilizadas para abstrair regras de negócio e facilitar testes unitários.
  - **Responsabilidade única para os casos de uso** (Use Cases), centralizando as regras da aplicação.

## 🌐 Integrações:

- Integração com API externa de CEP para buscar dados de localização do cliente.
- Armazenamento dessas informações no banco de dados para fins de controle de entregas.

## 📂 Tecnologias Utilizadas:

- **.NET Core / C#**.
- **Entity Framework Core**.
- **xUnit** para testes.
- **Moq** para mocks e testes isolados.
- **Swagger** para documentação da API.
- **PostegreSQL** para persistência dos dados.

---
