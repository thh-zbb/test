using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UISet : MonoBehaviour
{

    int hour;
    int minutes;
    int second;
    public Text TextTime;

    public Text text_name;
    public Text text_gender;
    public Text text_money;


    //public Button Home;

    // Start is called before the first frame update
    void Start()
    {
        text_name.text = UserInfo.userName;
        text_name.text = PhotonEngine.username;
        text_gender.text = UserInfo.userGender;
        text_money.text = "600612";
    }

    // Update is called once per frame
    void Update()
    {
        hour = DateTime.Now.Hour;
        minutes = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        TextTime.text = hour + ":" + minutes + ":" + second;
    }

    public void GoHome()
    {
        SceneManager.LoadScene("Home");
    }

}
