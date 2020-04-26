using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common2;


public class ChatRequest : Request
{
    public  string friendName;
    public  string chatString;

    public override void Start()
    {
        base.Start();
    }

    public override void DefaultRequse()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.friendName,friendName);            //朋友名字（object）
        data.Add((byte)ParameterCode.chatString, chatString);              //发送的内容
        PhotonEngine.Peer.OpCustom((byte)OpCode,data,true);
        //(发送用户的peer ； 发送用户的名字； 发送的内容)

    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        //成功发送消息
        if(operationResponse.ReturnCode==(short)ReturnCode.Success)
        {
            Debug.Log("成功发送消息给: "+friendName);
        }
    }
}
