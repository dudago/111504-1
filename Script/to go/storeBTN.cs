using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Assets;
using System;

public class storeBTN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void click_website()
    {
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT `official website` FROM `111- qingshui`.attractions where idattractions="+global.global_list+";");
        String url =ds.Tables[0].Rows[0][0].ToString().Trim();
        Application.OpenURL(url);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
