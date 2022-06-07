using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class START : MonoBehaviour
{
    private int answer_reset=global.answer_check;
    private int getCoupon = global.coupon_check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_start()
    {
        SceneManager.LoadScene("Guided_tour");
    }
    public void click_go()
    {
        answer_reset=0;
        global.answer_check=answer_reset;
        SceneManager.LoadScene("question_1");
    }
    public void clicl_giveup(){
        SceneManager.LoadScene("get_start");
    }
    public void click_get_coupon(){
        getCoupon=1;
        global.coupon_check=getCoupon;
        SceneManager.LoadScene("main_page");
    }
}
