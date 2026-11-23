const apiAdicionar = "https://localhost:7140/api/Produto/AddProduto"



//Tela Add_Produto 
//---------------------------------------------------------------------


const forms = document.querySelector("#adicionar")

forms.addEventListener("submit", async (event) => {
    event.preventDefault()

    var preco = Number(document.querySelector("#Addpreco").value)
    var estoque = Number(document.querySelector("#Addestoque").value)

    const produto = {
        nomeproduto: document.querySelector("#Addproduto").value,
        descricao: document.querySelector("#Adddescricao").value,
        preco: preco,
        estoque: estoque,
        totalValor: Multiplicar(estoque, preco)
    }

    try{
        const response = await fetch(apiAdicionar, {
            method: "POST",
            headers: {"Content-Type": "application/json"},
            body: JSON.stringify(produto)
        })

        if(!response.ok){
            alert("erro ao adicionar produto")
            throw new Error(response.status)
        }else{
            alert("produto adicionado")
        }
    }
    catch(error){
        console.error("erro ao acessar api")

    }

})

function Multiplicar(estoque, valor){
    var result = estoque * valor;
    return result
}




