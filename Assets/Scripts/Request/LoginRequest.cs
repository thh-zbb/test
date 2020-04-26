using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common2;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginRequest : Request
{
    [HideInInspector]
    public string username;
    [HideInInspector]
    public string password;


    private LoginPanel loginPanel;

    public override void Start()
    {
        base.Start();
        OpCode = OperationCode.Login;
        loginPanel = GetComponent<LoginPanel>();
    }

    public override void DefaultRequse()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username, username);
        data.Add((byte)ParameterCode.Password, password);
        PhotonEngine.Peer.OpCustom((byte)OpCode,data,true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        loginPanel.OnLoginResponse(returnCode);
    }
}
