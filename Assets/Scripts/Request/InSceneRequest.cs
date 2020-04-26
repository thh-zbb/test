using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common2;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

public class InSceneRequest : Request
{

    public static string sceneName;

    public override void DefaultRequse()
    {
        Debug.Log("进入新场景");
        Debug.Log("场景名字："+sceneName);
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.sceneName,sceneName);
        PhotonEngine.Peer.OpCustom((byte)OperationCode.inScene,data,true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        
    }
}
