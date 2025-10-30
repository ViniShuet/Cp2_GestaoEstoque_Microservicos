# Cp2_GestaoEstoque_Microservicos

## 👥 Integrantes do Projeto

- **Amanda Cornelsen** — RM97760  
- **Vinicius Shuet** — RM98160

# 🏷️ Gestão de Estoques

Sistema desenvolvido para controle de produtos e movimentações de estoque, com suporte a produtos perecíveis, relatórios automáticos e validações completas de integridade.

---

## 🧩 Descrição das Regras de Negócio Implementadas

O sistema **Gestão de Estoques** foi desenvolvido com foco em integridade e consistência das informações, garantindo que todas as movimentações de produtos respeitem as regras do negócio definidas.

### 🔒 Regras Gerais

- **Produto Perecível:**
  - Deve possuir obrigatoriamente uma **data de validade**.  
  - Não pode sofrer movimentações (entrada/saída) **após o vencimento**.

- **Produto Não Perecível:**
  - **Não deve possuir data de validade.**

- **Validações de Quantidade:**
  - A **quantidade informada** deve ser sempre **positiva**.  
  - Não é permitido realizar **saídas com quantidade maior que o estoque atual.**

- **Atualização Automática de Estoque:**
  - Entradas somam ao saldo do produto.
  - Saídas subtraem do saldo do produto.

- **Estoque Mínimo:**
  - Caso o estoque esteja abaixo da quantidade mínima, o sistema exibe um **alerta visual (⚠️)**.

- **Relatórios:**
  - Cálculo do **valor total do estoque** (`quantidade × preço unitário`).
  - Identificação de **produtos vencendo em até 7 dias**.
  - Listagem de **produtos abaixo do estoque mínimo**.

---

## 🧱 Diagrama Simples das Entidades

Representação textual das entidades do sistema:

Produto
  - Id (int)
  - Nome (string)
  - PrecoUnitario (decimal)
  - Perecivel (bool)
  - DataValidade (DateTime?)
  - EstoqueAtual (int)
  - QtdMin (int)

MovEstoque
  - Id (int)
  - ProdutoId (int)
  - Qtd (int)
  - DataMovimentacao (DateTime)

## 📡 Exemplos de Requisições da API

A API pode ser testada diretamente pelo **Swagger** (`https://localhost:{porta}/swagger`) ou usando ferramentas como **Postman** ou **cURL**.

---

### 🟢 1. Cadastrar Produto

**Endpoint:** `POST /api/produtos`  
**Descrição:** Cadastra um novo produto no sistema.

**Requisição:**
```json
{
  "nome": "Leite Integral",
  "precoUnitario": 4.50,
  "perecivel": true,
  "dataValidade": "2025-11-30",
  "estoqueAtual": 50,
  "qtdMin": 10
}
```
Resposta
```

{
  "id": 1,
  "nome": "Leite Integral",
  "precoUnitario": 4.50,
  "perecivel": true,
  "dataValidade": "2025-11-30T00:00:00",
  "estoqueAtual": 50,
  "qtdMin": 10
}
```
## ⚙️ Como Executar o Projeto

### 🧾 Pré-requisitos

Antes de executar o projeto, certifique-se de ter instalado:

- [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- [MySQL](https://dev.mysql.com/downloads/) instalado e em execução
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Banco de dados criado (exemplo: `fiap`)
- Git configurado (para clonar e versionar o repositório)

---

### 🚀 Passos para Execução

#### 1. Clonar o repositório

```bash
git clone https://seurepositorio.com/gestaoestoquesln.git
cd gestaoestoquesln
