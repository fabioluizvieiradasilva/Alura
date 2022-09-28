function tocaSom(idElementoAudio)
{
    const elemento = document.querySelector(idElementoAudio);
    
    if(elemento != null && elemento.localName === 'audio'){
            elemento.play();
    }
}

const listaDeTeclas = document.querySelectorAll('.tecla');

let contador = 0;

for (let contador = 0; contador < listaDeTeclas.length; contador++)
{
    const tecla = listaDeTeclas[contador];
    const instrumento = tecla.classList[1];
    const idAudio = `#som_${instrumento}`;

    tecla.onclick = function(){
            tocaSom(idAudio);
    }
    
    tecla.onkeydown = function (event){

        if(event.code === 'Space' || event.code === 'Enter'){
            tecla.classList.add('ativa');
        }
    }

    tecla.onkeyup = function (){
        tecla.classList.remove('ativa');
    }
    
}
