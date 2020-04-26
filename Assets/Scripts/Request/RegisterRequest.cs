using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common2;

public class RegisterRequest : Request
{

    [HideInInspector]
    public string username;
    [HideInInspector]
    public string password;
    [HideInInspector]
    public string gender;

    private RegisterPanel registerPanel;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        OpCode = OperationCode.Register;
        registerPanel = GetComponent<RegisterPanel>();
    }

    public override void DefaultRequse()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username, username);
        data.Add((byte)ParameterCode.Password, password);
        data.Add((byte)ParameterCode.gender, gender);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        ReturnCode returnCode = (ReturnCode)operationResponse.ReturnCode;
        registerPanel.OnRegisterResponse(returnCode);
    }

    
}
