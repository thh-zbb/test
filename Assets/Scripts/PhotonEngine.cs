using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using Common2;
using Common2.Tools;

public class PhotonEngine :MonoBehaviour, IPhotonPeerListener
{

    public static PhotonEngine Instance;
    private static PhotonPeer peer;
    public static PhotonPeer Peer//让外界可以访问我们的PhotonPeer
    {
        get
        {
            return peer;
        }
    }

    public static TextType textType;



    //创建一个字典，根据OperationCode去找到所有相对应的Request对象
    private Dictionary<OperationCode, Request> RequestDict = new Dictionary<OperationCode, Request>();

    public Dictionary<EventCode, BaseEvent> EventDict = new Dictionary<EventCode, BaseEvent>();

    //朋友列表
    public List<string> Friend = new List<string>();

    //有聊天的列表
    public List<string> chatList = new List<string>();

    //聊天记录
    public Dictionary<string, List<TextType>> MessageListDict = new Dictionary<string, List<TextType>>();

    //消息缓存
    public Dictionary<string,Queue<TextType>> messageQueueListDict=new Dictionary<string, Queue<TextType>>();


    /// <summary>
    /// 玩家属性
    /// </summary>
    public static string username;//保存当前用户的用户名
    public static string gender;    //性别



    private void Awake()
    {
        //保证只有一个连接服务器
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject); return;
        }
    }


    void Start()
    {
        //连接服务器端
        //通过Listender连接服务器端的响应
        //第一个参数 指定一个Licensed(监听器) ,第二个参数使用什么协议
        peer = new PhotonPeer(this, ConnectionProtocol.Udp);
        //连接 UDP的 Ip地址：端口号，Application的名字
        peer.Connect("192.168.1.133:5055", "MyGame2");

        //InitEvent();
        //textType = GetComponent<TextType>()
    }



    void Update()
    {
        peer.Service();//需要一直调用Service方法,时时处理跟服务器端的连接
    }



    public void DebugReturn(DebugLevel level, string message)
    {

    }


    //如果客户端没有发起请求，但是服务器端向客户端通知一些事情的时候就会通过OnEvent来进行响应 
    public void OnEvent(EventData eventData)
    {
        // 把服务器端接受到的事件分发到各个BaseEvent去处理
        EventCode code = (EventCode)eventData.Code;
        BaseEvent e = DictTool.GetValue<EventCode, BaseEvent>(EventDict, code);//通过EventCode得到一个BaseEvent
        //Debug.Log(e.EvCode);
        e.OnEvent(eventData);
        
    }


    //当我们在客户端向服务器端发起请求后，服务器端接受处理这个请求给客户端一个响应就会在这个方法里进行处理
    public void OnOperationResponse(OperationResponse operationResponse)
    {
        OperationCode opCode = (OperationCode)operationResponse.OperationCode;//得到响应的OperationCode
        Request request = null;
        bool temp = RequestDict.TryGetValue(opCode, out request);//是否得到这个响应                                                       // 如果得到这个响应
        if (temp)
        {
            request.OnOperationResponse(operationResponse);//处理Request里面的响应
        }
        else
        {
            Debug.Log("没有找到对应的响应处理对象");
        }

    }

    //public void InitEvent()
    //{
    //    NewPlayerEvent newPlayerEvent = new NewPlayerEvent();
    //    EventDict.Add(EventCode.NewPlayer,newPlayerEvent);

    //    SyncPositionEvent syncPositionEvent = new SyncPositionEvent();
    //    EventDict.Add(EventCode.SyncPosition, syncPositionEvent);

    //    ChatEvent chatEvent = new ChatEvent();
    //    EventDict.Add(EventCode.chat, chatEvent);
    //}

    //如果连接状态发生改变的时候就会触发这个方法。
    //连接状态有五种，正在连接中(PeerStateValue.Connecting)，
    //已经连接上（PeerStateValue.Connected），
    //正在断开连接中( PeerStateValue.Disconnecting)，
    //已经断开连接(PeerStateValue.Disconnected)，
    //正在进行初始化(PeerStateValue.InitializingApplication)
    public void OnStatusChanged(StatusCode statusCode)
    {
        Debug.Log(statusCode);
    }


    //添加Requst
    public void AddRequst(Request requst)
    {
        RequestDict.Add(requst.OpCode, requst);

    }
    //移除Requst
    public void RemoveRequst(Request request)
    {
        RequestDict.Remove(request.OpCode);
    }

    //添加Event事件
    public void AddEvent(BaseEvent Event)
    {
        EventDict.Add(Event.EvCode, Event);
    }
    //移除Event事件
    public void RemoveEvent(BaseEvent Event)
    {
        EventDict.Remove(Event.EvCode);
    }


}
