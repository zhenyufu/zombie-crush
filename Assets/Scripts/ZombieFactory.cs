using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public static GameObject plane;
	public static float start = 20f; 
	public static float width = 8.95f;

	public GameObject zombieType1;
	public GameObject zombieType2;
	public GameObject zombieType3;
	public GameObject zombieType4;
	public GameObject zombieType5;
	public GameObject zombieType6;

	public float time = 3f;
	public float widthOffset=1f;
	public float spwanRange=2f;
	public float zombieCoefficient=0.01f;
	public float zRange=1f;
	//public float exponentBase = 2f;
	private float spwanRangeExtend;
	private float startTime;
	private int baseNum=0;
	private int functionCallTime=0;
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
//		float currentTime = Time.time;
//		float elipsed = currentTime - startTime;
//		print (elipsed);
//		
//		int numZombie = Mathf.FloorToInt (2*elipsed/5+baseNum);//zombieCoefficient*Mathf.Pow (elipsed, 1));
//		for (int i=0; i<numZombie; i++) {
//			GameObject zombie = Instantiate (zombieType1) as GameObject;
//			
//			zombie.transform.position = new Vector3 (Random.Range(-width+widthOffset, width-widthOffset), 1f, Random.Range(start, start+zRange));
//			
//			
//			
//			
//		}

		int currentScore = ScoreBoard.CurrentScore ();
		spwanRangeExtend = widthOffset+currentScore;
		ZombieSpawner (currentScore);
//		GameObject zombie = Instantiate (zombieType1) as GameObject;
//						zombie.transform.position = new Vector3 (-7f, 0.5f, start);
//		zombie.transform.position = new Vector3 (Random.Range (width-spwanRange-spwanRangeExtend, width-spwanRangeExtend), 0.5f, start);

				

			}

	 void ZombieSpawner(int currentScore){

//		for (int i=0; i<10; i++) {
//						GameObject zombie = Instantiate (zombieType1) as GameObject;
//			zombie.transform.position = new Vector3 (width-widthOffset, 0.5f, start);//-width + widthOffset=leftmost; 0=mid;width-widthOffset=rightmost
//				}
		if (spwanRangeExtend + spwanRange < 2*width - widthOffset) {
			for(int i=0;i<3;i++){
						GameObject zombie = Instantiate (zombieType1) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (width - spwanRange - spwanRangeExtend, width - spwanRangeExtend), 0.5f, Random.Range (start,start+5f));}
		} 
		else if ((spwanRangeExtend + spwanRange >= 2*width - widthOffset) && currentScore < 30) {//the spawn range has went beyond the width
			for(int i=0;i<4;i++){
						int type = Random.Range (1, 4);
			//print(type);
						if (type == 1) {

								GameObject zombie = Instantiate (zombieType1) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, 5f), 0.5f,Random.Range (start,start+5f));
						} else if (type == 2) {

								GameObject zombie = Instantiate (zombieType2) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-5f, width - widthOffset), 0.5f, Random.Range (start,start+5f));
			}
			}
		}
		else if (currentScore >= 30) {
			functionCallTime++;
			int numZombie=Mathf.FloorToInt( Mathf.Log(functionCallTime, 2));
			for(int i=0;i<numZombie;i++){
				int type = Random.Range (2, 6);
				if(type==2){
				GameObject zombie = Instantiate (zombieType2) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, Random.Range (start,start+10f));


			}else if(type==3){
				GameObject zombie = Instantiate (zombieType3) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, Random.Range (start,start+10f));


			}else if(type==4){
				GameObject zombie = Instantiate (zombieType4) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, Random.Range (start,start+10f));
					
					
			}else if(type==5){
				GameObject zombie = Instantiate (zombieType5) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, Random.Range (start,start+10f));
					
					
			}else if(type==6){
				GameObject zombie = Instantiate (zombieType6) as GameObject;
				zombie.transform.position = new Vector3 (Random.Range (-width + widthOffset, width - widthOffset), 0.5f, Random.Range (start,start+10f));
					
					
			}



			}


		}





	}
}
