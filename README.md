# StockPharma

# Guia de Login no Sistema Localmente

Este documento fornece as instruções para configurar e rodar o sistema localmente.

## 1. Ligar o SQL Server

Certifique-se de que seu SQL Server está rodando na máquina local. Você pode fazer isso através do SQL Server Management Studio (SSMS) ou pelo `SQL Server Configuration Manager`.

## 2. Executar o Publicado

1. Localize o arquivo `publish.rar` e extraia seu conteúdo.
2. Dentro da pasta extraída, execute o arquivo do sistema.

## 3. Configurar a Conexão com o Banco de Dados

1. Abra o arquivo `appsettings.json` na pasta do sistema extraído.
2. Encontre a seção `ConnectionStrings` e altere a string de conexão para apontar para o seu SQL Server local. Exemplo:
   
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=SEU_SERVIDOR;Database=StockPharma;User Id=SEU_USUARIO;Password=SUA_SENHA;"
   }
   ```

## 4. Executar o Script do Banco de Dados

Após configurar a conexão com o banco de dados, execute o script SQL para criar as tabelas e inserir os dados iniciais:

1. Abra o SQL Server Management Studio (SSMS) e conecte-se ao seu servidor SQL local.
2. Localize o arquivo `Script StockPharma.sql` e abra-o no SSMS.
3. Execute o script para criar e popular o banco de dados.

## 5. Acessar o Sistema

Após seguir os passos acima, você poderá acessar o sistema normalmente. Caso encontre algum erro, verifique se o SQL Server está ativo e se a string de conexão está correta.

