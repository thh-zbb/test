using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class MessageInister : MonoBehaviour
{

    public string msg;

    GameObject prefab1;
    GameObject prefab2;

    public GameObject msgPanel;

    public InputField inputMsg;
    public Text friendName;

    ChatRequest chatRequest;

    private void Start()
    {
        prefab1 = Resources.Load("TextBubble Me") as GameObject;
        prefab2 = Resources.Load("TextBubble Friend") as GameObject;
        chatRequest = GetComponent<ChatRequest>();
        //消息有缓存
        if (PhotonEngine.Instance.messageQueueListDict[friendName.text].Count > 0)
        {

            TextType text;

            Queue<TextType> message = PhotonEngine.Instance.messageQueueListDict[friendName.text];
            for (int i = 0; i < message.Count; i++)
            {
                text = message.Dequeue();
                InstanceFriend(text.content);
            }
            PhotonEngine.Instance.messageQueueListDict.Remove(friendName.text);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            Instance();
        }
        if(PhotonEngine.Instance.messageQueueListDict[friendName.text].Count>0)
        {
            Queue<TextType> data = PhotonEngine.Instance.messageQueueListDict[friendName.text];
            while(data.Count>0)
            {
                InstanceFriend(data.Dequeue().content);
            }
        }
    }

    public void Instance()
    {
            msg = inputMsg.text;
            prefab1.GetComponentInChildren<Text>().text = msg;
            Instantiate(prefab1, msgPanel.transform);
            inputMsg.text = "";

            chatRequest.friendName = friendName.text;
            chatRequest.chatString = msg;
            chatRequest.DefaultRequse();
    }

    public void InstanceFriend(string chatString)
    {
        msg = chatString;
        prefab2.GetComponentInChildren<Text>().text = msg;
        Instantiate(prefab2, msgPanel.transform);

        
    }
    

}
