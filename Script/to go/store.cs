using System.Net.Mime;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;
using Assets;
using Debug = UnityEngine.Debug;
using UnityEngine.Networking;



public class store : MonoBehaviour
{
    public Text storeName;
    public Text storeAddress;
    public Text storeTell;
    public Text storeStory;
    public RawImage storePic;

    public String web="";
    public String tell="";
    public String map="";

    UnityWebRequest store_Texture;
    
    
    
    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT a.name, a.address, a.tell, b.url, c.attractionstory, a.maps, a.`official website` FROM `111- qingshui`.attractions as a join `111- qingshui`.images as b on a.idattractions = b.attractionid join `111- qingshui`.attractionstory as c on b.attractionid=c.attractionID where a.idattractions = "+global.global_list+";");
         if (ds != null)
            {
                    String nm = ds.Tables[0].Rows[0][0].ToString().Trim();
                    String address = ds.Tables[0].Rows[0][1].ToString().Trim();
                    tell = ds.Tables[0].Rows[0][2].ToString().Trim();
                    String url = ds.Tables[0].Rows[0][3].ToString().Trim();
                    String story = ds.Tables[0].Rows[0][4].ToString().Trim();
                    map = ds.Tables[0].Rows[0][5].ToString().Trim();
                    web = ds.Tables[0].Rows[0][6].ToString().Trim();
                    // Debug.Log(url);

                    store_Texture= UnityWebRequestTexture.GetTexture(url);

                    yield return store_Texture.SendWebRequest();
                    
                      if (store_Texture.isNetworkError || store_Texture.isHttpError)
                        {
                            Debug.Log("有問題");
                            //Debug.Log(avatar_Texture.error);
                        }
                        else
                        {
                            storePic.texture = DownloadHandlerTexture.GetContent(store_Texture);
                            storePic.SetNativeSize();
                            if(global.global_list==10){
                                storePic.rectTransform.sizeDelta = new Vector2(1000 , 600);
                            }else{
                              storePic.rectTransform.sizeDelta = new Vector2(899, 700);  
                            }
                            
                        }
                     
                    storeName.text= nm;
                    storeAddress.text = address;
                    storeTell.text = tell;
                    storeStory.text = story;
                    

                    


                
            }
            
    }

    public void click_website()
    {
        
        Application.OpenURL(web);
        
        

    }

    public void click_phone()
    {
       
        Application.OpenURL("tel://"+tell);
        
    }
    
    public void click_map()
    {
        Application.OpenURL(map);
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
   
}
