using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {


	public GameObject carPrefab;
	public float z;

	private Vector2 startPos;
	private Vector2 endPos;
	private bool isleftSwipe;
	public  float carRate=1f;
	//private float nextCar=0f;
	private float currentTime = 0f;// interval 

	// Use this for initialization
	void Start () {
		isleftSwipe = false;
	}
	
	// Update is called once per frame

	void Update () {
		if((ScoreBoard.CurrentFuel() == 0 )&& (GameObject.FindGameObjectWithTag("Car") == null)) {
			ScoreBoard.reload();
			Application.LoadLevel("WinScene");
		}

		currentTime += Time.deltaTime;

	if (Input.touchCount > 0) {
			Touch touch=Input.GetTouch(0);
								if (touch.phase == TouchPhase.Began) {
										startPos = touch.position;
										endPos = touch.position;
								}
			
								if (touch.phase == TouchPhase.Moved) {
										endPos = touch.position;
										if (Mathf.Abs (startPos.x - endPos.x) > Mathf.Abs (startPos.y - endPos.y)) {
					
												if (endPos.x - startPos.x < -10) {//left swipe
													isleftSwipe=true;
												}
										}
								}
			startPos=endPos;
			if(isleftSwipe){
				RaycastHit hit2;
				Ray ray2 = Camera.main.ScreenPointToRay (startPos);
				if (Physics.Raycast (ray2, out hit2)) {
					if(currentTime >= carRate && ScoreBoard.CurrentFuel()>0){
						currentTime = 0;
						ScoreBoard.fire();

					Vector3 newPosition = hit2.point;
					GameObject car = Instantiate (carPrefab) as GameObject;
					if (newPosition.z <= 20f && newPosition.z > 15f) {
						
						car.transform.position = new Vector3 (10f, 0f, 17.5f);
					} else if (newPosition.z <= 15f && newPosition.z > 10f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, 12.5f);
					}
					if (newPosition.z <= 10f && newPosition.z > 5f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, 7.5f);
					}
					if (newPosition.z <= 5f && newPosition.z > 0f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, 2.5f);
					}
					if (newPosition.z <= 0f && newPosition.z > -5f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, -2.5f);
					} else if (newPosition.z <= -5f && newPosition.z > -10f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, -7.5f);
					}
					if (newPosition.z <= -10f && newPosition.z > -15f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, -12.5f);
					}
					if (newPosition.z <= -15f && newPosition.z >= -20f) {
						//GameObject car = Instantiate (carPrefab) as GameObject;
						car.transform.position = new Vector3 (10f, 0f, -17.5f);
					}
					}
				}
			}
				if(touch.phase == TouchPhase.Ended)
					{
					startPos = Vector2.zero;
					endPos = Vector2.zero;
					isleftSwipe=false;
				}
		}
		
		else if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if(currentTime >= carRate && ScoreBoard.CurrentFuel()>0){
					currentTime = 0;
					ScoreBoard.fire();
				Vector3 newPosition = hit.point;
				GameObject car=Instantiate( carPrefab ) as GameObject;
				
				
				//car.transform.position=new Vector3(10f, 0f, z);
				/*if(newPosition.z<=20f && newPosition.z>10f){
				car.transform.position=new Vector3(10f, 0f, 15f);
				}
				else if(newPosition.z<=10f && newPosition.z>0f){
					car.transform.position=new Vector3(10f, 0f, 5f);
				}
				if(newPosition.z<=0f && newPosition.z>=-10f){
					car.transform.position=new Vector3(10f, 0f, -5f);
				}
				if(newPosition.z<=-10f && newPosition.z>=-20f){
					car.transform.position=new Vector3(10f, 0f, -15f);
				}*/
				if(newPosition.z<=20f && newPosition.z>15f){
					car.transform.position=new Vector3(10f, 0f, 17.5f);
				}
				else if(newPosition.z<=15f && newPosition.z>10f){
					car.transform.position=new Vector3(10f, 0f, 12.5f);
				}
				if(newPosition.z<=10f && newPosition.z>5f){
					car.transform.position=new Vector3(10f, 0f, 7.5f);
				}
				if(newPosition.z<=5f && newPosition.z>0f){
					car.transform.position=new Vector3(10f, 0f, 2.5f);
				}
				if(newPosition.z<=0f && newPosition.z>-5f){
					car.transform.position=new Vector3(10f, 0f, -2.5f);
				}
				else if(newPosition.z<=-5f && newPosition.z>-10f){
					car.transform.position=new Vector3(10f, 0f, -7.5f);
				}
				if(newPosition.z<=-10f && newPosition.z>-15f){
					car.transform.position=new Vector3(10f, 0f, -12.5f);
				}
				if(newPosition.z<=-15f && newPosition.z>=-20f){
					car.transform.position=new Vector3(10f, 0f, -17.5f);
				}
				}
			}
		}

		// make sure that currentTime doesn't grow too big
		if (currentTime > 100f) {
			currentTime = carRate;
		}
	}// end of update
}
