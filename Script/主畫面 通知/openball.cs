using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class openball : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GO;
    public GameObject Back;
    public Text main_message;
    private int checkLogin = global.login_check;
    private int checkCoupon = global.coupon_check;
    // private string inquire_email_check = global.email;
    void Start()
    {
        
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
        Back.SetActive(false);
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
            SceneManager.LoadScene("inquire");
        }
    }
    public void click_attractions(){
        SceneManager.LoadScene("explore");
    }
    public void click_buy(){
        SceneManager.LoadScene("explore");
    }
    public void click_food(){
        SceneManager.LoadScene("explore");
    }
}
