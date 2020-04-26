using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChatUI : MonoBehaviour
{
    public string talkingFriendName;

    public Text friendNameText;
    public InputField input;

    public string GetName;

    public string Msg;

    public GameObject thisObj;

    ChatRequest chatRequest;

    // Start is called before the first frame update
    void Start()
    {
        friendNameText.text = GetName;
    }

    public void Send()
    {
      
        
    }

    public void sendMsgChange()
    {
        Msg = input.text;
    }

    public void ReplacePrefab()
    {
        string path = "Assets/Resources/ChatPrefabs/";
        path += friendNameText.text + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(thisObj, path);
        Destroy(thisObj);
        //Debug.Log(success);
    }

}
