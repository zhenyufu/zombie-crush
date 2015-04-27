using UnityEngine;
using System.Collections;

public class MenuScript: MonoBehaviour {



	// Use this for initialization
	void Start () {
		//Debug.Log("MenuS Start");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartGame() {
		Application.LoadLevel("GameScene");
	}


	public void LoadMenu(){
		Application.LoadLevel("MenuScene");
	}
}
