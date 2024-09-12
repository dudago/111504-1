using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using System;
using Assets;

public class chanceball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void answer1_click(){
        if(global.correct1=="0"){
            SceneManager.LoadScene("fail");
        }
        if (global.correct1=="1"){
            SceneManager.LoadScene("success");
        }
    }

    public void answer2_click(){
        if(global.correct2=="0"){
            SceneManager.LoadScene("fail");
        }
        if (global.correct2=="1"){
            SceneManager.LoadScene("success");
        }
       
    }

    public void answer3_click(){
        if(global.correct3=="0"){
            SceneManager.LoadScene("fail");
        }else if (global.correct3=="1"){
            SceneManager.LoadScene("success");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
