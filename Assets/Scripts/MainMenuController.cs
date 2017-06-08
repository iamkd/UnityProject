using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

	public UButton playButton, settingsButton;

	// Use this for initialization
	void Start () {
		playButton.signalOnClick.AddListener(OpenLevelMenu);
		settingsButton.signalOnClick.AddListener(OpenSettingsMenu);
	}

	void OpenLevelMenu() {
		SceneManager.LoadScene("Level1");
	}
	void OpenSettingsMenu() {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
