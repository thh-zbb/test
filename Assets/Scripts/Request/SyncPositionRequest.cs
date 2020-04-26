using System.Collections;
using System.Collections.Generic;
using Common2;
using ExitGames.Client.Photon;
using UnityEngine;

public class SyncPositionRequest : Request
{
    public Vector3 pos;
    public Vector3 rotation;


    public override void DefaultRequse()
    {
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        //data.Add((byte)ParameterCode.Position, new Vector3Data() { x = pos.x, y = pos.y, z = pos.z });
        //data.Add((byte)ParameterCode.Position, pos);
        data.Add((byte)ParameterCode.x, pos.x);
        data.Add((byte)ParameterCode.y, pos.y);
        data.Add((byte)ParameterCode.z, pos.z);
        data.Add((byte)ParameterCode.rx, rotation.x);
        data.Add((byte)ParameterCode.ry, rotation.y);
        data.Add((byte)ParameterCode.rz, rotation.z);

        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);

    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        throw new System.NotImplementedException();
    }

}
