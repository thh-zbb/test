using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common2;
using Common2.Tools;
using UnityEngine.UI;

public class GetAttributeRequest : Request
{

    public string username;

    public GameObject attributePanel;

    public Text nameText;
    public Text ageText;
    public Text profileText;
    public Text genderText;

    public string gender;

    public override void Start()
    {
        base.Start();
        
    }

    public override void DefaultRequse()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.Username,username);
        PhotonEngine.Peer.OpCustom((byte)OperationCode.getAttribute, data, true);
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {

        Dictionary<byte, object> data = operationResponse.Parameters;
        //attributePanel.GetAttribute(data);
        //attributePanel.GetComponent<AttributePanel>().GetAttribute(data);
        nameText.text = (string)DictTool.GetValue<byte, object>(data, (byte)ParameterCode.Username);
        profileText.text = (string)DictTool.GetValue<byte, object>(data, (byte)ParameterCode.profile);
        ageText.text = (string)DictTool.GetValue<byte, object>(data, (byte)ParameterCode.age);
        gender = genderText.text = (string)DictTool.GetValue<byte, object>(data, (byte)ParameterCode.gender);

        Debug.Log(gender);

        if (gender == "boy")
        {
            attributePanel.GetComponent<Image>().color = new Color32(55, 162, 219, 255);
        }
    }


}
