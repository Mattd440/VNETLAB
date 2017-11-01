
function GetFile()
{
    var blob;
    var data;
    var a = document.getElementById("a");
    var txtFile = "test.txt";

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Saved/GetNetworkFile', true);
    xhr.onreadystatechange=function() {
     if (xhr.readyState==4) {
        data = (xhr.responseText);
        console.log(data);
        blob = new Blob([data],{type: "text/plain;charset=utf-8"});
        console.log(blob);
        saveAs(blob,txtFile);
      }
     }
     xhr.send(null);
       

}
 