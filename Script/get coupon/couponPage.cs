using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Assets;
using System;
using UnityEngine.UI;
using System.Data;

public class couponPage : MonoBehaviour
{

    public Text txtDate;
    // Start is called before the first frame update
    void Start()
    {
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT expDate FROM `111- qingshui`.coupon where idaccounts="+global.login_member+";");
        DataTable table = ds.Tables[0];
         if (table.Rows.Count != 0){
            string eday = ds.Tables[0].Rows[0][0].ToString().Trim();
            txtDate.text=eday;
            Debug.Log(eday);
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
