using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.Data;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class QAstory : MonoBehaviour
{

    public Text nm;
    public Text stry;
    // Start is called before the first frame update
    void Start()
    {
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT a.name, b.attractionStory FROM `111- qingshui`.attractions as a join `111- qingshui`.attractionstory as b on a.idattractions=b.attractionID where a.idattractions= "+global.global_gps+" ;");
        Debug.Log(global.global_gps);
         if (ds != null){
            String name=  ds.Tables[0].Rows[0][0].ToString().Trim();
            String story=  ds.Tables[0].Rows[0][1].ToString().Trim();
            nm.text=name;
            stry.text=story;
         }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
