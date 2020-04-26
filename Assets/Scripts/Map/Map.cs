using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Map : MonoBehaviour
{

    InSceneRequest inSceneRequest;

    private void Start()
    {
        inSceneRequest = GetComponent<InSceneRequest>();
    }

    public void ToPark()
    {
        SceneManager.LoadScene("Park");
        InSceneRequest.sceneName = "Park";
        inSceneRequest.DefaultRequse();
    }


}
