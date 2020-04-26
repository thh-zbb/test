using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExitGames.Client.Photon;
using Common2;
using Common2.Tools;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class SyncPositionEvent : BaseEvent
{

    Player player;

    
    public override void Start()
    {
        EvCode = EventCode.SyncPosition;
        base.Start();
        player = GetComponent<Player>();
    }

    public override void OnEvent(EventData eventData)
    {
        string playerDataListString = (string)DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.PlayerDataList);

        //进行反序列化接收数据
        using (StringReader reader = new StringReader(playerDataListString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<PlayerData>));
            List<PlayerData> playerDataList = (List<PlayerData>)serializer.Deserialize(reader);
            player = GetComponent<Player>();
            player.OnSyncPositionEvent(playerDataList);
        }
    }

    public override void OnDestroy()
    {
        Debug.Log("PositionEvent 被摧毁");
        base.OnDestroy();
    }
}

