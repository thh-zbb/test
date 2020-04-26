using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common2;
using Common2.Tools;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public bool isLocalPlayer = true;
    public string userName;

    public GameObject playerPrefab;


    private SyncPositionRequest SyncPosRequest;
    private SyncPlayerRequest syncPlayerRequest;



    private Vector3 lastPos = Vector3.zero;
    private float moveOffset = 0.01f;

    GameObject go;

    GameObject outGo;

    public string inScene;


    //存储所有实例化出来的Player
    Dictionary<string, GameObject> playerDict = new Dictionary<string, GameObject>();


    void Start()
    {
        inScene = SceneManager.GetActiveScene().name;
        
        if (isLocalPlayer)
        {
            userName = PhotonEngine.username;
            playerDict.Clear();
            //GetComponent<Renderer>().material.color = Color.green;
            SyncPosRequest = GetComponent<SyncPositionRequest>();
            syncPlayerRequest = GetComponent<SyncPlayerRequest>();
            syncPlayerRequest.DefaultRequse();
            InvokeRepeating("SyncPosition", 3, 0.1f);
        }
    }

    void SyncPosition()
    {

        if (Vector3.Distance(transform.position, lastPos) > moveOffset)
        {
            lastPos = transform.position;
            SyncPosRequest.pos = transform.position;
            SyncPosRequest.rotation = transform.localEulerAngles;
            SyncPosRequest.DefaultRequse();
        }
    }

    void Update()
    {
        if (isLocalPlayer)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * 4);
        }
    }


    //实例化其他客户端的角色
    public void OnSyncPlayerResponse(List<string> usernameList)
    {
        Debug.Log("正实例化其他客户端的角色，数量："+usernameList.Count);
        //创建其他客户端的角色
        foreach (string username in usernameList)
        {
            Debug.Log("被实例的玩家：" + username);
            OnNewPlayerEvent(username);
        }
    }

    public void OnNewPlayerEvent(string username)
    {
        if (username!=PhotonEngine.username)
        {
            GameObject go = GameObject.Instantiate(playerPrefab);
            Debug.Log("生成的玩家：" + username);
            go.GetComponent<Player>().isLocalPlayer = false;
            go.GetComponent<Player>().userName = username;
            playerDict.Add(username, go);//利用集合保存所有的其他客户端
        }
    }



    public void OnSyncPositionEvent(List<PlayerData> playerDataList)
    {

        foreach (PlayerData pd in playerDataList)//遍历所有的数据
        {

            if(pd.Username!=PhotonEngine.username)
            {

                if(playerDict.ContainsKey(pd.Username))
                {
                    playerDict.TryGetValue(pd.Username, out go);

                    go.transform.position = new Vector3() { x = pd.pos.x, y = pd.pos.y, z = pd.pos.z };
                    //go.transform.rotation = new Quaternion() { x = pd.rotation.x, y = pd.rotation.y, z = pd.rotation.z };
                    go.transform.localEulerAngles = new Vector3() { y = pd.rotation.y };
                }
                else
                {
                    Debug.Log("不存在此用户");
                }

                //GameObject go = DictTool.GetValue<string, GameObject>(playerDict, pd.Username);//根据传递过来的Username去找到所对应的实例化出来的Player

                //如果查找到了相应的角色，就把相应的位置信息赋值给这个角色的position

               
            }

        }
    }

    public void OnOutSceneEvent(string name)
    {
        if (playerDict.TryGetValue(name, out outGo))
        {  
            GameObject.Destroy(outGo);
            Debug.Log("已摧毁玩家：" + outGo.name);
        }
    }


    private void OnDestroy()
    {
        Debug.Log("Player组件被摧毁");
    }
}
