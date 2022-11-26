using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Assets;
using System;
using Debug = UnityEngine.Debug;

public class QandA : MonoBehaviour
{
    public Text questy;
    public Text ct1;
    public Text ct2;
    public Text ct3;
    public Text cr1;
    public Text cr2;
    public Text cr3;

    // public String correct1;
    // public String correct2;
    // public String correct3;

    public int questId;

    // Start is called before the first frame update
    void Start()
    {
        
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT question, idquestion FROM `111- qingshui`.question where idattraction="+global.global_gps+" order by rand() limit 1;");
         if (ds != null){
            String quest=  ds.Tables[0].Rows[0][0].ToString().Trim();
            String questIdS=  ds.Tables[0].Rows[0][1].ToString().Trim();
            questId=Int32.Parse(questIdS);
            questy.text=quest;
            Debug.Log(quest);
         }
         
         

         SqlAccess sql2 = new SqlAccess();
         DataSet ds2 = sql2.QuerySet("SELECT content, correct FROM `111- qingshui`.answer where idquestion="+questId+";");
         if(ds2!= null){
            String content1= ds2.Tables[0].Rows[0][0].ToString().Trim();
            String content2= ds2.Tables[0].Rows[1][0].ToString().Trim();
            String content3= ds2.Tables[0].Rows[2][0].ToString().Trim();
            global.correct1= ds2.Tables[0].Rows[0][1].ToString().Trim();
            global.correct2= ds2.Tables[0].Rows[1][1].ToString().Trim();
            global.correct3= ds2.Tables[0].Rows[2][1].ToString().Trim();
            ct1.text="A.      "+content1;
            ct2.text="B.      "+content2;
            ct3.text="C.      "+content3;
            cr1.text=global.correct1;
            cr2.text=global.correct2;
            cr3.text=global.correct3;
         }
        
    }

    // public void answer1_click(){
    //     if(correct1=="0"){
    //         SceneManager.LoadScene("fail");
    //     }else if (correct1=="0"){
    //         SceneManager.LoadScene("success");
    //     }
    // }

    // public void answer2_click(){
    //     if(correct2=="0"){
    //         SceneManager.LoadScene("fail");
    //     }else if (correct2=="0"){
    //         SceneManager.LoadScene("success");
    //     }
    // }

    // public void answer3_click(){
    //     if(correct3=="0"){
    //         SceneManager.LoadScene("fail");
    //     }else if (correct3=="0"){
    //         SceneManager.LoadScene("success");
    //     }
    // }

    // Update is called once per frame
    void Update()
    {
        
    }
}
