# OHLC Data Processing API

## Descrição

Esta API é projetada para processar dados OHLC (Open, High, Low, Close) e realizar cálculos financeiros como o Índice de Força Relativa (RSI), Bandas de Bollinger e Média Exponencial Móvel (EMA). Além disso, a API pode alimentar um banco de dados SQLite com dados OHLC e fornecer endpoints para consulta desses valores.

## Funcionalidades

- **Processamento de Dados OHLC:** Recebe, processa e armazena dados OHLC no banco de dados SQLite.
- **Cálculo de Indicadores:** Calcula o Índice de Força Relativa (RSI), Bandas de Bollinger e Média Exponencial Móvel (EMA) a partir dos dados armazenados.
- **Consulta de Dados OHLC:** Fornece endpoints para consulta dos valores OHLC armazenados no banco de dados.

## Arquitetura

A API segue a arquitetura limpa (Clean Architecture), dividida nas seguintes camadas:

1. **Apresentação (Presentation):** Contém os controladores e os endpoints da API.
2. **Aplicação (Application):** Contém a lógica de aplicação e os casos de uso.
3. **Core:** Contém as entidades de domínio e interfaces.
4. **Infraestrutura (Infrastructure):** Contém a implementação dos repositórios, serviços e integração com o banco de dados SQLite.

## Tecnologias Utilizadas

- **Linguagem:** C#
- **Plataforma:** .NET 8
- **Banco de Dados:** SQLite

## Endpoints

### Coins

- **GET /Coins: ** Consulta todas as moedas disponíveis na api

### OHLC

- **GET /OhlcHistory/SeedDatabase:** Alimenta a base de dados de acordo com a implementação do codigo
- **GET /OhlcHistory/GetData:** Obtem os dados de open, high, low e close de acordo com o período (retorna apenas o que estiver no banco de dados)

### OhlcStatistics

- **GET /OhlcStatistics:** Obtém os indicadores estatísticos como Bandas de Bollinger, Índice de Força Relativa e Média Móvel Exponencial.

## Contribuição

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues e pull requests.

## Licença

Este projeto está licenciado sob a Licença GNU. Veja o arquivo LICENSE para mais detalhes.
