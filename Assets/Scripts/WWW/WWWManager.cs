using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using UnityEngine;

public class WWWManager : MonoBehaviour
{

    /// <summary>
    /// 检查账号密码（用作登录）
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    public bool CheckNamePassword(string name, string password)
    {
        string postString = "name=" + name + "&password=" + password;
        Debug.Log("name:" + name);
        Debug.Log("password:" + password);
        byte[] postData = Encoding.UTF8.GetBytes(postString);//编码，尤其是汉字，事先要看下抓取网页的编码方式
        string url = UserInfo.urlSqlLogin;//地址
        WebClient webClient = new WebClient();
        webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可 
        byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流
        string srcString = Encoding.UTF8.GetString(responseData);//解码
        Debug.Log("结果：" + srcString);
        if (srcString == "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }




    /// <summary>
    ///    存入数据
    /// </summary>
    /// <param name="name"></param>
    /// <param name="password"></param>
    /// <param name="gender"></param>
    /// <returns></returns>
    public bool insertInto(string name, string password, string gender)
    {
        string postString = "name=" + name + "&password=" + password + "&gender=" + gender;
        Debug.Log("name:" + name);
        Debug.Log("password:" + password);
        Debug.Log("gender:" + gender);
        byte[] postData = Encoding.UTF8.GetBytes(postString);//编码，尤其是汉字，事先要看下抓取网页的编码方式
        string url = UserInfo.urlSqlRegister;//地址
        WebClient webClient = new WebClient();
        webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");//采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可 
        byte[] responseData = webClient.UploadData(url, "POST", postData);//得到返回字符流
        string srcString = Encoding.UTF8.GetString(responseData);//解码
        Debug.Log("结果：" + srcString);
        if (srcString == "1")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
