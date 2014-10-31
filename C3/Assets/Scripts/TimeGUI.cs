﻿using UnityEngine;
using System.Collections;

public class TimeGUI : MonoBehaviour
{
	float milliseconds = 0;
	int seconds = 0;
	int minutes = 0;
	string displayTime;
	PlayerMotion timeRefScript;

	void Update()
	{
		GameObject timeRef = this.gameObject;
		//		GameObject timeRef = GameObject.Find("Character_2_withTime");
		timeRefScript = (PlayerMotion) timeRef.GetComponent(typeof(PlayerMotion));
		if(!timeRefScript.getIsDone() && !timeRefScript.getIsPaused()) {
			milliseconds += Time.deltaTime;
			if (milliseconds > 1)
			{
				seconds++;
				milliseconds = 0;
			}
			if (seconds > 60)
			{
				minutes++;
				seconds = 0;
			}
		}
	}
	void OnGUI()
	{
		displayTime = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString (".00").Replace (".", "");
		GUI.Box(new Rect(Screen.width * 0.45f, Screen.height * 0.95f, Screen.width * 0.1f, Screen.height * 0.05f),displayTime);

		if(timeRefScript.getIsPaused()) {
//			GUI.Window(new Rect(Screen.width * 0.25f,Screen.height * 0.25f,Screen.width * 0.5f,Screen.height * 0.5f));
			GUI.BeginGroup (new Rect(Screen.width * 0.25f,Screen.height * 0.25f,Screen.width * 0.5f,Screen.height * 0.6f));
			if(GUI.Button (new Rect(0,0,Screen.width * 0.5f,Screen.height * 0.2f), "<color=#e5d416><size=30>Resume</size></color>")) {
				timeRefScript.unPause();
			}
			if(GUI.Button (new Rect(0,Screen.height * 0.2f,Screen.width * 0.5f,Screen.height * 0.2f), "<color=#547fa4><size=30>Restart Maze</size></color>")) {
				Application.LoadLevel(1);
			}
			if(GUI.Button (new Rect(0,Screen.height * 0.4f,Screen.width * 0.5f,Screen.height * 0.2f), "<color=#d96262><size=30>Main Menu</size></color>")) {
				Application.LoadLevel(0);
			}
			
			GUI.EndGroup ();
		}

		if(timeRefScript.getIsDone()) {
			GUI.BeginGroup (new Rect(Screen.width * 0.25f,Screen.height * 0.25f,Screen.width * 0.5f,Screen.height * 0.6f));
			GUI.Box(new Rect(0,Screen.height * 0.1f,Screen.width * 0.5f,Screen.height * 0.1f), "<color=#e5d416><size=30>You Won! Your time was "+ displayTime +"</size></color>");
			if(GUI.Button (new Rect(0,Screen.height * 0.2f,Screen.width * 0.5f,Screen.height * 0.2f), "<color=#547fa4><size=30>Restart Maze</size></color>")) {
				Application.LoadLevel(1);
			}
			if(GUI.Button (new Rect(0,Screen.height * 0.4f,Screen.width * 0.5f,Screen.height * 0.2f), "<color=#d96262><size=30>Main Menu</size></color>")) {
				Application.LoadLevel(0);
			}

			GUI.EndGroup ();
		}
	}

}
