using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class total : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void food_C()
    {
        SceneManager.LoadScene("map");
    }
    public void gift_C()
    {
        SceneManager.LoadScene("map");
    }
    public void view_C()
    {
        SceneManager.LoadScene("map");
    }
    public void road_C()
    {
        SceneManager.LoadScene("list");
    }
    public void video_C()
    {
        SceneManager.LoadScene("GPSLatLon");
    }
}
