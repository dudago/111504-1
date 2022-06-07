using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class list : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void list_1()
    {
        SceneManager.LoadScene("map"); 
    }
    public void list_2()
    {
        SceneManager.LoadScene("map");
    }
    public void list_3()
    {
        SceneManager.LoadScene("map");
    }
    public void list_4()
    {
        SceneManager.LoadScene("map");
    }
    public void list_5()
    {
        SceneManager.LoadScene("map");
    }
    public void bact_list()
    {
        SceneManager.LoadScene("list");
    }
    public void back_total()
    {
        SceneManager.LoadScene("list");
    }
    public void click_store(){
        SceneManager.LoadScene("store");
    }
}
