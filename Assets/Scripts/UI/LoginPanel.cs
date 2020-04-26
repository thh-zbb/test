using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common2;
using UnityEngine.SceneManagement;

public class LoginPanel : MonoBehaviour
{

    public InputField usernameIF;
    public InputField PasswordIF;
    public Text hintText;
    public Slider slider;
    public Text text100;

    public LoginPanel loginPanel;
    public RegisterPanel registerPanel;
    public GameObject loadPanel;

    private LoginRequest loginRequest;


    private void Start()
    {

        loginRequest = GetComponent<LoginRequest>();
    }


    //点击登陆按钮
    public void OnLoginButton()
    {
        hintText.text = "";
        if(usernameIF.text==""||PasswordIF.text=="")
        {
            hintText.text = "输入不能为空！";
            StartCoroutine(HintTextDelay());
            return;
        }
        loginRequest.username = usernameIF.text;
        loginRequest.password = PasswordIF.text;
        loginRequest.DefaultRequse();
    }

    public void OnChangeToRegister()
    {
        loginPanel.gameObject.SetActive(false);
        registerPanel.gameObject.SetActive(true);
    }

    public void OnForgetPassword()
    {
        hintText.text = "还没写好，再等等！";
        StartCoroutine(HintTextDelay());
    }

    public void OnLoginResponse(ReturnCode returnCode)
    {
        if(returnCode==ReturnCode.Success)
        {
            hintText.text = "密码正确！";
            PhotonEngine.username = usernameIF.text;
            UserInfo.userName = usernameIF.text;
            UserInfo.userGender = "默认";
            //SceneManager.LoadScene("Home");
            StartCoroutine(LoadScene());
        }
        else
        {
            hintText.text = "账号或密码错误";
            StartCoroutine(HintTextDelay());
            PasswordIF.text = "";
        }
    }

    public void SetNameIF(string name)
    {
        usernameIF.text = name;
    }

    IEnumerator HintTextDelay()
    {
        yield return new WaitForSeconds(2.0f);
        hintText.text = "";
    }


    IEnumerator LoadScene()
    {
        loadPanel.SetActive(true);

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
