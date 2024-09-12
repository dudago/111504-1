using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;
using Assets;

public class openball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO;
    public GameObject video_check;
    public GameObject Back;
    public Text main_message;
    private int checkLogin = global.login_check;
    private int checkCoupon = global.coupon_check;
    private int answer_reset=global.answer_check;
    // private string inquire_email_check = global.email;
    void Start()
    {
         SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT content FROM `111- Qingshui`.announcement");
        if (sql.isDataSetNull(ds) != true)
        {
            if (ds != null)
            {
                string En = ds.Tables[0].Rows[0][1].ToString().Trim();
                Debug.Log(En);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_bell_open()
    {
        SceneManager.LoadScene("bell");

    }
    public void click_sure(){
        video_check.SetActive(false);
    }
    public void click_video_sure(){
        Back.SetActive(false);
        SceneManager.LoadScene("Guided_tour");
    }
    public void click_home(){
        SceneManager.LoadScene("main_page");
    }
    public void click_coupon(){
        if(checkLogin==1){
            SceneManager.LoadScene("use_QRCode");
        }
        else{
            main_message.text="請先加入會員\n才能使用優惠券功能喔!!";
            GO.SetActive(true);
        }
    }
    public void click_video(){
        video_check.SetActive(true);
    }
    public void click_map(){
        SceneManager.LoadScene("list");
    }
    public void click_use(){
        Application.OpenURL("https://www.hsabc.com.tw/");
    }
    public void clicl_member(){
        if(checkLogin==0){
            SceneManager.LoadScene("login");
        }
        else if(checkLogin==1){
            SceneManager.LoadScene("member");
        }
    }
    public void click_attractions(){
        SceneManager.LoadScene("HC souviner");
    }
    public void click_buy(){
        SceneManager.LoadScene("souviner explore");
    }
    public void click_food(){
        SceneManager.LoadScene("HC store");
    }
    public void click_answerQuestion()
    {
        if(checkLogin==1){
            answer_reset=0;
            global.answer_check=answer_reset;
            SceneManager.LoadScene("question_1");
        }
        else{
            main_message.text="請先加入會員\n才能使用優惠券功能喔!!";
            GO.SetActive(true);
        }
    }
}
