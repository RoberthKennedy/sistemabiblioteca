# 📚 Sistema de Biblioteca Universitária

Uma aplicação web moderna, robusta e responsiva construída com a plataforma **.NET Core**, seguindo rigorosamente o padrão de arquitetura **MVC (Model-View-Controller)**. O sistema foi desenvolvido para oferecer um gerenciamento inteligente de livros, acervo acadêmico e produtos integrados.

---

## 🎨 Identidade Visual & Interface

O projeto conta com uma interface clean e profissional baseada no **Bootstrap**, totalmente personalizada com uma paleta de cores moderna em tons de azul elétrico e degradês dinâmicos.

- **Design Consistente:** Telas de listagem, cadastro, edição e login unificadas.
- **Experiência do Usuário (UX):** Cards interativos com efeitos de elevação (_hover_), tabelas responsivas e _inputs_ flutuantes.
- **Iconografia:** Integração completa com o _Bootstrap Icons_.

---

## 🛠️ Tecnologias e Recursos Utilizados

- **Backend:** .NET Core (C#)
- **Padrão Arquitetural:** Model-View-Controller (MVC)
- **Frontend:** Razor Views (HTML5, CSS3, JavaScript)
- **Estilização:** Bootstrap 5 & Bootstrap Icons
- **Validação:** ASP.NET jQuery Validation (Client-side)

---

## 🚀 Funcionalidades Principais

### 🔹 Área Pública

- **Página Inicial (Home):** Banner de boas-vindas (_Hero Section_) com busca integrada e vitrine dinâmica de livros através de cards estilizados.
- **Sobre Nós:** Página institucional apresentando a história, indicadores de impacto (estatísticas do acervo) e os valores da biblioteca.
- **Nossos Produtos/Acervo:** Vitrine pública com paginação, filtros e limite inteligente de descrição para manter o alinhamento visual.
- **Contato:** Formulário de envio de mensagens integrado com validação em tempo real e exibição dos canais de atendimento diretos.

### 🔹 Área Administrativa (Restrita)

- **Controle de Acesso:** Tela de login segura para administradores do sistema.
- **Gerenciamento do Acervo (CRUD Completo):**
  - Listagem administrativa com busca em tempo real e badges de categorias.
  - Cadastro de novos títulos com formulários organizados em grids.
  - Edição de itens existentes com preservação de integridade de dados (`id` oculto).
  - Exclusão de registros do sistema.

---

## 📂 Estrutura do Projeto

Abaixo estão as principais pastas que compõem a arquitetura MVC do sistema:

```text
sistemabiblioteca/
│
├── Controllers/           # Lógica de controle e rotas da aplicação
├── Models/                # Definição das entidades e view models (Ex: Produto, Livro)
└── Views/                 # Páginas Razor (.cshtml) divididas por contexto
    ├── Home/              # Index (Página Inicial) e Sobre
    ├── Produto/           # Criar, Editar, Listar e Vitrine
    ├── Contato/           # Formulário Fale Conosco
    └── Shared/            # Layout principal (_Layout.cshtml) e validações
```
