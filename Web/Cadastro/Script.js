
const API_URL = "https://localhost:7140/api/Usuario/cadastro";

const form = document.querySelector(".cadastro");

form.addEventListener("submit", async (event) => {
    event.preventDefault();

    const usuario = {
        nome: document.querySelector("#nome").value,
        email: document.querySelector("#email").value,
        senha: document.querySelector("#senha").value
    };

    try {
        const response = await fetch(API_URL, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(usuario)
        });

        if (!response.ok) {
            throw new Error(`Erro HTTP: ${response.status}`);
        }

        alert("Usuário cadastrado com sucesso!");

        form.reset();
        

    } catch (error) {
        console.error("Erro:", error);
        alert("erro ao cadastrar usuario");
    }
});
