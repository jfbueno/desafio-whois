# Whois.NET

Esta aplicação tem como objetivo solucionar o problema do desafio para desenvolvedores.

Para facilitar os testes, eu mesmo fiz uma publicação dela, usando minha conta de estudante no Azure. Ela pode ser acessada pelo link [umbler-whoisapp.azurewebsites.net](https://umbler-whoisapp.azurewebsites.net).

**Observação**: Como usei uma conta gratuita tanto para os servidor da aplicação quanto para o servidor do MongoDB, a aplicação pode apresentar algum _delay_. Principalmente no primeiro acesso.




# Instruções de publicação

Para rodar a aplicação são necessárias as seguintes ferramentas

 * IIS (Internet Information Services)
 * MongoDB


# 1. Publicação local com o Visual Studio 

Compilar e realizar o _deploy_ da aplicação com o Visual Studio.

### Compilando

Abra o arquivo `.sln` com o Visual Studio, entre no menu `Build` e clique na opção `Rebuild`.

Abra o menu `Build` novamente, clique em `Publish DesafioWhois`.

Isso abrirá a janela de publicação.

1. Em "**_Select a publish target_**", clique em **Custom** e entre com um nome qualquer na janela que vai abrir;

2. Em **_Publish Method_** escolha a opção **_File System_**;

3. Em **_target location_** selecione o caminho onde os arquivos de publicação devem ser gerados;

4. Clique no botão <kbd>Publish</kbd>.

### Configuração do IIS

1. Abra o IIS e crie um novo _Web Site_;

2. Escolha um nome qualquer e em "**_Physical location_**" selecione o mesmo diretório que foi definido na publicação do Visual Studio;

# 2. Publicação com os arquivos de _deploy_ pré-gerados

Pra facilitar um pouco, gerei os arquivos necessários para publicação e coloquei numa pasta zipada. Esta pasta pode ser baixada [aqui](http://AlgumLink).

Para fazer esta publicação, extraia os arquivos em uma pasta qualquer, crie uma aplicação no IIS e em "**_Physical location_**" selecione o caminho onde estão os arquivos extraídos. 

# Configuração de ambiente

Após realizar a publicação da aplicação é necessário configurar os parâmetros usados para conexão ao MongoDB. 

1. Abra o arquivo `web.config` e procure pela tag **`appKeys`**;

2. Procure pelos pares de chave-valor que contém chaves iniciadas com "Mongo" e altere conforme as configurações do seu servidor MongoDB;

   ```
   <add key="MongoUrl" value="mongodb://localhost:27017" />
   <add key="MongoDb" value="db" />
   <add key="MongoCollection" value="dominios" />
   ```

**Observação:** O banco de dados (`MongoDb`) e a _collection_ (`MongoCollection`) **não precisam** ser criados de antemão. Caso eles não existam, a aplicação se encarregará de criá-los.
