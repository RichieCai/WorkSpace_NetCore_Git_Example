"use strict";

//var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
var connection = new signalR.HubConnectionBuilder().withUrl("https://localhost:7026/chatHub").build();


//建立連線
connection.start().then(function () {
    console.log("連線成功");
}).catch(function (err) {
    return console.error("連線失敗,錯誤訊息:"+err.toString());
});


connection.on("UpdateList", function (jsonList) {

    var list = JSON.parse(jsonList);
    document.getElementById("IDList").remove();

    var ul = document.getElementById("myList");
    // 建立一個 DocumentFragment，可以把它看作一個「虛擬的容器」
    var fragment = document.createDocumentFragment();

    for (i = 0; i < list.length; i++) {
        
        let li = document.createElement("li");
        li.appendChild(document.createTextNode(list[i]));
        document.getElementById("IDList")
        fragment.appendChild(li);
    }
    // 最後將組合完成的 fragment 放進 ul 容器
    ul.appendChild(fragment);
});


//接收訊息
connection.on("UpdateSelfID", function (id) {
    document.getElementById("SelfID").innerText(id);
});

connection.on("UadateContent", function (msg) {
    var li = document.createElement("li");
    li.appendChild(document.createTextNode(msg));
    document.getElementById("Content").appendChild(li);
});



//發送訊息
document.getElementById("btnSend").addEventListener("click", function (event) {
    var UserId = document.getElementById("txtUser").value;
    var sendToID = document.getElementById("txtToUser").value;
    var message = document.getElementById("txtMessage").value;


    connection.invoke("SendMessage", UserId, sendToID, message).catch(function (err) {
        return console.error('傳送錯誤: '+ err.toString());
    });
    event.preventDefault();
});