using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {

	static Text fs;
	// Use this for initialization
	void Start () {
		fs = GameObject.Find("FinalScore").GetComponent<Text>(); 
		fs.text = ScoreBoard.fs.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
