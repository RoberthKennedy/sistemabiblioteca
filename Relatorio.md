Relatório Técnico – Sistema Biblioteca ASP.NET Core MVC
Introdução
Durante o desenvolvimento do sistema da Biblioteca utilizando ASP.NET Core MVC, Entity Framework Core e SQLite, utilizamos diversas tecnologias importantes que facilitam a criação e manutenção da aplicação. Neste relatório, explico de forma simples como essas ferramentas funcionam e qual a importância delas para o projeto.
Injeção de Dependência (Dependency Injection)
O que é Injeção de Dependência?
A Injeção de Dependência é um recurso muito utilizado no ASP.NET Core para evitar que uma classe precise criar seus próprios objetos. Em vez disso, o próprio framework fornece esses objetos quando necessário.
No nosso projeto, isso acontece quando o Controller precisa acessar o banco de dados. O ASP.NET cria e entrega automaticamente uma instância do DbContext, deixando o código mais organizado e fácil de manter.
Além disso, a Injeção de Dependência traz várias vantagens:
• Reduz o acoplamento entre as classes;
• Facilita a manutenção do sistema;
• Torna o código mais organizado;
• Facilita a realização de testes.
Ciclos de Vida dos Serviços
No arquivo Program.cs podemos registrar serviços com diferentes tempos de vida.
Transient
Uma nova instância é criada toda vez que o serviço é solicitado.
É indicado para serviços simples que não precisam armazenar informações.
Scoped
Uma única instância é criada para cada requisição realizada pelo usuário.
Esse é o modelo utilizado pelo Entity Framework Core, pois garante segurança e evita problemas de concorrência.
Singleton
Apenas uma instância é criada e compartilhada por toda a aplicação.
Todos os usuários utilizam o mesmo objeto durante a execução do sistema.
Por que o DbContext não deve ser Singleton?
O DbContext não foi desenvolvido para ser compartilhado entre vários usuários ao mesmo tempo. Se fosse registrado como Singleton, poderiam ocorrer erros, conflitos de dados e problemas de desempenho.
Por esse motivo, o Entity Framework Core utiliza normalmente o ciclo de vida Scoped.
Entity Framework Core e ORM
O que é um ORM?
ORM significa Object Relational Mapping, ou Mapeamento Objeto-Relacional.
Seu principal objetivo é permitir que o desenvolvedor trabalhe com objetos C# em vez de escrever comandos SQL manualmente.
Assim, quando criamos uma classe chamada Livro, por exemplo, o Entity Framework consegue transformá-la em uma tabela dentro do banco de dados.
Vantagens do ORM
As principais vantagens são:
• Menos código SQL;
• Desenvolvimento mais rápido;
• Menor chance de erros;
• Maior produtividade da equipe;
• Integração direta com a linguagem C#.
O que significa Code-First?
Code-First é uma abordagem onde primeiro criamos as classes da aplicação e depois o banco de dados é gerado automaticamente com base nessas classes.
Ou seja, o desenvolvedor modela o sistema em código e o Entity Framework se encarrega de criar as tabelas necessárias.
Como funcionam as Migrations?
As Migrations servem para registrar todas as alterações realizadas nas entidades do projeto.
Quando adicionamos um novo campo ou uma nova classe, o Entity Framework gera uma Migration contendo as mudanças necessárias para atualizar o banco de dados.
Dessa forma, o banco acompanha a evolução do sistema sem a necessidade de criar tabelas manualmente.
O que acontece ao executar "dotnet ef database update"?
Quando esse comando é executado, o Entity Framework verifica quais alterações ainda não foram aplicadas no banco.
Depois disso, ele gera os comandos SQL necessários e atualiza a estrutura do banco automaticamente.
Para controlar esse processo, ele utiliza uma tabela chamada "\_\_EFMigrationsHistory", que registra todas as migrations já executadas.
SQLite: Vantagens e Limitações
Vantagens do SQLite
O SQLite foi uma ótima escolha para o desenvolvimento do projeto porque é simples e leve.
Entre suas principais vantagens estão:
• Não precisa instalar servidor de banco de dados;
• Fácil configuração;
• Baixo consumo de recursos;
• Banco armazenado em um único arquivo;
• Ideal para estudos, testes e pequenos projetos.
Principal limitação do SQLite
O maior problema do SQLite aparece quando muitas pessoas tentam gravar informações ao mesmo tempo.
Como ele trabalha em um único arquivo, apenas uma operação de escrita pode ocorrer por vez. Quando vários usuários tentam salvar dados simultaneamente, podem ocorrer filas, lentidão e bloqueios.
Cenário com muitos acessos
Se o sistema da Biblioteca crescer e passar a receber milhares de acessos simultâneos, o SQLite provavelmente não conseguirá oferecer o desempenho necessário.
Nessa situação, bancos mais robustos, como PostgreSQL ou SQL Server, se tornam opções mais adequadas.
Quando migrar para PostgreSQL ou SQL Server?
A migração deve ser considerada quando:
• O número de usuários aumentar significativamente;
• O sistema começar a apresentar lentidão;
• Houver necessidade de maior segurança;
• Forem necessários backups mais avançados;
• O projeto passar para um ambiente de produção com muitos acessos.
Conclusão
O ASP.NET Core MVC fornece diversos recursos que facilitam o desenvolvimento de aplicações modernas. A Injeção de Dependência ajuda a organizar o código e reduzir o acoplamento entre as classes. O Entity Framework Core simplifica o acesso ao banco de dados por meio do ORM e da abordagem Code-First. Já o SQLite é uma excelente solução para projetos acadêmicos e ambientes de teste, porém apresenta limitações quando a aplicação cresce e passa a atender muitos usuários simultaneamente. Nesse cenário, a utilização de bancos mais robustos, como PostgreSQL ou SQL Server, torna-se a melhor alternativa.
