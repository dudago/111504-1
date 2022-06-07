using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inquire : MonoBehaviour
{
    public InputField inquire_email;
    public Text read_inquire_email;
    private string inquire_email_check = global.email;
    //EMAIL
    public InputField inquire_last_name;
    public Text read_inquire_last_name;
    private string inquire_last_name_check = global.last_name;
    public InputField inquire_first_name;
    public Text read_inquire_first_name;
    private string inquire_first_name_check = global.first_name;
    //NAME
    public Text inquire_year;
    private string inquire_year_check = global.year;
    public Text inquire_month;
    private string inquire_month_check = global.month;
    public Text inquire_date;
    private string inquire_date_check = global.date;
    //BIRTHDAY
    public Text inquire_gender;
    private string inquire_gender_check = global.gender;
    private int member_login_check = global.login_check;

    // Start is called before the first frame update
    void Start()
    {
        read_inquire_email.text=inquire_email_check;
        read_inquire_last_name.text=inquire_last_name_check;
        read_inquire_first_name.text=inquire_first_name_check;
    }

    // Update is called once per frame
    void Update()
    {   
        if(inquire_year.text=="出生年"){
            inquire_year.text=inquire_year_check;
            inquire_month.text=inquire_month_check;
            inquire_date.text=inquire_date_check;
            inquire_gender.text=inquire_gender_check;
        }
    }
    public void click_inquire_save()
    {
        string save_email = inquire_email.text.Trim();
        if(save_email != ""){
            global.email=save_email;
        }
        string save_first_name = inquire_first_name.text.Trim();
        if(save_first_name != ""){
            global.first_name = save_first_name;
        }
        string save_last_name = inquire_last_name.text.Trim();
        if(save_last_name != ""){
            global.last_name = save_last_name;
        }
        string save_gender = inquire_gender.text.Trim();
        global.gender = save_gender;
        string save_year = inquire_year.text.Trim();
        global.year = save_year;
        string save_month = inquire_month.text.Trim();
        global.month = save_month;
        string save_date = inquire_date.text.Trim();
        global.date = save_date;
        read_inquire_email.text=inquire_email_check;
        read_inquire_last_name.text=inquire_last_name_check;
        read_inquire_first_name.text=inquire_first_name_check;
        inquire_year.text=inquire_year_check;
        inquire_month.text=inquire_month_check;
        inquire_date.text=inquire_date_check;
        inquire_gender.text=inquire_gender_check;
    }
    public void click_logout(){
        member_login_check=0;
        global.login_check=member_login_check;
        SceneManager.LoadScene("login");
    }
}
