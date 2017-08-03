# Whois.NET

## Publicação local com o Visual Studio

Para realizar o _deploy_ da aplicação são necessários as seguintes ferramentas

 * IIS (Internet Information Services)
 * MongoDB
 * Visual Studio

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

