using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Common2;
using Common2.Tools;
using ExitGames.Client.Photon;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SyncPlayerRequest : Request
{

    private Player player;

    public override void Start()
    {
        base.Start();
        player = GetComponent<Player>();
    }


    public override void DefaultRequse()
    {
        Debug.Log("开始同步玩家");
        Dictionary<byte, object> data = new Dictionary<byte, object>();
        data.Add((byte)ParameterCode.sceneName,SceneManager.GetActiveScene().name);
        Debug.Log("当前场景名字：" + SceneManager.GetActiveScene().name);
        PhotonEngine.Peer.OpCustom((byte)OpCode, data, true);//把Player位置传递给服务器
    }

    public override void OnOperationResponse(OperationResponse operationResponse)
    {
        
        //接收xml格式的字符串
        string usernameListString = (string)DictTool.GetValue<byte, object>(operationResponse.Parameters, (byte)ParameterCode.UsernameList);

        Debug.Log("需要同步的玩家列表："+usernameListString);

        //通过xml反序列化解析传输过来的List数据 接受完后关闭
        using (StringReader reader = new StringReader(usernameListString))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            List<string> usernameList = (List<string>)serializer.Deserialize(reader);//表示读取字符串
            Debug.Log("自己的名字；"+PhotonEngine.username);

            player.OnSyncPlayerResponse(usernameList);
        }
    }
}
