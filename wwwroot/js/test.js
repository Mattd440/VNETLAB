

function Point(x,y)
{
    this.leftPercent =x;
    this.topPercent = y;
}
//points where hosts are added
var points = [
    new Point(10,50),
    new Point(80,50),
    new Point(45,20),
    new Point(45,80),
    new Point(10,20),
    new Point(10,80),
    new Point(80,20),
    new Point(80,80),
    new Point(27,20),
    new Point(27,80),
    new Point(62,20),
    new Point(62,80)

];

var switchPoints = [
    new Point(30,50),
    new Point(60,50)
];


var addElement = (function(){
    var index =0;
    var switchIndex = 0;
    var curr = document.getElementById("box");
    function addSwitchImg(point){
        this.SwitchPoint = point;
        var newImg = document.createElement("img");
        newImg.setAttribute("src", "./images/switch.jpeg");
        newImg.setAttribute("width", "60px");
        newImg.style.position= "absolute" ;
        newImg.style.left = this.SwitchPoint.leftPercent + '%';
        newImg.style.top = this.SwitchPoint.topPercent + '%' ;
        curr.appendChild(newImg);
        switchIndex = switchIndex + 1;

    }
    function addHostImg(point){
        this.point = point;
        var newEl = document.createElement("img");
        newEl.setAttribute("src", "./images/computer.jpg");
        newEl.setAttribute("width", "50px");
        newEl.style.position = "absolute";
        newEl.style.left = this.point.leftPercent + '%';
        newEl.style.top = this.point.topPercent + '%';

        //newEl.appendChild(content);


        curr.appendChild(newEl);
        index = index + 1;
    }
    return {
        addHost : function(){
            addHostImg(points[index]);
        },

        addSwitch : function(){
            addSwitchImg(switchPoints[switchIndex]);
        }
    }
})();


// toggle dropdown menus on and off
function ToggleVisibility(type)
{
    var div = document.getElementById("addHost");
    var switchdiv = document.getElementById("addSwitch");      
   
    if(type == "host")
    {
        
        if(div.style.display !== 'none')
         {
            div.style.display = 'none'
         }
        else{
            div.style.display = 'block';
            if (switchdiv.style.display === 'block'){
                switchdiv.style.display = 'none';
            }
            var addHostImageBtn = document.getElementById("addHostImageBtn").disabled = true;
        }
   } 
   else if(type == "switch")
   {

        if(switchdiv.style.display !== 'none')
        {
            switchdiv.style.display = 'none';
        }
        else{
            switchdiv.style.display = 'block';
            if(div.style.display === 'block'){
                div.style.display = 'none'
            }

        }
   }

}


function Host(name,switchname, eth0) {
    this.name = name;
    this.eth0 = eth0;
    this.switchname = switchname;
}


// ajax call to add a host
function postHost() {
    var name = document.getElementById("name").value;
    var eth0 = document.getElementById("eth0").value;
    var switchName = document.getElementById("switch").value;

   
   if(!name || !eth0 || !switchName )
   {
    alert("Enter All Fields Before Saving A Host");
   }else{
    this.addElement.addHost();

    var host = new Host(name,switchName, eth0);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'Create/AddNewHost', true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.send(JSON.stringify(host));
    }

   document.getElementById("name").value = "";
   document.getElementById("eth0").value = "";
   document.getElementById("switch").value = "";

}


function Switch(name, eth0, ports)
{
    this.name = name;
    this.eth0 = eth0;
    this.ports = ports; 
}


function postSwitch() {
    
    var name = document.getElementById("switchname").value;
    var eth0sw = document.getElementById("eth0sw").value;
    var ports = document.getElementById("ports").value;
     var hostButton = document.getElementById("addBtn");

    if(!name || !eth0 || !ports)
    {
        alert("Enter All Fields Before Saving A Switch");
    }else{
        this.addElement.addSwitch();

        var switch1 = new Switch(name, eth0sw, ports);

        var xhr = new XMLHttpRequest();
        xhr.open('POST', 'Create/AddNewSwitch', true);
        xhr.setRequestHeader("Content-type", "application/json");
        xhr.send(JSON.stringify(switch1));

    }

    document.getElementById("switchname").value = "";
    document.getElementById("eth0sw").value = "";
    document.getElementById("ports").value = "";


}


function postNewNetwork()
{
    showButtons();

   var name = document.getElementById("newNetworkName").value;
    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'Create/addnetwork', true);
    xhr.setRequestHeader("Content-type", "application/json");
    xhr.send(JSON.stringify(name))
  
}


function showButtons()
{
   var saveBtn = document.getElementById("saveNetwork");
   var addBtns = document.getElementById("controlButtons");
   var networkInput = document.getElementById("newNetworkName");
   var hostBtn = document.getElementById("addBtn");

    if(networkInput.value)
    {
        addBtns.style.display = "inline-block";
        saveBtn.disabled = true;
       
    }
    else{
        alert("Please Enter a network name");
    }
  
}
