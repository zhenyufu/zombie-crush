using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public static GameObject plane;
	public static float start = 5f; 
	public static float width = 5f;

	public GameObject zombieType1;
	public GameObject zombieType2;
	public float time = 1f;
	public float widthOffset=0f;
	public float spwanRange=2f;
	private float spwanRangeExtend;
	// Use this for initialization
	void Start () {
		InvokeRepeating("makeZombie", 1f, time);
		plane = GameObject.Find("Plane");
		start = start * plane.transform.localScale.z;
		width = width * plane.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void makeZombie(){
		int currentScore = ScoreBoard.CurrentScore ();
		spwanRangeExtend = widthOffset+currentScore;
		ZombieSpawner (currentScore);
		//GameObject zombie = Instantiate (zombieType1) as GameObject;
						//zombie.transform.position = new Vector3 (-7f, 0.5f, start);
		//zombie.transform.position = new Vector3 (Random.Range (width-spwanRange-spwanRangeExtend, width-spwanRangeExtend), 0.5f, start);

				

	}

	 void ZombieSpawner(int currentScore){
		if (spwanRangeExtend + spwanRange < 2*width - widthOffset) {
						GameObject zombie = Instantiate (zombieType1) as GameObject;
						zombie.transform.position = new Vector3 (Random.Range (width - spwanRange - spwanRangeExtend, width - spwanRangeExtend), 0.5f, start);
		} else if ((spwanRangeExtend + spwanRange >= 2*width - widthOffset) && currentScore < 50) {//the spawn range has went beyond the width
						int type = Random.Range (1, 3);
			print(type);
						if (type == 1) {

								GameObject zombie = Instantiate (zombieType1) as GameObject;
								zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, 0), 0.5f, start);
						} else if (type == 2) {

								GameObject zombie = Instantiate (zombieType2) as GameObject;
								zombie.transform.position = new Vector3 (Random.Range (0, width - widthOffset), 0.5f, start);
						}


				} else if (currentScore >= 50) {
					GameObject zombie = Instantiate (zombieType2) as GameObject;
								zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, start);



				}
	}
}
