using System.Collections;
using System.Collections.Generic;
using Common2;
using Common2.Tools;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerEvent : BaseEvent
{

    private Player player;


    public override void Start()
    {
        EvCode = EventCode.NewPlayer;
        base.Start();
        player = GetComponent<Player>();
    }

    public override void OnEvent(EventData eventData)
    {
        string username = (string)DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.Username);
        string sceneName = (string)DictTool.GetValue<byte, object>(eventData.Parameters, (byte)ParameterCode.sceneName);
        if (SceneManager.GetActiveScene().name == sceneName)
        {
            player.OnNewPlayerEvent(username);//根据用户名实例化出来新的Player出来
        }
        
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }



}
