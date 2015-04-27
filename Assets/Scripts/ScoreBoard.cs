using UnityEngine;
using System.Collections;

public static class ScoreBoard {


	// Use this for initialization
	private static int score = 0 ;
	private static int fuel = 3;
	private static int TotalFuel=3;
	// Update is called once per frame
	public static void DestoyOneZombie(){
		score++;
		fuel++;
		Displayui.refresh();
	}
	public static void TankZombie(){
		score++;
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

	public static void goBeyondBound(){
		fuel -= 2;
		Displayui.refresh ();
	}

	public static void fireTank(){
		fuel -= 5;
		Displayui.refresh ();
		}

	public static void reload(){
		fuel = TotalFuel;
		score = 0;
	}

}
