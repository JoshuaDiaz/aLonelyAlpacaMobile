﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHome : MonoBehaviour {

	public string menuLevel;
	public string levelSelect;
	GameObject currentLevel;
	currentLevelName currentLevelScript;
	GameObject previousLevel;
	currentLevelName previousLevelScript;
	
	// Use this for initialization
	void Start () {
		
	}
	
	public void goHome() {
		SceneManager.LoadScene(menuLevel, LoadSceneMode.Single);
		LoggingManager.instance.RecordEvent(7, "Player pressed HOME button.");
	}

	public void goToLevelSelect() {
		currentLevel = GameObject.Find("GameObject");
		currentLevelScript = currentLevel.GetComponent<currentLevelName>();
		currentLevelScript.currentLevelNameString = SceneManager.GetActiveScene().name;
		Debug.Log("current level name: " + currentLevelScript.currentLevelNameString);		
	
		SceneManager.LoadScene(levelSelect, LoadSceneMode.Single);
		LoggingManager.instance.RecordEvent(7, "Player pressed LEVEL SELECT button.");
	}

	public void goBackToPreviousLevel(){
		previousLevel = GameObject.Find("GameObject");
		previousLevelScript = previousLevel.GetComponent<currentLevelName>();
		SceneManager.LoadScene(previousLevelScript.currentLevelNameString, LoadSceneMode.Single);
	}
}
