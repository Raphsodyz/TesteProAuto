## O escopo

Sistema para Atualizar o Cadastro

A PROAUTO é especialista em gestão da Proteção Veicular e seguimos firmes na missão de melhorar índices de satisfação dos nossos associados e uma parte importante desse processo é o nosso sistema de atualização cadastral.

Você foi encarregado de desenvolver uma versão dessa aplicação que possui funcionalidadeschave como: atualizar o endereço do associado.

● O associado se autentica pelo seu CPF e sua placa

● O associado visualiza todos os seus dados(Nome, CPF, Placa, Endereço e Telefone)
mas só pode atualizar o endereço.

Outra coisa muito importante por aqui: nós utilizamos largamente serviços restful, portanto é importante que você pense nisso ao implementar sua solução.

QUICK TIP: Avaliaremos a sua implementação da mesma forma que avaliamos os nossos códigos de produção: nós automatizamos testes e nos preocupamos com a organização e leitura do código. Tudo isso para garantirmos entregas contínuas e de valor para os nossos clientes.

Você deve utilizar a linguagem C# para implementação com preferência a utilização do
framework .NET MVC.

PAY ATTENTION: Não é necessário que você se apresse para nos enviar uma solução, a entrega antecipada deste exercício não é um critério de avaliação. Caso o tempo combinado seja insuficiente, não hesite em nos contatar para negociarmos um novo prazo. 

Grande abraço e... go ahead, let's code!!

# Execução do código

Requisitos:

- .Net 6.0
- MySql 8.0
- Visual Studio(Ou visual code, tutorial baseado no visual studio).

Faça o download do código acima.

Dentro do Mysql, crie um banco de dados com o nome que desejar para que a aplicação possa consumir.
Com o código em mãos, abra o arquivo CadastroProAuto.sln pelo visual studio na opção 'Abrir um projeto ou solução'. Dentro projeto, pela direita no 'Gerenciador de Soluções' abra a pasta 'Services' e clique com botão direito em cima do arquivo 'Services' e em 'adicionar/Novo item' crie um arquivo chamado 'appsettings.json'; esse arquivo será utilizado para as interações da aplicação com o seu banco de dados/etc. Dentro do appsettings.json(apague se vier algo escrito), crie uma seção chamada: 

```json
{
"ConnectionStrings":{
  "default":"server= ; database= ; user id= ; password= ;"
  }
}
```

Os campos dentro da opção 'default' a serem preenchidos são:

- Server: O servidor do seu banco de dados ex: localhost, 197.168.0.1 e etc.
- Database: O nome do banco de dados a ser utilizado.
- User id: Seu usuário do Mysql.
- Password: A senha do seu usuário Mysql.

Com o arquivo appsettings.json preenchido, clique com o botão direito na solução 'CadastroProAuto' e selecione 'Propriedades'. Clique na opção 'Vários projetos de inicialização' e com a setinha da janela, mova o projeto 'Services' para a última posição, após clique na opção 'Nenhum' e selecione a opção 'Iniciar'. Clique em 'Aplicar e 'Ok' após essas alterações. Na parte superior do Visual Studio, clique na barra de pesquisa e digite 'Console do Gerenciador de Pacotes'. Dentro do terminal do gerenciador de pacotes aberto em baixo, clique na opção 'Projeto padrão' e selecione a opção 'Data\Data'. No shell de execução do gerenciador de pacotes, faça um migration ao seu banco, digitando o comando 'Add-Migration First'. Após terminar o processo, digite o comando 'Update-Database' para adição das tabelas no banco de dados do Mysql.
Após a inserção das tabelas do banco de dados no Mysql, acesse novamente o arquivo que criamos 'appsettings.json' dentro da pasta services e crie mais um campo chamado "Token" em cima do campo "ConnectionStrings".

```json
"Token":"",
```

No campo "Token", insira dentro das aspas uma chave qualquer que será utilizado para gerar o token JWT da aplicação.
Para finalizar, clique com o botão direito em cima da solução 'CadastroProAuto' e em 'Propriedades'. Coloque a opção 'CadastroMVC' como penúltima e selecione nela também a opção de 'Iniciar', após isso, clique em 'Aplicar' e 'Ok'. Para execução, clique no botãozinho de Play verde escrito 'Iniciar' no Visual Studio.

*Obs.:* Dentro da pasta Cadastro MVC existe outro arquivo 'appsettings.json' do frontend. Este contendo os links com os endpoints da API. O link em desenvolvimento da API está configurado no 'launchSettings.json' para iniciar em "https://localhost:7191" ou "http://localhost:5191".
