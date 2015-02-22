using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	private int width = 300;
	private int height = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void LoadLevel() {
		Application.LoadLevel("GameScene");
	}

	void OnGUI() {
		if (GUI.Button (new Rect ((Camera.main.pixelWidth-width)/2, (Camera.main.pixelHeight-width)/2, width, height), "START GAME")) {
			LoadLevel();	
		}
		
	}
}
