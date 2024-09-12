using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class inquire : MonoBehaviour
{
    public InputField inquire_account;
    public Text read_inquire_account;
    private string inquire_account_check = global.account;
    //ACCOUNT
    public Text input_gender;
    private string member_gender_check = global.gender;
    public Text message;
    private int member_login_check = global.login_check;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void click_logout(){
        member_login_check=0;
        global.login_check=member_login_check;
        SceneManager.LoadScene("login");
    }
}
