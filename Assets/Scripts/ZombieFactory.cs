using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public static GameObject plane;
	public static float start = 20f; 
	public static float width = 8.95f;

	public GameObject zombieType1;
	public GameObject zombieType2;
	public float time = 3f;
	public float widthOffset=1f;
	public float spwanRange=2f;
	public float zombieCoefficient=0.01f;
	public float zRange=1f;
	//public float exponentBase = 2f;
	private float spwanRangeExtend;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		InvokeRepeating("makeZombie", 1f, time);
		//plane = GameObject.Find("Plane");
		//start = 20f //start * plane.transform.localScale.z;
		//width = 8.95f //width * plane.transform.localScale.x;
		//print ("start: " +start);
		//print ("width: " + width);
	}
	// Update is called once per frame
	void FixedUpdate () {
		/*float currentTime = Time.time;
		float elipsed = currentTime - startTime;
		print (elipsed);

		int numZombie = Mathf.FloorToInt (zombieCoefficient*elipsed);//zombieCoefficient*Mathf.Pow (elipsed, 1));
		for (int i=0; i<numZombie; i++) {
			GameObject zombie = Instantiate (zombieType1) as GameObject;

			zombie.transform.position = new Vector3 (Random.Range(-width+widthOffset, width-widthOffset), 0.5f, start);




				}*/



	}

	void makeZombie(){
		float currentTime = Time.time;
		float elipsed = currentTime - startTime;
		print (elipsed);
		
		int numZombie = Mathf.FloorToInt (zombieCoefficient*elipsed);//zombieCoefficient*Mathf.Pow (elipsed, 1));
		for (int i=0; i<numZombie; i++) {
			GameObject zombie = Instantiate (zombieType1) as GameObject;
			
			zombie.transform.position = new Vector3 (Random.Range(-width+widthOffset, width-widthOffset), 0.5f, Random.Range(start, start+zRange));
			
			
			
			
		}

		//int currentScore = ScoreBoard.CurrentScore ();
		//spwanRangeExtend = widthOffset+currentScore;
		//ZombieSpawner (currentScore);
		//GameObject zombie = Instantiate (zombieType1) as GameObject;
						//zombie.transform.position = new Vector3 (-7f, 0.5f, start);
		//zombie.transform.position = new Vector3 (Random.Range (width-spwanRange-spwanRangeExtend, width-spwanRangeExtend), 0.5f, start);

				

			}

	 void ZombieSpawner(int currentScore){

		for (int i=0; i<10; i++) {
						GameObject zombie = Instantiate (zombieType1) as GameObject;
			zombie.transform.position = new Vector3 (width-widthOffset, 0.5f, start);//-width + widthOffset=leftmost; 0=mid;width-widthOffset=rightmost
				}
	/*	if (spwanRangeExtend + spwanRange < 2*width - widthOffset) {
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



				}*/
	}
}
