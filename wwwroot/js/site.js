// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function ConverterImagem(){
    var receberArquivo = document.getElementById("NewFoto").files;
    console.log(receberArquivo);
    if(receberArquivo.length > 0){
     var carregarImagem = receberArquivo[0];
     var lerArquivo = new FileReader();
     lerArquivo.onload = function(arquivoCarregado){
         //COnverter a imagem para base64
         var ImagemBase64 = arquivoCarregado.target.result;
         document.getElementById('FotoBase64').value = ImagemBase64;
         //Cria o elemento html
         var novaImagem = document.createElement('img');
         //atribui a imagem para o atributo src
 
         novaImagem.src = ImagemBase64;
 
         document.getElementById("apresentar-imagem").innerHTML = novaImagem.outerHTML;
     }
     lerArquivo.readAsDataURL(carregarImagem);
    }
 }
 function CarregarFoto(ContentBaseImagem64){
     novaImagem.src = ContentBaseImagem64;
     
 }