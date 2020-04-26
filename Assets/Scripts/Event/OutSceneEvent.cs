using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using UnityEngine;
using Common2;

public class OutSceneEvent : BaseEvent
{

    Player player;

    public override void Start()
    {
        EvCode = EventCode.outScene;
        base.Start();
        player = GetComponent<Player>();
    }

    public override void OnEvent(EventData eventData)
    {
        Dictionary<byte, object> data = eventData.Parameters;
        data.TryGetValue((byte)ParameterCode.Username, out object Oname);
        string name = (string)Oname;
        Debug.Log("收到的名字："+name);
        player.OnOutSceneEvent(name);
    }
}
