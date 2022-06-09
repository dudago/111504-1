using UnityEngine;
using System.Collections;

public class GetGPS : MonoBehaviour
{

    public string gps_info = "";
    public int flash_num = 1;
    public string gps_check = "";

    // Use this for initialization  
    void Start()
    {

    }

    void OnGUI()
    {
        GUI.skin.label.fontSize = 28;
        GUI.Label(new Rect(20, 350, 600, 48), this.gps_info);
        GUI.Label(new Rect(20, 50, 600, 48), this.flash_num.ToString());
        GUI.Label(new Rect(20, 400, 600, 48), this.gps_check);

        GUI.skin.button.fontSize = 50;
        if (GUI.Button(new Rect(Screen.width / 2 - 110, 200, 220, 85), "GPS定位"))
        {
            // 這裡需要啟動一個協同程式  
            StartCoroutine(StartGPS());
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 110, 500, 220, 85), "重新整理GPS"))
        {
            this.gps_info = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
            this.gps_info = this.gps_info + " Time:" + Input.location.lastData.timestamp;
            this.flash_num += 1;
        }
        if (GUI.Button(new Rect(Screen.width / 2 - 110, 800, 220, 85), "GPS判斷"))
        {
            // 這裡需要啟動一個協同程式  
            // StartCoroutine(StartGPS());
            if (Input.location.lastData.latitude >= 25.00 && Input.location.lastData.latitude <= 26.00 && Input.location.lastData.longitude >= 121.0 && Input.location.lastData.longitude <= 122.0)
            {
                this.gps_check = "老公家";
            }
            else if(Input.location.lastData.latitude >= 24.111 && Input.location.lastData.latitude <= 24.113 && Input.location.lastData.longitude >= 120.615 && Input.location.lastData.longitude <= 120.617)
            {
                this.gps_check = "台中高鐵站"; //24.112196553211174, 120.61611962835141 高鐵站座標
            }
            else if (Input.location.lastData.latitude >= 24.267 && Input.location.lastData.latitude <= 24.269 && Input.location.lastData.longitude >= 120.57 && Input.location.lastData.longitude <= 120.59)
            {
                this.gps_check = "牛罵頭遺址"; //24.26837253425851, 120.58053059071528 牛罵頭遺址
            }
            else if (Input.location.lastData.latitude >= 24.267 && Input.location.lastData.latitude <= 24.272 && Input.location.lastData.longitude >= 120.55 && Input.location.lastData.longitude <= 120.56)
            {
                this.gps_check = "港區藝術中心"; //24.27012873094046, 120.5577874102345 港區藝術中心
            }
            else if (Input.location.lastData.latitude >= 24.259 && Input.location.lastData.latitude <= 24.27 && Input.location.lastData.longitude >= 120.51 && Input.location.lastData.longitude <= 120.53)
            {
                this.gps_check = "台中港outlet"; //24.261086659567553, 120.51887504639194 outlet
            }
            else
            {
                this.gps_check = "失敗";
            }
        }
    }

    // Input.location = LocationService  
    // LocationService.lastData = LocationInfo   

    void StopGPS()
    {
        Input.location.Stop();
    }

    IEnumerator StartGPS()
    {
        // Input.location 用於訪問裝置的位置屬性（手持裝置）, 靜態的LocationService位置  
        // LocationService.isEnabledByUser 使用者設定裡的定位服務是否啟用  
        if (!Input.location.isEnabledByUser)
        {
            this.gps_info = "isEnabledByUser value is:" + Input.location.isEnabledByUser.ToString() + " Please turn on the GPS";
            yield return false;
        }

        // LocationService.Start() 啟動位置服務的更新,最後一個位置座標會被使用  
        Input.location.Start(10.0f, 10.0f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            // 暫停協同程式的執行(1秒)  
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if (maxWait < 1)
        {
            this.gps_info = "Init GPS service time out";
            yield return false;
        }

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            this.gps_info = "Unable to determine device location";
            yield return false;
        }
        else
        {
            this.gps_info = "N:" + Input.location.lastData.latitude + " E:" + Input.location.lastData.longitude;
            this.gps_info = this.gps_info + " Time:" + Input.location.lastData.timestamp;
            yield return new WaitForSeconds(100);
        }
    }

}