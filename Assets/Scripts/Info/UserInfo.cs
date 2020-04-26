

public static class UserInfo
{

    //php连接数据库
    public static string urlSql = "http://192.168.43.224:8181/test2.php";                //查询测试（登陆时用）
    public static string urlSqlLogin = "http://192.168.43.224:8181/login.php";            //查询 （登录）
    public static string urlSqlRegister = "http://192.168.43.224:8181/register.php";      //添加  （注册）
    public static string urlSqlFindInfo = "http://192.168.43.224:8181/FindInfo.php";

    public static string userName;
    public static string userPassword;
    public static string userId;
    public static string userGender;

    public static void SetUserName(string name)
    {
        userName = name;
    }

}
