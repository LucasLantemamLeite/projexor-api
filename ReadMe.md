# Projexor-Api

> Projeto em desenvolvimento

Projexor-Api é a parte do servidor do Projexor, um gerenciador de projetos. A primeira versão permitirá criar, excluir e atualizar projetos, além de contar com sistema de usuários e grupos de projetos compartilhados. O projeto será dividido em duas aplicações: Projexor-Web (Backend e Frontend) para portfólio e treinamento, e Projexor-Mobile, focado no uso pessoal e suporte a projetos futuros.

### Características

* **Monolítico**: Todo o servidor está centralizado.
* **APIs REST**: Requisições via rotas.
* **MVC**: Estrutura para simplicidade e organização.
* **Vertical Slice Architecture**: Divisão por features em pastas para melhor organização.

### Banco de Dados

* **SQL Server**: Persistência de dados.

### Ferramentas

* **Docker**: Simulação do banco de dados local.
* **Postman**: Teste de requisições.
* **VSCode**: Editor principal.
* **Entity Framework Core**: Acesso a dados e versionamento do banco.
* **Beekeeper Studio**: Visualização das tabelas criadas.
* **Swagger**: Documentação e testes da API seguindo OpenAPI.