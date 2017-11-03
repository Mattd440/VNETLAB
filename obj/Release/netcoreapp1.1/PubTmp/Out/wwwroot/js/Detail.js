
function GetFile()
{
    var blob;
    var data;
    var a = document.getElementById("a");
    var txtFile = "networkconfig.json";

    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Saved/GetNetworkFile', true);
    xhr.onreadystatechange=function() {
     if (xhr.readyState==4) {
        data = JSON.stringify(xhr.responseText);
        console.log(data);
        blob = new Blob([data],{type: "application/json"});
        console.log(blob);
        saveAs(blob,txtFile);
      }
     }
     xhr.send(null);
       

}
 