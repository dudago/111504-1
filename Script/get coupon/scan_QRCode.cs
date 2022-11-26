using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZXing;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Assets;

public class scan_QRCode : MonoBehaviour
{
    public RawImage cameraTexture; // 即時預覽相機畫面
    public Text txtQRcode; // 掃完 QR-CODE 後，顯示裡面的字串
    private WebCamTexture webCameraTexture;
    private BarcodeReader barcodeReader;

    IEnumerator Start()
    {
        barcodeReader = new BarcodeReader();
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            WebCamDevice[] devices = WebCamTexture.devices;
            string devicename = devices[0].name;
            webCameraTexture = new WebCamTexture(devicename, 1000, 1000);
            cameraTexture.texture = webCameraTexture;
            webCameraTexture.Play();

            txtQRcode.text = "相機解析度 : " + webCameraTexture.width + "x" + webCameraTexture.height;

            InvokeRepeating("DecodeQR", 0, 0.5f); // 0.5 秒掃描一次
        }
    }

    private void DecodeQR()
    {
        var br = barcodeReader.Decode(webCameraTexture.GetPixels32(), webCameraTexture.width, webCameraTexture.height);
        if (br != null)
        {
            txtQRcode.text = br.Text;
        }
    }
      public void click_start(){
        SqlAccess sql = new SqlAccess();
        DataSet ds= sql.QuerySet("SELECT name FROM `111- qingshui`.attractions;");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++){
            string nm = ds.Tables[0].Rows[i][0].ToString().Trim();
             if(txtQRcode.text == nm){
             SceneManager.LoadScene("coupon");
             webCameraTexture.Stop();
             }
        }
       
        if(txtQRcode.text==null){
            txtQRcode.text = "請確認QRCode是否正確，並且重新掃描";
        }
    }
    public void QR_home(){
        webCameraTexture.Stop();
        SceneManager.LoadScene("main_page");
        webCameraTexture.Stop();
    }
}
