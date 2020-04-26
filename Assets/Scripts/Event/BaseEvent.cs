using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common2;
using ExitGames.Client.Photon;

public abstract class BaseEvent : MonoBehaviour
{
    public EventCode EvCode;

    public abstract void OnEvent(EventData eventData);//接收服务器发送过来的数据与消息


    //当这个组件初始化的时候添加这个Request
    public virtual void Start()
    {

            PhotonEngine.Instance.AddEvent(this);
            
    }
    //当这个组件被销毁的时候移除这个Request
    public virtual void OnDestroy()
    {

            PhotonEngine.Instance.RemoveEvent(this);
        
    }
}
