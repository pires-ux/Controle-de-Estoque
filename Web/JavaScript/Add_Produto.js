
const apiAdicionar = "https://localhost:7140/api/Produto/AddProduto";

const forms = document.querySelector("#adicionar");

forms.addEventListener("submit", async (event) => {
    event.preventDefault();

    const preco = Number(document.querySelector("#Addpreco").value);
    const estoque = Number(document.querySelector("#Addestoque").value);

    const produto = {
        nomeproduto: document.querySelector("#Addproduto").value,
        descricao: document.querySelector("#Adddescricao").value,
        preco: preco,
        estoque: estoque,
        totalValor: Multiplicar(estoque, preco)
    };

    try {
        const token = localStorage.getItem("jwt");
        const response = await fetch(apiAdicionar, {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Authorization": `Bearer ${token}`
            },
            body: JSON.stringify(produto)
        });

        if (!response.ok) {
            alert("Erro ao adicionar produto");
            throw new Error(response.status);
        } else {
            alert("Produto adicionado");
        }
    } catch (error) {
        console.error("Erro ao acessar API:", error);
    }
});

function Multiplicar(estoque, valor) {
    return estoque * valor;
}
