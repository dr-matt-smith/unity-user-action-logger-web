// file: WebLeaderBoard.cs
// based on Unity example at:
// https://docs.unity3d.com/2020.1/Documentation/ScriptReference/Networking.UnityWebRequest.Get.html

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.Networking;



public class SendToWebLog : MonoBehaviour
{
	private string apiURI = "https://user-logger.frb.io/api";
	private static string userId = "(unknown)"; // not set yet

	private string url = "";

	public void NewUserId(string newUserId)
	{
		userId = newUserId;
		LogLine("New Participant Id = " + userId);
	}

	public void LogLine(string message)
	{
		string sceneName = SceneManager.GetActiveScene().name;

		url = apiURI;
		url += "/" + userId;
		url += "/" + sceneName;
		url += "/" + message;
		
		StartCoroutine(  LoadWww() );


	}
	
	private IEnumerator LoadWww()
	{
		Debug.Log("URL = " + url);
		using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
		{
			webRequest.certificateHandler = new CertHandler();

			// Request and wait for the desired page.
			yield return webRequest.SendWebRequest();

			switch (webRequest.isDone)
			{
				case true:
					Debug.Log("success: " + webRequest.downloadHandler.text);
					break;
				
				case false:
					Debug.Log("web request error");
					break;					
			}
		}
	}
	
} 