<div style="display: inline_block">
  <img align="center" height="50" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/csharp/csharp-original.svg" title="C Sharp">
  <img align="center" height="50" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/dotnetcore/dotnetcore-original.svg" title=".NET Core">
  <img align="center" height="50" width="50" src="https://raw.githubusercontent.com/devicons/devicon/master/icons/swagger/swagger-original.svg" title="Swagger">
</div>

<br/>

---


# <img height="30" width="30" src="https://img.icons8.com/?size=100&id=iHI2gDXCsMzH&format=png&color=000000" alt="Brazil" /> Good Hamburguer
Desenvolvimento de uma aplicação back-end em C# com .NET, aplicação dos conceitos de Controladores e Entidades, uso da abordagem DDD (Domain Drive Design), uso do InMemoryContext pra manipulação do banco de dados em memória, Swagger para documentação da API e o uso do ORM Entity Framework.

## Funcionalidades
- **Menu:** Listar todas os itens do menu, Listar todos os sandwiches, Listar todos os extras (Batata Fritas e Bebidas).
- **Order:** Adicionar, Listar todas os pedidos, Atualizar e Remover.

## Regras
- Se o cliente selecionar um sanduíche, batatas fritas e um refrigerante, então o cliente receberá um desconto de 20%.
- Se o cliente selecionar um sanduíche e um refrigerante, então o cliente receberá um desconto de 15%.
- Se o cliente selecionar um sanduíche e batatas fritas, então o cliente receberá um desconto de 10%.
- Cada pedido não pode conter mais de um sanduíche, batatas fritas ou refrigerante. Se dois itens idênticos forem enviados, a API deve retornar uma mensagem de erro exibindo o motivo.

## Requisitos
1. Crie uma API WEB em C# (Versão 8 do .NET Core).
2. Crie um endpoint para listar sanduíches e acompanhamentos.
3. Crie um endpoint para listar apenas sanduíches.
4. Crie um endpoint para listar apenas acompanhamentos.
5. Crie um endpoint para enviar um pedido e retornar o valor que será cobrado ao cliente.
6. Crie um endpoint para listar todos os pedidos.
7. Crie um endpoint para atualizar um pedido.
8. Crie um endpoint para remover um pedido.

## Iniciando o projeto
Defina o projeto GoodHamburguer.API como projeto de inicialização. <br/>
Para definir o projeto `GoodHamburguer.API` como o projeto de inicialização no Visual Studio, siga os passos abaixo:

1. **No Solution Explorer**: Localize o projeto `GoodHamburguer.API`.
2. **Clique com o botão direito** no nome do projeto.
3. Selecione a opção **"Definir como Projeto de Inicialização"** ("Set as Startup Project").

Isso definirá o `GoodHamburguer.API` como o projeto que será executado quando você iniciar a depuração ou execução.

<br/>

---

<br/>

# <img height="30" width="30" src="https://img.icons8.com/?size=100&id=yzSggttkqLf4&format=png&color=000000" alt="English" /> Good Hamburguer
Development of a back-end application in C# with .NET, applying the concepts of Controllers and Entities, using the DDD (Domain-Driven Design) approach, InMemoryContext for manipulating the in-memory database, Swagger for API documentation, and the use of the Entity Framework ORM.

## Features
- **Menu:** List all menu itens, List all sandwiches and List all extras (Fries and Drinks).
- **Order:** Add, List all orders, Update, Remove

## Rules
- If the customer selects a sandwich, fries, and soft drink, then the customer will have 20%
discount.
- If the customer selects a sandwich and soft drink, then the customer will have 15% discount.
- If the customer selects a sandwich and fries, then the customer will have a 10% discount.
- Each order cannot contain more than one sandwich, fries, or soda. If two identical items are
sent, the API should return an error message displaying the reason.

## Requirements
1) Create a WEB API in C# - version 8 of .NET Core (it will not be necessary to include any type of
authentication)
2) Create an endpoint to list sandwiches and extras.
3) Create an endpoint to list sandwiches only.
4) Create an endpoint to list extra only.
5) Create an endpoint to send an order and return the amount that will be charged to the
customer.
6) Create an endpoint to list all orders.
7) Create an endpoint to update an order.
8) Create an endpoint to remove an order. 


## Getting Start
Set the `GoodHamburguer.API` project as the startup project.  
To set the `GoodHamburguer.API` project as the startup project in Visual Studio, follow these steps:

1. **In Solution Explorer**: Locate the `GoodHamburguer.API` project.
2. **Right-click** on the project name.
3. Select the option **"Set as Startup Project"**.

This will set the `GoodHamburguer.API` project as the project that will be executed when you start debugging or running the application.
