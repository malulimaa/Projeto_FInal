# Regras do projeto: API de controle de treinos

API REST para mulheres que treinam sozinhas registrarem cargas e repetições
e consultarem a própria evolução. Não há front-end: o cliente é o Swagger.

## Estrutura do repositório

- `ControleTreino.slnx`: solução, na raiz.
- `ControleTreinoApi/`: a API (Controllers, Services, Repositories, Models, Data).
- `ControleTreinoApi.Tests/`: testes (xUnit), ao lado da API.
- `.github/workflows/ci-cd.yml`: CI (build e testes) e publicação do pacote.

## Comandos

```
dotnet restore
dotnet build -c Release
dotnet test -c Release
```

Todos devem passar antes de abrir um Pull Request.

## Stack e arquitetura

- .NET 10, Entity Framework Core com migrations, SQLite, autenticação por token (JWT), xUnit.
- Camadas: Controller -> Service -> Repository.
  - Controller: recebe a requisição, chama o Service e devolve a resposta.
  - Service: contém TODAS as regras de negócio.
  - Repository: acesso a dados.
- Cada mudança no modelo gera uma migration com nome que descreve a mudança.
- Entrada inválida responde 400 com mensagem que aponta o campo.

## Segurança

- Senha guardada apenas como hash. Mínimo de 8 caracteres.
- Todas as rotas exigem token, exceto cadastro e login. Sem token ou token inválido: 401.
- Login negado não informa se o erro foi no e-mail ou na senha.
- Cada usuária acessa apenas os próprios dados.
- NUNCA colocar senhas, strings de conexão ou a chave do token no código ou no
  repositório. Usar user-secrets ou variáveis de ambiente.

## Regras de negócio

1. Carga >= 0 (zero é válido para exercícios sem peso). Repetições de 1 a 100.
2. A maior carga vem só do que foi registrado. O plano nunca entra na conta.
3. Uma sessão só aceita séries do próprio treino.
4. Editar o plano não altera o histórico já registrado.
5. Agrupamento por semana começa na segunda-feira. Por mês: do dia 1 ao último dia.
6. Série sem carga registrada fica fora da maior carga e do histórico.
7. Exercício que está em algum treino não pode ser excluído.
8. Exercícios, treinos e registros de outra usuária não aparecem (como se não existissem).
9. E-mail único por conta.
10. Exercício que nunca foi registrado: a API informa que não há registro, nunca responde 0 kg.

Outras validações: nome do exercício de 2 a 60 caracteres; grupo muscular entre
Peito, Costas, Pernas, Ombros, Braços, Abdômen ou Outro; ordem das séries única
dentro do treino; treino precisa de pelo menos uma série.

## Testes

- Escrever testes para as regras de negócio e para os endpoints principais
  (código de resposta e formato dos dados).
- Marcar testes de regra de negócio com `[Trait("Category", "Unit")]`.
- `dotnet test` deve rodar localmente, sem depender do banco publicado.

## Git

- Uma branch por funcionalidade. Nunca commitar direto na `main`.
- Commits no padrão Conventional Commits: `feat:`, `fix:`, `test:`, `docs:`, `refactor:`, `chore:`.
- Um Pull Request por funcionalidade, ligado a uma issue (`Closes #número`).
- Todo PR é revisado por uma pessoa do grupo antes do merge.

## Limites para agentes de IA

- Trabalhar só no escopo da issue indicada. Não refatorar nem alterar arquivos fora dele.
- Não alterar `.github/workflows/` nem este arquivo sem pedido explícito.
- Não inventar regras: se algo não estiver aqui nem na issue, perguntar.
