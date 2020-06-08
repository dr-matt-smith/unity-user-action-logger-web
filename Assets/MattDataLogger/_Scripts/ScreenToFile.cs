using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;


/*
 * an EXAMPLE script - illustrating how to use the web logger
 */
public class ScreenToFile : MonoBehaviour
{

	private Text textInput;

	private SendToWebLog logSender;
	public void Start()
	{
		logSender = GameObject.Find("logsender").GetComponent<SendToWebLog>();
	}

	private void Awake()
	{
		textInput = GetComponent<Text>();
	}

	public void BUTTON_ACTION_LogTextToFile()
	{
		String message = textInput.text;
		logSender.LogLine(message);
	}

	public void BUTTON_ACTION_CreateTextFileWithUserId()
	{
		String userId = textInput.text;

		if (userId.Length < 1)
		{
			userId = "(empty)";
		}
		
		Debug.Log("user ID = " + userId);
		logSender.NewUserId(userId);
	}
	
	public void BUTTON_ACTION_Scene2()
	{
		// Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
		SceneManager.LoadScene("scene2");
	}


	

	
}
