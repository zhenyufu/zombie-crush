using UnityEngine;
using System.Collections;

public static class ScoreBoard {


	// Use this for initialization
	private static int score;
	private static int fuel = 50;

	// Update is called once per frame
	public static void DestoyOneZombie(){
		score++;
		fuel++;
		Displayui.refresh();

	}
	
	public static int CurrentScore(){
		return score;
	}

	public static int CurrentFuel(){
		return fuel;
	}


	public static void fire(){
		fuel--;
		Displayui.refresh();
	}



}
