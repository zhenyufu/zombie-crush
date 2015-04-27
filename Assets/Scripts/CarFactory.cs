using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CarFactory : MonoBehaviour {


	public GameObject carPrefab;
	public GameObject carPrefab2;

	public float z;

	private Vector2 startPos;
	private Vector2 endPos;
	private bool isleftSwipe;
	private bool isupSwipe;
	public  float carRate=1f;
	public float tankRate=1f;
	//private float nextCar=0f;
	private float currentTime = 0f;// interval 
	private float offsetY = 1.2f;
	// Use this for initialization
	//
	private int startPower = 0;
	private float holdTime;
	public Slider carSlider;



	void Start () {
		isleftSwipe = false;
		isupSwipe = false;
	}


	// Update is called once per frame

	void Update () {
		if((ScoreBoard.CurrentFuel() <= 0 ) && GameObject.FindGameObjectWithTag("Car") == null && (GameObject.FindGameObjectWithTag("Tank"))==null) {
			ScoreBoard.reload();
			Application.LoadLevel("WinScene");
		}

		currentTime += Time.deltaTime;

	if (Input.touchCount > 0) {
						Touch touch = Input.GetTouch (0);
						if (touch.phase == TouchPhase.Began) {
								startPos = touch.position;
								endPos = touch.position;
						}
			
						if (touch.phase == TouchPhase.Moved) {
								endPos = touch.position;
								if (Mathf.Abs (startPos.x - endPos.x) > Mathf.Abs (startPos.y - endPos.y)) {
					
										if (endPos.x - startPos.x < -10) {//left swipe
												isleftSwipe = true;
										}
								} else {
										//Upward Swipe
				
										isupSwipe = true;

											

								}
						}
						startPos = endPos;
						if (isleftSwipe) {
								RaycastHit hit2;
								Ray ray2 = Camera.main.ScreenPointToRay (startPos);
								if (Physics.Raycast (ray2, out hit2)) {
										if (currentTime >= carRate && ScoreBoard.CurrentFuel () > 0) {
												currentTime = 0;
												ScoreBoard.fire ();

												Vector3 newPosition = hit2.point;
												GameObject car = Instantiate (carPrefab) as GameObject;
												if (newPosition.z <= 20f && newPosition.z > 15f) {
						
														car.transform.position = new Vector3 (10f, offsetY, 17.5f);
												} else if (newPosition.z <= 15f && newPosition.z > 10f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, 12.5f);
												}
												if (newPosition.z <= 10f && newPosition.z > 5f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, 7.5f);
												}
												if (newPosition.z <= 5f && newPosition.z > 0f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, 2.5f);
												}
												if (newPosition.z <= 0f && newPosition.z > -5f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, -2.5f);
												} else if (newPosition.z <= -5f && newPosition.z > -10f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, -7.5f);
												}
												if (newPosition.z <= -10f && newPosition.z > -15f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, -12.5f);
												}
												if (newPosition.z <= -15f && newPosition.z >= -20f) {
														//GameObject car = Instantiate (carPrefab) as GameObject;
														car.transform.position = new Vector3 (10f, offsetY, -17.5f);
												}
										}
								}
						}

			/*
						if (isupSwipe) {
								RaycastHit hit2;
								Ray ray2 = Camera.main.ScreenPointToRay (startPos);
								if (Physics.Raycast (ray2, out hit2)) {
										if (currentTime >= tankRate && ScoreBoard.CurrentFuel () >= 5) {

												currentTime = 0;
												ScoreBoard.fireTank ();
							
												//Vector3 newPosition = hit2.point;
												GameObject tank1 = Instantiate (tankPrefab) as GameObject;
												tank1.transform.position = new Vector3 (-4, offsetY, -20);

												GameObject tank2 = Instantiate (tankPrefab) as GameObject;
												tank2.transform.position = new Vector3 (4, offsetY, -20);

										}
								}
						}
						*/

						if (touch.phase == TouchPhase.Ended) {
								startPos = Vector2.zero;
								endPos = Vector2.zero;
								isleftSwipe = false;
								isupSwipe = false;
						}
		} 


		else if (Input.GetMouseButton (0)) {
			holdTime+=Time.deltaTime;
			if(holdTime > 0.01f){
				startPower += 2;
				carSlider.value = startPower;
				holdTime = 0f;
			}
			
			
			
			
			
			
		} 
		if (Input.GetMouseButtonUp(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if(hit.transform.gameObject.tag == "TankUI"){
					Camera.main.GetComponent<Tankfactory>().fireTank();
				}
				else if(Camera.main.GetComponent<Tankfactory>().checkClear()){
				if (currentTime >= carRate && ScoreBoard.CurrentFuel () > 0) {
					currentTime = 0;
					ScoreBoard.fire ();
					Vector3 newPosition = hit.point;
					GameObject carleft = Instantiate (carPrefab) as GameObject;
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

					if (newPosition.z <= 20f && newPosition.z > 10f || newPosition.z >= - 20f && newPosition.z < - 10f){
						offsetY = 1.7f;
					}
					if (newPosition.z <= 20f && newPosition.z > 15f  ) {
						//	GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, 17.5f);
					}
					//										else if(newPosition.z <= 20f && newPosition.z > 15f && newPosition.x<= 0f) {
					//												GameObject carright = Instantiate (carPrefab2) as GameObject;
					//												carright.transform.position = new Vector3 (-10f, offsetY, 17.5f);
					//										}
					if (newPosition.z <= 15f && newPosition.z > 10f ) {
						//	GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, 12.5f);
					}
					//										else if(newPosition.z <= 15f && newPosition.z > 10f && newPosition.x<= 0f) {
					//												GameObject carright = Instantiate (carPrefab2) as GameObject;
					//												carright.transform.position = new Vector3 (-10f, offsetY, 12.5f);
					//										}
					if (newPosition.z <= 10f && newPosition.z > 5f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, 7.5f);
					}
					//										else if(newPosition.z <= 10f && newPosition.z > 5f && newPosition.x<= 0f) {
					//												GameObject carright = Instantiate (carPrefab2) as GameObject;
					//												carright.transform.position = new Vector3 (-10f, offsetY, 7.5f);
					//										}
					if (newPosition.z <= 5f && newPosition.z > 0f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, 2.5f);
					}
					//					else if(newPosition.z <= 5f && newPosition.z > 0f && newPosition.x<= 0f) {
					//						GameObject carright = Instantiate (carPrefab2) as GameObject;
					//						carright.transform.position = new Vector3 (-10f, offsetY, 2.5f);
					//					}
					if (newPosition.z <= 0f && newPosition.z > -5f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, -2.5f);
					}
					//					else if(newPosition.z <= 0f && newPosition.z > -5f && newPosition.x<= 0f) {
					//						GameObject carright = Instantiate (carPrefab2) as GameObject;
					//						carright.transform.position = new Vector3 (-10f, offsetY, -2.5f);
					//					}
					if (newPosition.z <= -5f && newPosition.z > -10f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, -7.5f);
					}
					//					else if(newPosition.z <= -5f && newPosition.z > -10f && newPosition.x<= 0f) {
					//						GameObject carright = Instantiate (carPrefab2) as GameObject;
					//						carright.transform.position = new Vector3 (-10f, offsetY, -7.5f);
					//					}
					if (newPosition.z <= -10f && newPosition.z > -15f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, -12.5f);
					}
					//					else if(newPosition.z <= -10f && newPosition.z > -15f && newPosition.x<= 0f) {
					//						GameObject carright = Instantiate (carPrefab2) as GameObject;
					//						carright.transform.position = new Vector3 (-10f, offsetY, -12.5f);
					//					}					
					if (newPosition.z <= -15f && newPosition.z >= -20f ) {
						//GameObject carleft = Instantiate (carPrefab) as GameObject;
						carleft.transform.position = new Vector3 (10f, offsetY, -17.5f);
					}
					//					else if(newPosition.z <= -15f && newPosition.z >= -20f && newPosition.x<= 0f) {
					//						GameObject carright = Instantiate (carPrefab2) as GameObject;
					//						carright.transform.position = new Vector3 (-10f, offsetY, -17.5f);
					//					}					
					
					/*	if (newPosition.z <= 10f && newPosition.z > 5f) {
												car.transform.position = new Vector3 (10f, offsetY, 7.5f);
										}
										if (newPosition.z <= 5f && newPosition.z > 0f) {
												car.transform.position = new Vector3 (10f, offsetY, 2.5f);
										}
										if (newPosition.z <= 0f && newPosition.z > -5f) {
												car.transform.position = new Vector3 (10f, offsetY, -2.5f);
										} 
										if (newPosition.z <= -5f && newPosition.z > -10f) {
												car.transform.position = new Vector3 (10f, offsetY, -7.5f);
										}
										if (newPosition.z <= -10f && newPosition.z > -15f) {
												car.transform.position = new Vector3 (10f, offsetY, -12.5f);
										}
										if (newPosition.z <= -15f && newPosition.z >= -20f) {
												car.transform.position = new Vector3 (10f, offsetY, -17.5f);
										}*/
					if(startPower > 100){startPower = 100;}
					carleft.GetComponent<CarMove> ().speed = 4 + startPower/10f ;		
					
					
					//hold time

					holdTime = 0f;
					startPower = 0;
					carSlider.value = startPower;
				}
				
			}
			}
			
			//
			
			
		} 



		// make sure that currentTime doesn't grow too big
		if (currentTime > 100f) {
			currentTime = carRate;
		}
	}// end of update
}
