using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class question : MonoBehaviour
{
    private int ans = global.answer_check;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_q1A(){
        ans ++;
        global.answer_check=ans;
        SceneManager.LoadScene("question_2");
    }
    public void click_q1B(){
        SceneManager.LoadScene("question_2");
    }
    public void click_q1C(){
        SceneManager.LoadScene("question_2");
    }
    public void click_q1D(){
        SceneManager.LoadScene("question_2");
    }

    public void click_q2A(){
        SceneManager.LoadScene("question_3");
    }
    public void click_q2B(){
        ans ++;
        global.answer_check=ans;
        SceneManager.LoadScene("question_3");
    }
    public void click_q2C(){
        SceneManager.LoadScene("question_3");
    }
    public void click_q2D(){
        SceneManager.LoadScene("question_3");
    }

    public void click_q3A(){
        if(ans>=2){
            SceneManager.LoadScene("success");
        }
        else{
            SceneManager.LoadScene("fail");
        }
    }
    public void click_q3B(){
        if(ans>=2){
            SceneManager.LoadScene("success");
        }
        else{
            SceneManager.LoadScene("fail");
        }
    }
    public void click_q3C(){
        ans++;
        if(ans>=2){
            SceneManager.LoadScene("success");
        }
        else{
            SceneManager.LoadScene("fail");
        }
    }
    public void click_q3D(){
        if(ans>=2){
            SceneManager.LoadScene("success");
        }
        else{
            SceneManager.LoadScene("fail");
        }
    }
}
