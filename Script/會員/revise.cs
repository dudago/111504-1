using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class revise : MonoBehaviour
{
    public InputField old_password;
    private string old_password_check = global.password;
    public InputField revise_password;
    public InputField revise_passwordCheck;
    public Text password_message;
    //PASSWORD
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void click_save_password(){
        string read_old_password = old_password.text.Trim();
        string read_revise_password = revise_password.text.Trim();
        string read_revise_passwordCheck = revise_passwordCheck.text.Trim();
        if(read_old_password==old_password_check){
            if(read_revise_password==read_revise_passwordCheck){
                global.password=read_revise_password;
                SceneManager.LoadScene("inquire");
            }
            else{
                password_message.text="密碼不相同";
            }
        }
        else{
            password_message.text="請確認原密碼是否正確";
        }
    }
}
