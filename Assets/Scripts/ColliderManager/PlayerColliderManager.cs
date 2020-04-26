using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerColliderManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="ToMap")
        {
            SceneManager.LoadScene("Map");
        }
    }

    //IEnumerator LoadScene()
    //{
    //    loadPanel.SetActive(true);

    //    AsyncOperation operation = SceneManager.LoadSceneAsync("map");

    //    operation.allowSceneActivation = false;

    //    while (!operation.isDone)
    //    {

    //        slider.value = operation.progress;

    //        text100.text = operation.progress * 100 + "%";

    //        if (operation.progress >= 0.9f)
    //        {
    //            slider.value = 1;

    //            text100.text = "press anykey to continue";

    //            if (Input.anyKeyDown)
    //            {
    //                operation.allowSceneActivation = true;

    //            }

    //        }

    //        yield return null;

    //    }

    //}
}
