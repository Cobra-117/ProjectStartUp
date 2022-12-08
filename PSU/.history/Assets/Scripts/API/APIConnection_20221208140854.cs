using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

// UnityWebRequest.Get example

// Access a website and use UnityWebRequest.Get to download a page.
// Also try to download a non-existing page. Display the error.

public class APIConnection : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
        //"https://tasty.p.rapidapi.com/recipes/get-more-info?id=8138"

        //
        StartCoroutine(GetRequest("https://tasty.p.rapidapi.com/recipes/list?from=0&size=1&tags=chinese%22"));
    }

    private void Print(int a = 6) {
        Debug.Log(a);
    }

    //Print();

    IEnumerator GetRequest(string uri)
    {

        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            webRequest.SetRequestHeader("X-RapidAPI-Key", "9c194ef45emshe5b0846676a63d6p18a69djsn4e869ac013a9");
            webRequest.SetRequestHeader("X-RapidAPI-Host", "tasty.p.rapidapi.com");

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                    // Debug.Log(webRequest.downloadHandler.text);
                    // var resultAsJson = JSONUtility.FromJson<ListResult>(webRequest.downloadHandler.text);
                    break;
            }
        }
    }
}