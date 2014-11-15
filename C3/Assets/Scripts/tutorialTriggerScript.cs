﻿using UnityEngine;
using System.Collections;

public class tutorialTriggerScript : MonoBehaviour {

	public GUIText t;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay () {
		Debug.Log ("Trigger entered!");
		t.enabled = true;
	}

	void OnTriggerExit () {
		t.enabled = false;
	}
}
