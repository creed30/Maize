﻿using UnityEngine;
using System.Collections;

public class MainMenuHandler : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			Debug.Log(Application.loadedLevel);
			if (Application.loadedLevel == 0) {
				Application.Quit();
			} else if (Application.loadedLevel != 2) {
				selectButton (0);
			} else if (Application.loadedLevel != 3) {
				selectButton (0);
			} else {
				selectButton (0);
			}
		}
	}

	public void selectButton(int button) {
		Application.LoadLevel (button);
	}

	public void getLevel() {
		}
}
