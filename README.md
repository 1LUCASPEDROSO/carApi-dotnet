# Cars-api
 Projeto de API Rest usando DTO pra testes

## como acessar documento API SWAGGER
Após iniciar o projeto e subir corretamente acesse o domínio: http://localhost:5067/ para visualizar os modelos  ou para fazer Request e Response 

## Documentação

Documento ApiCars
Este projeto foi construído usando C# 9.0 com dotnet versão 9.0.1 com
entity-framework EF-core para criação e manipulações de entidades,
postgreSQL e estruturado seguindo o padrão arquitetural Clean-architecture, onde cada camada desempenha um papel na organização e
na funcionalidade da aplicação que foi Dividido em Infrastructure com repositories para entidades controle de versões contexto de banco de dados,Domain para abrigar entidades e  regras de negócio puras como o Enum de tipos de combustível, Application para interfaces de repositories, interfaces de regras de negócio e suas implementações e DTOs
(data transfer object) e API para Controller para expor endpoints rest.

Entity: As Entities representam as tabelas no banco de dados. Elas são
usadas para mapeamento objeto-relacional, permitindo a
persistência dos dados.

### Repository:
Os Repositories proporcionam uma abstração sobre o acesso aos
dados. Eles permitem que os serviços e lógicas de negócio interajam com as entidades
para realizar operações. Foram utilizados para transformar e modelar dados para os
endpoints de GET/POST/PUT/DELETE.

### Service: 
A camada de services contém a lógica da aplicação de CRUD e
modelagem de dados por DTO.

### Controller:
Os Controllers expõem endpoints REST para interação com a
aplicação. Eles recebem requisições HTTP, e baseado na opção HTTP as operações
para os serviços apropriados e retornam as respostas correspondentes, muitas vezes
usando objetos DTO (Data Transfer Objects) para estruturar os dados de saída.
Este padrão proporciona uma separação clara de responsabilidades entre os diferentes
componentes da aplicação, facilitando a manutenção, escalabilidade e testabilidade do
sistema.

#### ERD de estrutura do projeto:

### Justificação de escolha de CrossOrigin
Baseado na hipótese de que o frontend seja hospedado em outro domínio, foi utilizado
a anotação @CrossOrigin(origins = "*") em TODOS controllers para que seja liberada
para qualquer aplicação fazer requisições, podendo no futuro ou em ambiente de
deploy ser alterado para o domínio específico de aplicação a qual a API servirá.


http://localhost:5067/models / POST

{
"brand_id": 0,
"name": "string",
"fipe_value": 0
}

http://localhost:5067/cars / POST

{
"id": 0,
"registerDate": "2024-08-20T02:46:36.462Z",
"modelId": 0,
"year": 0,
"gasType": "string",
"numDoors": 0,
"color": "string",
}

http://localhost:5067/brands / POST

{
"id": 0,
"name_brand": "string"
}

### Dependências utilizadas

Entity-framework
postgreSQL

Repositório no GitHub: https://github.com/1LUCASPEDROSO/cars-api-dotnet


