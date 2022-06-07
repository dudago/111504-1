using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class map : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void pic_web()
    {
        Application.OpenURL("https://www.hsabc.com.tw/");
    }
    public void map_c()
    {
        Application.OpenURL("https://www.google.com/maps/place/%E6%B8%85%E6%B0%B4%E6%95%A3%E6%AD%A5/@24.2697744,120.5770347,20z/data=!4m5!3m4!1s0x3469147f0850b759:0x5e75014e7e6e85b8!8m2!3d24.2698431!4d120.5769685");
    }
    public void map_1_next()
    {
        SceneManager.LoadScene("map_2");
    }
    public void map_2_next()
    {
        SceneManager.LoadScene("map_3");
    }
    public void map_3_next()
    {
        SceneManager.LoadScene("map");
    }
    public void map_1_pervious()
    {
        SceneManager.LoadScene("map_3");
    }
    public void map_2_pervious()
    {
        SceneManager.LoadScene("map");
    }
    public void map_3_pervious()
    {
        SceneManager.LoadScene("map_2");
    }
}
