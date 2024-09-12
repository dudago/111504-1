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
        SceneManager.LoadScene("success");
    }
    public void click_q1B(){
        SceneManager.LoadScene("fail");
    }
    public void click_q1C(){
        SceneManager.LoadScene("fail");
    }
    public void click_q1D(){
        SceneManager.LoadScene("fail");
    }
}
