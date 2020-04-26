using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventIniste : MonoBehaviour
{
    NewPlayerEvent newPlayerEvent;
    OutSceneEvent outSceneEvent;
    SyncPositionEvent syncPositionEvent;
    ChatEvent chatEvent;

    // Start is called before the first frame update
    void Start()
    {
        newPlayerEvent = GetComponent<NewPlayerEvent>();
        outSceneEvent = GetComponent<OutSceneEvent>();
        syncPositionEvent = GetComponent<SyncPositionEvent>();
        chatEvent = GetComponent<ChatEvent>();

        PhotonEngine.Instance.AddEvent(newPlayerEvent);
        PhotonEngine.Instance.AddEvent(outSceneEvent);
        PhotonEngine.Instance.AddEvent(chatEvent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
