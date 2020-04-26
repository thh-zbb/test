using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common2;

public class ChatEvent : BaseEvent
{

    //public static TextType text;
    public Queue<TextType> getChatQueue = new Queue<TextType>();

    public override void OnEvent(EventData eventData)
    {
        Debug.Log("收到对方的消息");
        //收到对方发的消息
        Dictionary<byte, object> data = eventData.Parameters;
        data.TryGetValue((byte)ParameterCode.sendName, out object friendName);
        data.TryGetValue((byte)ParameterCode.chatString, out object chatString);

        TextType text = GetComponent<TextType>();
        text.content = (string)chatString;
        text.userName = (string)friendName;
        text.isOwner = false;

        Debug.Log("发送人："+friendName);
        Debug.Log("内容：" + chatString);

        //记录所有消息
        if (PhotonEngine.Instance.MessageListDict.ContainsKey((string)friendName))         //如果之前有记录
        {
            PhotonEngine.Instance.MessageListDict[(string)friendName].Add(text);
        }
        else
        {
            List<TextType> textType = new List<TextType>();
            textType.Add(text);
            PhotonEngine.Instance.MessageListDict.Add((string)friendName, textType);
        }
        //List<TextType> getChatString = new List<TextType>();
        //PhotonEngine.Instance.MessageListDict.TryGetValue((string)friendName, out getChatString);
        //getChatString.Add(text);
        //PhotonEngine.Instance.MessageListDict[(string)friendName] = getChatString;

        //记录未读信息  
        //判断是否第一次
        if (PhotonEngine.Instance.messageQueueListDict.TryGetValue((string)friendName, out getChatQueue))
        {
            PhotonEngine.Instance.messageQueueListDict[(string)friendName].Enqueue(text);
        }
        else
        {
            PhotonEngine.Instance.messageQueueListDict.Add((string)friendName, new Queue<TextType>());
            PhotonEngine.Instance.messageQueueListDict[(string)friendName].Enqueue(text);
        }
    }

    public override void Start()
    {
       
        EvCode = EventCode.chat;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
