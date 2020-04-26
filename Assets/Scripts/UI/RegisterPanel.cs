using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Common2;

public class RegisterPanel : MonoBehaviour
{
    public InputField usernameIF;
    public InputField passwordIF;
    public InputField passwordIF2;
    public Dropdown genderDrop;
    public Image yes;
    public Image no;
    public Text hintText;

    public GameObject loginPanel;
    public GameObject registerPanel;

    string[] sliderValue = { "男", "女" };

    private RegisterRequest registerRequest;

    // Start is called before the first frame update
    void Start()
    {
        yes.gameObject.SetActive(false);
        no.gameObject.SetActive(false);
        registerRequest = GetComponent<RegisterRequest>();
    }

    // Update is called once per frame
    void Update()
    {
        //其中一个为空
        if(passwordIF.text==""||passwordIF2.text=="")
        {
            yes.gameObject.SetActive(false);
            no.gameObject.SetActive(false);
        }
        //都不为空
        else
        {
            if (passwordIF.text == passwordIF2.text)
            {
                yes.gameObject.SetActive(true);
                no.gameObject.SetActive(false);
            }
            else
            {
                yes.gameObject.SetActive(false);
                no.gameObject.SetActive(true);
            }
        }
    }


    public void OnRegisterButton()
    {
        hintText.text = "";
        registerRequest.username = usernameIF.text;
        registerRequest.password = passwordIF.text;
        registerRequest.gender = sliderValue[genderDrop.value];
        if(usernameIF.text==""||passwordIF.text==""||passwordIF2.text=="")
        {
            hintText.text = "内容不能为空！";
        }
        //不为空
        else
        {
            //没有任何格式问题
            if(passwordIF.text==passwordIF2.text)
            {
                registerRequest.DefaultRequse();
            }
            else
            {
                hintText.text = "两次密码输入不一样！";
            }
        }
    }


    public void OnChangeToLoginButton()
    {
        registerPanel.SetActive(false);
        loginPanel.SetActive(true);
    }

    public void OnRegisterResponse(ReturnCode returnCode)
    {
        switch(returnCode)
        {
            case ReturnCode.Success:
                Debug.Log("插入成功！");
                loginPanel.GetComponent<LoginPanel>().SetNameIF(usernameIF.text);
                OnChangeToLoginButton();
                break;

            case ReturnCode.nonexistent:
                hintText.text = "此用户已经存在！";
                usernameIF.text = "";
                break;

            default:
                hintText.text = "数据插入失败！";
                break;
        }
    }

    IEnumerator HintTextDelay()
    {
        yield return new WaitForSeconds(2.0f);
        hintText.text = "";
    }

}
