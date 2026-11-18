## Resumo

<!-- O que foi feito e por quê, em poucas frases. -->

## Issue relacionada

Closes #

## Como testar

<!-- Passos para conferir pelo Swagger ou por teste automatizado. -->

## Checklist

- [ ] `dotnet test -c Release` passa localmente
- [ ] Regras de negócio estão no Service, não no Controller
- [ ] Testes de regra de negócio e de endpoint incluídos
- [ ] Dados isolados por usuária (nada de outra usuária aparece)
- [ ] Nenhum segredo, senha ou string de conexão no código
- [ ] Commits no padrão Conventional Commits
- [ ] Mudança de modelo tem migration com nome descritivo
