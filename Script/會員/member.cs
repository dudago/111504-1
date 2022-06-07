using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class member : MonoBehaviour
{
    public InputField input_email;
    private string member_email_check = global.email;
    //EMAIL
    public InputField input_password;
    private string member_password_check = global.password;
    public InputField input_passwordCheck;
    //PASSWORD
    public InputField input_last_name;
    private string member_last_name_check = global.last_name;
    public InputField input_first_name;
    private string member_first_name_check = global.first_name;
    //NAME
    public Text input_year;
    private string member_year_check = global.year;
    public Text input_month;
    private string member_month_check = global.month;
    public Text input_date;
    private string member_date_check = global.date;
    //BIRTHDAY
    public Text input_gender;
    private string member_gender_check = global.gender;
    public Text message;
    private int member_login_check = global.login_check;


    public void clickLtoRs()
    {
        SceneManager.LoadScene("register");
    }
    public void clickIntoRe()
    {
        SceneManager.LoadScene("revise");
    }
    public void click_login(){
        string member_email = input_email.text.Trim();
        string member_password = input_password.text.Trim();
        if(member_email == member_email_check && member_password == member_password_check){
            member_login_check=1;
            global.login_check=member_login_check;
            SceneManager.LoadScene("inquire");
        }
        else
        {
            input_email.text="";
            input_password.text="";
            message.text="請確認帳號密碼是否正確！";
        }
    }
    public void click_register()
    {
        string member_password = input_password.text.Trim();
        string member_passwordCheck = input_passwordCheck.text.Trim();
        if(member_password==member_passwordCheck){
            global.password=member_password;
            string member_email = input_email.text.Trim();
            global.email=member_email;
            string member_first_name = input_first_name.text.Trim();
            global.first_name = member_first_name;
            string member_last_name = input_last_name.text.Trim();
            global.last_name = member_last_name;
            string member_gender = input_gender.text.Trim();
            global.gender = member_gender;
            string member_year = input_year.text.Trim();
            global.year = member_year;
            string member_month = input_month.text.Trim();
            global.month = member_month;
            string member_date = input_date.text.Trim();
            global.date = member_date;
            SceneManager.LoadScene("login");
        }
        else{
            input_password.text="";
            input_passwordCheck.text="";
            message.text="請確認密碼是否正確！";
        }
        
    }
}
