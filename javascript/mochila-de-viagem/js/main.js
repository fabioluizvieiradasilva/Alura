const form = document.getElementById("novo-item");
const lista = document.getElementById('lista');
const itens = JSON.parse(localStorage.getItem('itens')) || [];

itens.forEach((elemento) => {    
    criaElemento(elemento)
})

form.addEventListener("submit", (evento) => {
    evento.preventDefault();  

    const nome = evento.target.elements['nome'];
    const quantidade = evento.target.elements['quantidade'];

    const existe = itens.find(elemento => elemento.nome === nome.value);

    const itemAtual = {
        "nome": nome.value,
        "quantidade": quantidade.value
    }    

    if(existe){
        itemAtual.id = existe.id;
        atualizaElemento(itemAtual);
    }else {
        itemAtual.id = itens.length;
        //criando o elemento na lista
        criaElemento(itemAtual);     
        itens.push(itemAtual);

    }

    //inserindo dados no localstorage
    localStorage.setItem('itens', JSON.stringify(itens));

    nome.value ='';
    quantidade.value = '';
})

function criaElemento(item){

    //criando um novo item "<li></li>"
    const novoItem = document.createElement('li');
    //adicionando a classe "item" ao novoItem
    novoItem.classList.add('item');    

    //criando um novo item "<strong></strong>"
    const numeroItem = document.createElement('strong');
    numeroItem.innerHTML = item.quantidade;
    numeroItem.dataset.id = item.id;
    
    //adicionando o numeroItem dentro do novoItem
    novoItem.appendChild(numeroItem);
    novoItem.innerHTML += item.nome;

    //Adicionando o novoItem dentro da lista
    lista.appendChild(novoItem);   

}

function atualizaElemento(item){
    document.querySelector("[data-id='" + item.id + "']").innerHTML = item.quantidade;
}