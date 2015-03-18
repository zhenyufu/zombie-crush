using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Displayui : MonoBehaviour {

	static Text displayScore;
	static Text displayFuel;


	// Use this for initialization
	void Start () {
		//update the ui score
		displayScore = GameObject.Find("Score").GetComponent<Text>(); 

		displayFuel = GameObject.Find("Fuel").GetComponent<Text>(); 
		//Debug.Log (displayScore);

	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public static void refresh(){
		displayScore.text = ScoreBoard.CurrentScore().ToString();
		displayFuel.text = ScoreBoard.CurrentFuel().ToString();
	}


}
