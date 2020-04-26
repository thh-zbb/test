using Common2;
using Common2.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributePanel : MonoBehaviour
{
    public string playerName;
    public int age;
    public string profile;
    public string sendMsg;
    public string gender;

    public Text locationT;

    public Text nameText;

   
    public Button sendMsgButton;

    public GameObject panel;              //属性框

    public Text chatNameTtext;

    public GameObject chatParent;

    public GameObject defaultPrefab;

    public LocationInfo locationInfo;

    private void Start()
    {
        locationT.text = "纬度" + locationInfo.latitude + "经度" + locationInfo.longitude + "海拔" + locationInfo.altitude;
    }

    public void SendMsg()
    {
        //chatPanel.SetActive(true); 
        //chatNameTtext.text = nameText.text;
        string path = "ChatPrefabs/" + nameText.text;
        GameObject initobj = Resources.Load(path) as GameObject;
        //此预制体存在
        Debug.Log("path:"+path);
        if(initobj!=null)
        {
            initobj.GetComponent<ChatUI>().GetName = nameText.text;
            Instantiate(initobj, chatParent.transform);
        }
        //预制体不存在
        else
        {
            defaultPrefab.GetComponent<ChatUI>().GetName = nameText.text;
            Instantiate(defaultPrefab, chatParent.transform);
        }
    }

    public void GetAttribute(Dictionary<byte,object> data)
    {
        

       
    }
}
