
const apiMostrar = "https://localhost:7140/api/Produto/Mostrar";
const apiExcluir = "https://localhost:7140/api/Produto/Excluir";
const apiEditar = "https://localhost:7140/api/Produto/EditarProduto";

// Elementos do HTML
const tabela = document.querySelector("tbody");
const msgEditar = document.querySelector("#msgEditar");
const formulario = document.querySelector("#formEditar");
const btnCancelar = document.querySelector("#cancelar");

msgEditar.style.display = "none";
let idProdutoEditando = null;

window.addEventListener("load", async function carregar() {
    console.log("Página completamente carregada!");

    const token = localStorage.getItem("jwt");
    const response = await fetch(apiMostrar, {
        method: "GET",
        headers: { "Authorization": `Bearer ${token}` }
    });

    if (!response.ok) {
        console.error("Erro ao carregar produtos:", response.status);
        return;
    }

    const produtos = await response.json();
    Listar(produtos);
});

function Listar(response) {
    const produtos = response;
    tabela.innerHTML = "";

    produtos.forEach(produto => {
        const linha = document.createElement("tr");
        linha.dataset.id = produto.id;

        linha.innerHTML = `
            <td>${produto.produtoNome}</td>
            <td>${produto.descricao}</td>
            <td>${produto.preco}</td>
            <td>${produto.quantidade}</td>
            <td>${produto.totalValor}</td>
            <td>
                <button type="button" class="editar">E</button>
                <button type="button" class="excluir">L</button>
            </td>
        `;
        tabela.appendChild(linha);
    });
}

tabela.addEventListener("click", async function(event) {
    if (event.target.classList.contains("editar")) {
        const linha = event.target.closest("tr");
        idProdutoEditando = linha.dataset.id;
        console.log("ID do produto:", idProdutoEditando);
        msgEditar.style.display = "flex";
    }

    if (event.target.classList.contains("excluir")) {
        const linha = event.target.closest("tr");
        const id = linha.dataset.id;
        const resposta = confirm("Tem certeza de deletar produto?");

        if (resposta) {
            const excluido = await Excluir(id);
            if (excluido) linha.remove();
        }
    }
});

btnCancelar.addEventListener("click", function() {
    msgEditar.style.display = "none";
});

formulario.addEventListener("submit", async function(event) {
    event.preventDefault();
    console.log("Enviar edição");

    const preco = Number(document.querySelector("#preco").value);
    const quantidade = Number(document.querySelector("#quantidade").value);

    const dados = {
        nomeproduto: document.querySelector("#produto").value,
        descricao: document.querySelector("#descricao").value,
        preco: preco,
        quantidade: quantidade,
        totalvalor: preco * quantidade
    };

    await Editar(idProdutoEditando, dados);
    window.location.reload();
});

async function Excluir(id) {
    const token = localStorage.getItem("jwt");
    const response = await fetch(`${apiExcluir}/${id}`, {
        method: "DELETE",
        headers: { "Authorization": `Bearer ${token}` }
    });

    if (response.ok) {
        console.log("Produto deletado");
        return true;
    } else {
        console.error("Erro ao excluir:", response.status);
        return false;
    }
}

async function Editar(id, novoProduto) {
    const token = localStorage.getItem("jwt");
    const response = await fetch(`${apiEditar}/${id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
            "Authorization": `Bearer ${token}`
        },
        body: JSON.stringify(novoProduto)
    });

    if (response.ok) {
        console.log("Produto atualizado");
        msgEditar.style.display = "none";
    } else {
        console.error("Erro ao editar:", response.status);
    }
}
