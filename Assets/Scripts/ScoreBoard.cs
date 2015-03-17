using UnityEngine;
using System.Collections;

public static class ScoreBoard {

	// Use this for initialization
	// Use this for initialization
	private static int score;

	// Update is called once per frame
	public static void DestoyOneZombie(){
		score++;
	}
	
	public static int CurrentScore(){
		return score;
	}

}
