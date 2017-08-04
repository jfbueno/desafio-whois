# Whois.NET

Esta aplicação foi desenvolvida para solucionar o problema do desafio para desenvolvedores.
  
### Funcionamento da aplicação

A aplicação tem como principal objetivo buscar informações sobre domínios. Ao entrar com um domínio são buscadas as informações do mesmo usando a [**WhoAPI**](https://whoapi.com/).

Os dados que já foram consultados são salvos como cache para que possam ser consultados com mais agilidade nas próximas consultas. Os registros de cache expiram em 10 dias, ou seja, 10 dias após consultar o domínio `exemplo.com` o registro salvo no cache interno será ignorado a aplicação buscará novamente os dados atualizados da API.

### Tecnologias utilizadas

 1. Backend  
     * C#
     * ASP.NET MVC
     * ASP.NET Web API
     
2. Frontend 
    * JavaScript
    * AngularJS

3. Banco de dados de _caching_ 
    * MongoDB

### Construção da aplicação

Esta aplicação é uma _Single Page Application_ construída com AngularJS que consome uma API escrita em C# usando ASP.NET WebAPI. A API contém dois _endpoints_.

### Endpoints da API

 * **`api/buscar/{dominio}`**: 
 
      Busca informações sobre o domínio (enviado por parâmetro na URL, tanto _inline_ quanto por _query string_.   
  
     Exemplo de requisição: **`http://exemplo/api/buscar?dominio=umbler.com`** ou **`http://exemplo/api/buscar/umbler.com/`** (notar a barra no final).
   
 * **`api/atualizarcache/{idRegistro}`**:

      Busca as informações do domínio, ignorando o cache interno e atualizando o mesmo.

      Exemplo de requisição: **`http://exemplo/api/atualizarcache?idRegistro=59834f84dc85e94788428ec5`** ou **`http://exemplo/api/buscar/59834f84dc85e94788428ec5`**
      
### Retorno da API

Para as duas solicitações a API vai retornar um JSON (ou um XML) com a mesma estrutura do JSON de exemplo abaixo.

```
{  
   "Dado": {  
      "Id": "59834f84dc85e94788428ec5",
      "NomeDominio": "umbler.com",
      "DataCriacao": "2013-06-03T23:42:15Z",
      "DataExpiracao": "2027-06-03T23:42:15Z",
      "DataAtualizacao": "2017-07-08T19:31:54Z",
      "NameServers": [  
         "ns1.dominio.com",
         "ns1.dominio.com"
      ],
      "Emails":[  
         "alguem@email.com",
         "outroalguem@email.com"
      ],
      "RawInfo": "Uma string gigantesca com quebra de linhas ",
      "Contatos":[  
         {  
            "Nome": "Alguém",
            "Tipo": "admin",
            "Organizacao": "ECMA Org",
            "Fone": "+1 18 6552 4458",
            "Email": "alguem@email.com",
            "EnderecoCompleto": "Rua ECMA, 1080. NY, NY. USA."
         }
      ],
      "ExpiracaoCacheInterno": "2017-08-14T03:00:00Z",
      "Registrado": true,
      "CacheExpirado": false
   },
   "Cacheado": true
}
```

### Testes e publicação

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

Pra facilitar um pouco, gerei os arquivos necessários para publicação e coloquei numa pasta zipada. Esta pasta pode ser baixada [aqui](https://drive.google.com/file/d/0B5jv5pjdNuIvdHRvcGo2Q1pLR0U/view?usp=sharing).

Para fazer esta publicação, extraia os arquivos em uma pasta qualquer, crie uma aplicação no IIS e em "**_Physical location_**" selecione o caminho onde estão os arquivos extraídos. 

# Configuração de ambiente

Após realizar a publicação da aplicação é necessário configurar os parâmetros usados para conexão ao MongoDB. 

1. Abra o arquivo `web.config` e procure pela tag **`appKeys`**;

2. Procure pelos pares de chave-valor que contém chaves iniciadas com "Mongo" e altere conforme as configurações do seu servidor MongoDB;

   ```xml
   <add key="MongoUrl" value="mongodb://localhost:27017" />
   <add key="MongoDb" value="db" />
   <add key="MongoCollection" value="dominios" />
   ```

**Observação:** O banco de dados (`MongoDb`) e a _collection_ (`MongoCollection`) **não precisam** ser criados de antemão. Caso eles não existam, a aplicação se encarregará de criá-los.
