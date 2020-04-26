using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WWWLogin : MonoBehaviour
{

    public Text hintText;
    public InputField usernameIF;
    public InputField passwordIF;
    public Slider slider;
    public Text text100;

    public GameObject panal;
         

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginButton()
    {
        if (usernameIF.text != "" && passwordIF.text != "")
        {
            string name = usernameIF.text;
            string password = passwordIF.text;
            WWWManager login = new WWWManager();
            if (login.CheckNamePassword(name, password))
            {
                hintText.text = "正确";
                UserInfo.userName = name;
                //UserInfo.userInfo.userName = name;
                Debug.Log(UserInfo.userName);
                StartCoroutine(LoadScene());
            }
            else
            {
                hintText.text = "账号或密码错误！";
                StartCoroutine(OkTextDelay());
            }
        }
        else
        {
            hintText.text = "账号或密码为空";
            StartCoroutine(OkTextDelay());
            Debug.Log("账号或密码为空！");
        }
    }

    IEnumerator OkTextDelay()
    {
        yield return new WaitForSeconds(2.0f);
        hintText.text = "";
    }


    IEnumerator LoadScene()
    {
        panal.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync("Home");

        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {

            slider.value = operation.progress;

            text100.text = operation.progress * 100 + "%";

            if (operation.progress >= 0.9f)
            {
                slider.value = 1;

                text100.text = "press anykey to continue";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;

                }

            }

            yield return null;

        }

    }



}
