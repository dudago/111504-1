using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets;
using System;
using UnityEngine.UI;
using System.Data;


public class START : MonoBehaviour
{
    private int answer_reset=global.answer_check;
    private int getCoupon = global.coupon_check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_start()
    {
        SceneManager.LoadScene("Guided_tour");
    }
    public void clicl_giveup(){
        SceneManager.LoadScene("main_page");
    }
    public void click_get_coupon(){
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT * FROM `111- qingshui`.coupon where idaccounts="+global.login_member+";");
        DataTable table = ds.Tables[0];
        DateTime eday= DateTime.Today.AddDays(60);
        Debug.Log(eday);
        string uid = global.login_member.ToString();
        string seday= eday.ToString("yyyy-MM-dd HH:mm:ss");
        
        if(table.Rows.Count==0){
            sql.InsertInto("`111- qingshui`.coupon", new string[] { "`idaccounts`", "expDate" }, new string[] { uid, seday });
        }else {
            sql.UpdateInto("`111- qingshui`.coupon", new string[] { " " }, new string[] { uid, seday }, "idaccounts", uid  );
        }
        getCoupon=1;
        global.coupon_check=getCoupon;
        SceneManager.LoadScene("main_page");
    }
}
