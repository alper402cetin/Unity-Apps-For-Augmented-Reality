// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var welcome = Welcome.FromJson(jsonString);
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json.Linq;
using System;
using Newtonsoft.Json;
using System.IO;
//using System.Web.Extensions;
//using System.Web.Script.Serialization;

public class Example1 : MonoBehaviour
{
    string UnityUrl = "https://demo0173267.mockable.io";
    InputField outputArea;

    public void Start()
    {
        outputArea = GameObject.Find("OutputArea").GetComponent<InputField>();
        if (outputArea == null)
            Debug.Log("It is null");
        GameObject.Find("GetButton").GetComponent<Button>().onClick.AddListener(GetData);
    }

    public void GetData() => StartCoroutine(GetData_Coroutine());

    public IEnumerator GetData_Coroutine()
    {
        outputArea.text = "Loading...";
        string uri = UnityUrl;
        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                outputArea.text = request.error;
            else
            {
                string temp = request.downloadHandler.text;
                //var serializer = new JavaScriptSerializer();
                //Console.WriteLine("Goodbye");
                //QuickType.Welcome dummy;

                JObject json = JObject.Parse(temp);
                //Debug.Log(json.ToString());
                JsonReader reader = new JsonTextReader(new StringReader(temp));

                //dummy = JsonSerializer.Deserialize<QuickType.Welcome>(reader.ToString());

                QuickType.Welcome result = new QuickType.Welcome();
                //var dummy = JsonConvert.DeserializeObject<QuickType.Welcome>(temp).ToString();
                result.Status = (int)json;
                int i = 0;

                if (json == null)
                    Debug.Log("It is null");

                while (i<10)
                {
                    
                    //Debug.Log((result.Status));
                    i++;
                }
                //Debug.Log(i);
                outputArea.text = request.downloadHandler.text;
            }
        }
    }
}