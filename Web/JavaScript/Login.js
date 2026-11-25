
const api = "https://localhost:7140/api/Usuario/login";

console.log("iniciado");

const formulario = document.querySelector("#login");

formulario.addEventListener("submit", async (event) => {
    event.preventDefault();

    const dados = {
        email: document.getElementById("email").value,
        senha: document.getElementById("senha").value
    };

    try {
        const response = await fetch(api, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(dados)
        });

        if (response.ok) {
            const resultado = await response.json();

            // Guarda o JWT para usar nas outras páginas
            localStorage.setItem("jwt", resultado.token);

            alert("Login realizado com sucesso!");
            window.location.href = "../Principal/Tela_Principal.html";
        } else {
            const erro = await response.text();
            console.log("Erro da API:", erro);
            alert("E-mail ou senha incorretos.");
        }
    } catch (error) {
        alert("Erro ao tentar conectar com a API.");
        console.log("Erro:", error);
    }
});
