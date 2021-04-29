using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class WebApi : MonoBehaviour
{
    
    public static void Post(InventoryItem items )
    {
        string json = JsonUtility.ToJson(items);
        UnityWebRequest www = UnityWebRequest.Post("https://localhost:44362/home/post", json);
        
        
        www.SetRequestHeader("content-Type", "application/json");
        www.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(json));



        www.SendWebRequest();

        if (www.isDone)
        {
            print("done");
        }
        if(www.isNetworkError || www.isHttpError)
        {
            print(www.error);
        }
    }


}
