<template>
  <div class="about">
    <h1>This is an about page</h1>
    <p>連線id:<span>{{ConnectId}}</span></p>
    <p>訊息狀態:<span>{{ConnecStatusMessage}}</span></p>
    <p>顯示訊息</p>
    <div id="divMessages" >
             <li v-for="(input, index) in vMessagesList">
            <span>{{input}}</span>
            </li>
    </div>
    <input id="tbMessage" type="text" v-model="InputMessage" @keyup.enter="send" />
    <button id="btnSend" @click="send">Send</button>
  </div>
</template>

<script lang="ts">
import { ref, defineComponent, reactive, onMounted,watch  } from "vue";
import {HubConnectionBuilder} from "@microsoft/signalr";


export default defineComponent({
  name: "SignalRTest2Child",
  props: {
    SelUser:Object,
    IsShow:Boolean,
  },
  setup(props) {
    let queryParams = ref(new URLSearchParams());
    let hub = reactive({
      connection: {},
      HubConnId: "",
      resultInfo: {},
    });
    
    //let connectionServer=null;
    let vMessagesList=reactive([]);
    let InputMessage = ref('');
    let username = new Date().getTime();
    let ConnectId=ref('');
    let ConnecStatusMessage=ref('');

    let TargetUser:any=reactive({
    id:"5",
    name:"",
    age:"",
    });
    watch(props,()=>{
                console.log("child watch 每次附值");
        TargetUser.name=  props.SelUser?.name;
        ///queryParams.value = new URLSearchParams();
        //queryParams.value.set('UserId', TargetUser.id);
        //queryParams.value.set('UserName', TargetUser.name);
         funCreateConn(TargetUser.id,TargetUser.name);
    });
    watch(
      () => props.SelUser,
      (newVal) => {
        console.log("child watch2 第一次附值");
        TargetUser.name = newVal?.name;
        //queryParams.value = new URLSearchParams();
        //queryParams.value.set("UserId", TargetUser.id);
        //queryParams.value.set("UserName", TargetUser.name);
        funCreateConn(TargetUser.id,TargetUser.name);
      },
      { immediate: true }
    );



    onMounted(() => {

    //    let connectionServer =  new HubConnectionBuilder()
    //        .withUrl(`https://localhost:44371/progressHub2?${queryParams.value.toString()}`,{
    //        accessTokenFactory:async () =>
    //        { 
    //        const token:any= localStorage.getItem("loginToken");
    //        return token ;
    //        }, // 获取JWT访问令牌
    //    }).build();
//
    //    connectionServer.on('messageReceived', (username:never, message:never) => {
    //      console.log("messageReceived");
    //      //"username:"+username+",message:"+message
    //      vMessagesList.push(message);
    //      });
//
    //    const send = () => {
    //      connectionServer.send('newMessage', username, InputMessage.value).then(() => (InputMessage.value = ''));
    //    };
    //    connectionServer.on("UpdateInit", (id:any,UserId:any,UserName:any) => {
    //      console.log("UpdateInit");
    //      console.log("id:"+id+",UserId:"+UserId+",UserName:"+UserName);
    //      hub.HubConnId = id;
    //      ConnectId.value=id;
    //      ConnecStatusMessage.value="connection sunccess";
    //    });
//
    //    connectionServer.start().catch((err:any) => document.write(err));
    //    connectionServer.onclose((error:any) => {
    //      ConnecStatusMessage.value="connection error";
    //    });
    });

    function funCreateConn(UserId:string,UserName:string)
    {
        let queryParams2  = new URLSearchParams();
        queryParams2.set('UserId', UserId);
        queryParams2.set('UserName', UserName);
      let  connectionServer =  new HubConnectionBuilder()
          .withUrl(`https://localhost:44371/progressHub2?${queryParams2.toString()}`,{
          accessTokenFactory:async () =>
          { 
          const token:any= localStorage.getItem("loginToken");
          return token ;
          }, // 获取JWT访问令牌
      }).build();

    connectionServer.on('messageReceived', (username:never, message:never) => {
      console.log("messageReceived");
      //"username:"+username+",message:"+message
      vMessagesList.push(message);
      });

    const send = () => {
      connectionServer.send('newMessage', username, InputMessage.value).then(() => (InputMessage.value = ''));
    };
    connectionServer.on("UpdateInit", (id:any,UserId:any,UserName:any) => {
      console.log("UpdateInit");
      console.log("id:"+id+",UserId:"+UserId+",UserName:"+UserName);
      hub.HubConnId = id;
      ConnectId.value=id;
      ConnecStatusMessage.value="connection sunccess";
    });

    connectionServer.start().catch((err:any) => document.write(err));
    connectionServer.onclose((error:any) => {
      ConnecStatusMessage.value="connection error";
    });


    }

    return {
      vMessagesList,
      InputMessage,
      ConnectId,
      ConnecStatusMessage,
      funCreateConn
    }
  },
});

 
</script>
