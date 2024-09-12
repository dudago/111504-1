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



public class strexplore : MonoBehaviour
{
int count;
    int over;

    // Start is called before the first frame update
    void Start()
    {
        SqlAccess sql = new SqlAccess();
        DataSet ds = sql.QuerySet("SELECT a.name,b.url FROM `111- qingshui`.attractions as a join `111- qingshui`.images as b on a.idattractions=b.attractionid where categoryID=1 order by a.idattractions;");
            if (ds != null)
            {
                count=0;
                over=ds.Tables[0].Rows.Count;
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    count++;
                    String nm = ds.Tables[0].Rows[i][0].ToString().Trim();
                    String url = ds.Tables[0].Rows[i][1].ToString().Trim();
                    // Debug.Log(url);
                    StartCoroutine(DownloadImage(url,nm)); 
                }
                
            }
    }


    IEnumerator DownloadImage(string MediaUrl, string nm)
    {
        GameObject suddenly = transform.GetChild(0).gameObject;
        GameObject g;
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
            Debug.Log(request.error);
        else{
			Texture2D webTexture = ((DownloadHandlerTexture)request.downloadHandler).texture as Texture2D;
			Sprite webSprite = SpriteFromTexture2D(webTexture);
            g = Instantiate(suddenly, transform);
            g.transform.GetChild(0).GetComponent<Text>().text = nm;
            g.transform.GetChild(1).GetComponent<Image>().sprite=webSprite; 
		}
        while(over==count-1)
        {
            Destroy(suddenly);
            over=0;
            count=0;
        }
    }
	
	Sprite SpriteFromTexture2D(Texture2D texture) {
		return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
	}

   public void hot()
    {
        SceneManager.LoadScene("store explorehot");
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
