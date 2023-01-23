<body>
    <h1 align="center">API criada para prática de Serialização de arquivos.</h1>
    <p>Utilizando a linguagem de programção C# e documentação em swagger.</p>
    <p>O projeto consiste em criar uma API que possa cadastrar e gerir enquetes.</p>
    
    <h2>Cadastro de Enquete</h2>
    <p>Para o cadastro é necessário passar como parametro o título para a enquete no campo designado e porfim a array com os candidatos a voto.</p>
    <img src="src/Screenshots/cadastro.png" alt="">
    
    <h2>Contagem</h2>
    <p>Sabendo o nome das enquetes em andamento, é possivel fazer a busca pelo nome dela e verificar quais são os itens mais votados.</p>
    <img src="src/Screenshots/apuracao.png" alt="">
    
    <h2>Votação</h2>
    <p>Para adicionar o voto em uma enquete é necessário saber o nome da enquete e o ID do candidato a voto. Assim, preenche os campos desejados para adicionar o voto.</p>
    <img src="src/Screenshots/votar.png" alt="">

    <h2>Verificar Enquetes</h2>
    <p>Quando não souber as enquetes que estão acontecendo, pode utilizar o campo de buscar enquetes. Nele não é necessário nenhum parametro. Apenas executando ele faz uma varredura e dispobiliza o nome das enquetes que estão ativas.</p>
    <img src="src/Screenshots/verificarEnquetes.png" alt="">
    
    <p>Obs: Projeto criado em .net 7.0</p>
    <p>Para rodar o projeto em seu computador, basta fazer o download deste repositório</p>
    <p>Para iniciar o swagger utilizar o cli: "dotenet watch run"</p>
</body>