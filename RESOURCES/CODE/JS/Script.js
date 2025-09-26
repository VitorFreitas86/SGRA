
  WebFontConfig = {
      google: { families: [ 'Ubuntu::latin' ] }
  };
(function() {
    var wf = document.createElement('script');
    wf.src = ('https:' == document.location.protocol ? 'https' : 'http') +
      '://ajax.googleapis.com/ajax/libs/webfont/1/webfont.js';
    wf.type = 'text/javascript';
    wf.async = 'true';
    var s = document.getElementsByTagName('script')[0];
    s.parentNode.insertBefore(wf, s);
})(); 

       function Resize() {
           var widthWindow = document.documentElement.offsetHeight;
     
           if (widthWindow < 500) {
               document.getElementById("rodape").style.display = 'none';
           }
           else {
               document.getElementById("rodape").style.display = 'block';
               document.getElementById("rodape").style.width = '100%';
           }
       }

       function Resize_reg() {
           var widthWindow = document.documentElement.offsetHeight;

           if (widthWindow < 650) {
               document.getElementById("rodape").style.display = 'none';
           }
           else {
               document.getElementById("rodape").style.display = 'block';
               document.getElementById("rodape").style.width = '100%';
           }
       }

function checkSizeWindow() {
    var widthWindow = document.documentElement.offsetWidth;
    var Height = document.documentElement.offsetHeight;
    if (Height < 500) {
        document.getElementById("rodape").style.display = 'none';
    }
    else {
        document.getElementById("rodape").style.display = 'block';
        document.getElementById("rodape").style.width = '100%';
    }
    if (widthWindow < 1180) {
        
        if (widthWindow < 1024) {
            document.getElementById("logo_gra").style.display = 'none';
            document.getElementById("btnLogout").style.display = 'inline';
        }
        $("a:contains('Terminar Sessão')").parent('li').hide();
        document.getElementById("btnLogout").style.display = 'inline';
    }
    else {
        document.getElementById("btnLogout").style.display = 'none';
        document.getElementById("logo_gra").style.display = 'block';
        $("a:contains('Terminar Sessão')").parent('li').show();      
    }
}
// This function will execute if file upload fails
function uploadError(sender, args) {
    document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').innerHTML = args.get_errorMessage();
}
                  
          function uploadcomplete(sender, args) {
              if (parseInt(args.get_length()) > 1000000) {
                  document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "block";
                  var err = new Error();
                  err.name = "Upload Error2";
                  err.message = "Existem os seguintes erros de preenchimento:" + '<p style="padding-left:20px;">' + "&#13;&#10;&#160;&#8226;Os documentos devem ter um tamanho inferior a 1Mb" + '</p>' + '<p style="padding-left:20px;">' + "&#13;&#10;&#160;&#8226;Apenas serão permitidos ficheiros num dos seguintes formatos: .PDF .PNG .JPG .TIFF" + '</p>';
                  throw (err);
                  return false;
              }
              else {
                  document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "none";
              }
          }     

function checkExtension(sender, args) {
    var fileName = args.get_fileName();
    var fileExt = fileName.substring(fileName.lastIndexOf(".") + 1);
    if (fileExt == "pdf" || fileExt == "PDF" || fileExt == "jpeg" || fileExt == "jpg" || fileExt == "JPG" || fileExt == "JEPG" || fileExt == "PNG" || fileExt == "png" || fileExt == "tiff") {
        document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "none";
        return true;
    } else {
        //To cancel the upload, throw an error, it will fire OnClientUploadError
        document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "block";
        var err = new Error();
        err.name = "Upload Error";
        err.message =  "Existem os seguintes erros de preenchimento:"+ '<p style="padding-left:20px;">' + "&#13;&#10;&#160;&#8226;Os documentos devem ter um tamanho inferior a 1Mb" + '</p>' +'<p style="padding-left:20px;">'+"&#13;&#10;&#160;&#8226;Os documentos a carregar deverão estar num dos formatos: .JPG .PDF .JPEG .PNG .TIFF"+'</p>';
        throw (err);
        return false;
    }
    return true;
}

function checkExtension_foto(sender, args) {
    var fileName = args.get_fileName();
    var fileExt = fileName.substring(fileName.lastIndexOf(".") + 1);
    document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "none";
    if (fileExt == "jpeg" || fileExt == "jpg" || fileExt == "JPG" || fileExt == "JEPG" || fileExt == "PNG" || fileExt == "png") {
        document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "none";
        return true;
    } else {
        document.getElementById('ContentPlaceHolder1_conducao_form_Conducao_StatusLabel').style.display = "block";
        //To cancel the upload, throw an error, it will fire OnClientUploadError
        var err = new Error();
        err.name = "Upload Error";
        err.message = "Existem os seguintes erros de preenchimento:" + '<p style="padding-left:20px;">' + "&#13;&#10;&#160;&#8226;Os documentos devem ter um tamanho inferior a 1Mb" + '</p>' + '<p style="padding-left:20px;">' + "&#13;&#10;&#160;&#8226;A fotografia deverá estar num dos seguintes formatos: .JPG .JPEG .PNG" + '</p>';
        throw (err);
        return false;
    }
    return true;
}
