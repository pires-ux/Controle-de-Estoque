const apiMostrar = "https://localhost:7140/api/Produto/Mostrar"


const tela = document.querySelectorAll("body")

window.addEventListener("load", async function Mostrar() {
    console.log("Página completamente carregada!");

    var response = await fetch(apiMostrar).then(r => r.json());

    Listar(response);
});



function Listar(response){
    var produtos = response;
    console.log(produtos)

    var tabela = document.querySelector("tbody")
    produtos.forEach(produto => {
        const linha = document.createElement("tr");

        linha.innerHTML = `
            <td>${produto.produtoNome}</td>
            <td>${produto.descricao}</td>
            <td>${produto.preco}</td>
            <td>${produto.quantidade}</td>
            <td>${produto.totalValor}</td>
            <td>
                <button class ="editar">E</button>
                <button class ="excluir">L</button>
            </td>
        `;

        tabela.appendChild(linha);
    });
}







