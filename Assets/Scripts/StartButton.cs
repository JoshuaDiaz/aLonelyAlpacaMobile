﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
  public void startGame()
  {
    GameObject gmobjct = GameObject.FindWithTag("GameManager");
    Destroy(GameObject.Find("MusicTime"));
    SceneManager.LoadScene("B0.5 - Intro", LoadSceneMode.Single);
  }
}
