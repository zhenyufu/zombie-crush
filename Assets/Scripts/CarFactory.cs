using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CarFactory : MonoBehaviour
{
	
	private ObjectPool objectPool;
	public float z;
	public  float carRate = 1f;
	public float tankRate = 1f;
	private float currentTime = 0f;  // interval 
	private float offsetY = 1.2f;
	
	// Use this for initialization
	private int startPower = 0;
	private float holdTime;
	public Slider carSlider;
	
	void Start ()
	{
		objectPool = GameObject.Find ("MainCamera").GetComponent<ObjectPool> (); 
	}
	
	
	// Update is called once per frame
	
	void Update ()
	{
		if ((ScoreBoard.CurrentFuel () <= 0) && GameObject.FindGameObjectWithTag ("Car") == null && (GameObject.FindGameObjectWithTag ("Tank")) == null) {
			PostScores ("dummy", ScoreBoard.CurrentScore ());
			ScoreBoard.reload ();
			Application.LoadLevel ("WinScene");
		}
		
		currentTime += Time.deltaTime;
		
		if (Input.touchCount > 0) {
			
			Touch touch = Input.GetTouch (0);
			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled) {
				holdTime += Time.deltaTime;
				if (holdTime > 0.01f) {
					startPower += 2;
					carSlider.value = startPower;
					holdTime = 0f;
				}
				
			}
			
			if (touch.phase == TouchPhase.Ended) {
				RaycastHit hit2;
				Ray ray2 = Camera.main.ScreenPointToRay (touch.position);
				if (Physics.Raycast (ray2, out hit2)) {
					if (hit2.transform.gameObject.tag == "TankUI") {
						Camera.main.GetComponent<Tankfactory> ().fireTank ();
					} else if (Camera.main.GetComponent<Tankfactory> ().checkClear ()) {
						if (currentTime >= carRate && ScoreBoard.CurrentFuel () > 0) {
							currentTime = 0;
							ScoreBoard.fire ();
							Vector3 newPosition = hit2.point;
							GameObject carleft = objectPool.takeOut ("Car");
							
							if (newPosition.z <= 20f && newPosition.z > 10f || newPosition.z >= - 20f && newPosition.z < - 10f) {
								offsetY = 1.7f;
							}
							if (newPosition.z <= 20f && newPosition.z > 15f) {
								carleft.transform.position = new Vector3 (10f, offsetY, 17.5f);
							}
							if (newPosition.z <= 15f && newPosition.z > 10f) {
								carleft.transform.position = new Vector3 (10f, offsetY, 12.5f);
							}
							if (newPosition.z <= 10f && newPosition.z > 5f) {
								carleft.transform.position = new Vector3 (10f, offsetY, 7.5f);
							}
							if (newPosition.z <= 5f && newPosition.z > 0f) {
								carleft.transform.position = new Vector3 (10f, offsetY, 2.5f);
							}
							if (newPosition.z <= 0f && newPosition.z > -5f) {
								carleft.transform.position = new Vector3 (10f, offsetY, -2.5f);
							}
							if (newPosition.z <= -5f && newPosition.z > -10f) {
								carleft.transform.position = new Vector3 (10f, offsetY, -7.5f);
							}
							if (newPosition.z <= -10f && newPosition.z > -15f) {
								carleft.transform.position = new Vector3 (10f, offsetY, -12.5f);
							}				
							if (newPosition.z <= -15f && newPosition.z >= -20f) {
								carleft.transform.position = new Vector3 (10f, offsetY, -17.5f);
							}				
							
							if (startPower > 100) {
								startPower = 100;
							}
							carleft.GetComponent<CarMove> ().speed = 4 + startPower / 10f;		
							
							holdTime = 0f;
							startPower = 0;
							carSlider.value = startPower;
						}
						
					}
				}
			}
			
			
			
		} else if (Input.GetMouseButton (0)) {
			holdTime += Time.deltaTime;
			if (holdTime > 0.01f) {
				startPower += 2;
				carSlider.value = startPower;
				holdTime = 0f;
			}
			
			
			
			
			
			
		} 
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.transform.gameObject.tag == "TankUI") {
					Camera.main.GetComponent<Tankfactory> ().fireTank ();
				} else if (Camera.main.GetComponent<Tankfactory> ().checkClear ()) {
					if (currentTime >= carRate && ScoreBoard.CurrentFuel () > 0) {
						currentTime = 0;
						ScoreBoard.fire ();
						Vector3 newPosition = hit.point;
						GameObject carleft = objectPool.takeOut ("Car");
						
						if (newPosition.z <= 20f && newPosition.z > 10f || newPosition.z >= - 20f && newPosition.z < - 10f) {
							offsetY = 1.7f;
						}
						if (newPosition.z <= 20f && newPosition.z > 15f) {
							carleft.transform.position = new Vector3 (10f, offsetY, 17.5f);
						}
						if (newPosition.z <= 15f && newPosition.z > 10f) {
							carleft.transform.position = new Vector3 (10f, offsetY, 12.5f);
						}
						if (newPosition.z <= 10f && newPosition.z > 5f) {
							carleft.transform.position = new Vector3 (10f, offsetY, 7.5f);
						}
						if (newPosition.z <= 5f && newPosition.z > 0f) {
							carleft.transform.position = new Vector3 (10f, offsetY, 2.5f);
						}
						if (newPosition.z <= 0f && newPosition.z > -5f) {
							carleft.transform.position = new Vector3 (10f, offsetY, -2.5f);
						}
						
						if (newPosition.z <= -5f && newPosition.z > -10f) {
							carleft.transform.position = new Vector3 (10f, offsetY, -7.5f);
						}
						if (newPosition.z <= -10f && newPosition.z > -15f) {
							carleft.transform.position = new Vector3 (10f, offsetY, -12.5f);
						}			
						if (newPosition.z <= -15f && newPosition.z >= -20f) {
							//GameObject carleft = Instantiate (carPrefab) as GameObject;
							carleft.transform.position = new Vector3 (10f, offsetY, -17.5f);
						}
						if (startPower > 100) {
							startPower = 100;
						}
						carleft.GetComponent<CarMove> ().speed = 4 + startPower / 10f;		
						
						
						//hold time
						
						holdTime = 0f;
						startPower = 0;
						carSlider.value = startPower;
					}
					
				}
			}			
			
		} 
		
		
		
		// make sure that currentTime doesn't grow too big
		if (currentTime > 100f) {
			currentTime = carRate;
		}
	}// end of update
	
	public void PostScores (string levelName, int scoreToBePassed)
	{
		new GameSparks.Api.Requests.LogEventRequest_pScore ().Set_score (scoreToBePassed).Send ((response) =>
		                                                                                        {
			if (response.HasErrors) {
				Debug.Log ("Update gamespark score Failed");
			} else {
				Debug.Log ("Update gamespark score Successful");
			}
		});
	}
	
}
