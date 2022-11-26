using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets;
using System;
using UnityEngine.UI;
using System.Data;

//記得要把inport都先import好(上面這些) 重要!!!
public class User: MonoBehaviour
{
    public InputField password;
    public InputField email;
    public InputField location;
    public Text loginMsg;
    private int member_login_check = global.login_check;
    public int userid;
    
    SqlAccess sql;
        void Start()
    {
        // checkLogin();
    }
    public void register()//註冊
    {
        string regDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        sql = new SqlAccess();//宣告
        DataSet ds = sql.QuerySet("SELECT * FROM `111- qingshui`.accounts where email='" + email.text + "'");//宣告一組資料命名為ds 並且使用sql語法搜尋資料庫是否有與這組email相同的email
        DataTable table = ds.Tables[0];
        if (table.Rows.Count == 0)//如果沒有東西回傳回來的話也就是原本沒有此email
        {
            if (isSpace(password) && isSpace(email) )//確認帳號與信箱是否有空直
            {
                sql.InsertInto("`111- qingshui`.accounts", new string[] { "`birth year`", "email",  "createTime", "location" }, new string[] { password.text, email.text, regDate, location.text });//sql 輸入語法
                loginMsg.text = "註冊成功";
                SceneManager.LoadScene("login");
            }
            else
            {
                loginMsg.text = "帳密不能為空值";
            }
        }
        else
        {
            loginMsg.text = "此帳號已經使用過，請換一個!";
            password.text="";
            email.text="";
        }

        sql.Close();//結束後記得關閉sql
    }
    
    public void Login()//登入功能
    {
        sql = new SqlAccess();//宣告
        if (email.text != null && password.text != null)//判斷是否有空直
        {
            DataSet ds = sql.QuerySet("SELECT idaccounts FROM `111- qingshui`.accounts where email ='" + email.text + "' and `birth year` ='" + password.text + "'");//sql 查詢語法
            DataTable table = ds.Tables[0];
            foreach (DataRow dataRow in table.Rows)
            {
                foreach (DataColumn dataColumn in table.Columns)
                {
                    Debug.Log("登入ID:" + dataRow[dataColumn]);//這條可以忽略 這是偵錯的時候用的
                    userid=Int32.Parse(dataRow[dataColumn].ToString());//把string 轉為int並且設為userid
                    PlayerPrefs.SetInt("ID", userid);
                    PlayerPrefs.SetString("email", email.text);
                }
            }
            if (table.Rows.Count > 0)
            {
                SqlAccess sql2 = new SqlAccess();
                DataSet ds2 = sql.QuerySet("SELECT expDate FROM `111- qingshui`.coupon where idaccounts="+userid+";");
                DataTable table2 = ds2.Tables[0];
                if (table2.Rows.Count != 0){
                string expdate= ds2.Tables[0].Rows[0][0].ToString().Trim();
                DateTime exday = DateTime.Parse(expdate);
                int result=DateTime.Compare(exday, DateTime.Today);
                if(result==1){
                    global.coupon_check=1;
                }  
                }
                
                loginMsg.text = "歡迎" + email.text + "登入";
                global.login_member=userid;
                member_login_check=1;
                global.login_check=member_login_check;
                SceneManager.LoadScene("member");
            }
            else
            {
                loginMsg.text = "帳號或密碼錯誤";
            }
        }
        sql.Close();
    }
    public void isLogin(){
        if(PlayerPrefs.GetInt("userid")!=0){
         Debug.Log(PlayerPrefs.GetInt("userid"));
        }else{
             Debug.Log("你尚未登入");
        }
    }
    ///<summary>
    /// 輸入的TextField 是否為空 回傳bool
    ///</summary>
    ///<param name = "inputField">inputField</param>
    public bool isSpace(InputField inputField){
        if(inputField.text.Length !=0){
            return true;
        }
            return false;
    }
    //檢查登入狀態
        private void checkLogin(){
        if( PlayerPrefs.GetInt("ID")!=0 && PlayerPrefs.GetString("email")!=null){
            SceneManager.LoadScene("member");
        }
        else{
            loginMsg.text="請先登入";
        }
        // int nInt = PlayerPrefs.GetInt("ID");
        // string sString = PlayerPrefs.GetString("username");
    }
     
}
