using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tankfactory : MonoBehaviour {

	public Slider tankSlider;
	private int currentInt = 0;
	//private bool tankReady = false;
	public GameObject tankDisplay;
	public GameObject tankPrefab;
	private float offsetY = 1.2f;
	private ObjectPool objectPool;
	private GameObject tank1,tank2; 
	// Use this for initialization
	void Start () {
		objectPool = GameObject.Find("MainCamera").GetComponent<ObjectPool>(); 

		tankDisplay.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void addTank(int i){

		currentInt += i*4;
		if(currentInt >= 100){
			currentInt = 100;
			tankDisplay.SetActive (true);
			//tankReady = true;
		}
		tankSlider.value = currentInt;

	}

	public void fireTank(){
		tank1 = objectPool.takeOut ("Tank");
		tank1.transform.position = new Vector3 (-4.2f, offsetY, -25f);
		
		tank2 = objectPool.takeOut ("Tank");
		tank2.transform.position = new Vector3 (4.2f, offsetY, -25f);

		tankDisplay.SetActive (false);
		//tankReady = false;
		currentInt = 0;
		tankSlider.value = currentInt;
	}


	public bool checkClear(){
		if (tank1 == null) {
			return true;		
		}
		return false;
	}


}
