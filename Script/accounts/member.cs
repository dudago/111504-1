using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class member : MonoBehaviour
{
    public GameObject GO;
    public InputField input_account;
    private string member_account_check = global.account;
    //ACCOUNT
    public Text input_password_c;
    public InputField input_password;
    private string member_password_check = global.password;
    //PASSWORD
    public Text input_gender;
    private string member_gender_check = global.gender;
    public Text message;
    private int member_login_check = global.login_check;

    public void clickLtoRs()
    {
        SceneManager.LoadScene("register");
    }
    public void click_login(){
        string member_account = input_account.text.Trim();
        string member_password = input_password.text.Trim();
        if(member_account == member_account_check && member_password == member_password_check){
            member_login_check=1;
            global.login_check=member_login_check;
            SceneManager.LoadScene("member");
        }
        else
        {
            input_account.text="";
            input_password.text="";
            message.text="請確認帳號密碼是否正確！";
        }
    }
    public void click_register()
    {
        string member_password = input_password_c.text.Trim();
        global.password=member_password;
        string member_gender = input_gender.text.Trim();
        global.gender = member_gender;
        GO.SetActive(true); 
    }
    public void member_check(){
        GO.SetActive(false);
        SceneManager.LoadScene("login");
    }
}