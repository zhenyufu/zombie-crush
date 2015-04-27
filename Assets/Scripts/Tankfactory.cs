using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Tankfactory : MonoBehaviour {

	public Slider tankSlider;
	private int currentInt = 0;
	private bool tankReady = false;
	public GameObject tankDisplay;
	public GameObject tankPrefab;
	private float offsetY = 1.2f;
	GameObject tank1, tank2;
	// Use this for initialization
	void Start () {
		tankDisplay.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void addTank(int i){

		currentInt += i*10;
		if(currentInt >= 100){
			currentInt = 100;
			tankDisplay.SetActive (true);
			tankReady = true;
		}
		tankSlider.value = currentInt;

	}

	public void fireTank(){
		tank1 = Instantiate (tankPrefab) as GameObject;
		tank1.transform.position = new Vector3 (-4.2f, offsetY, -20f);
		
		tank2 = Instantiate (tankPrefab) as GameObject;
		tank2.transform.position = new Vector3 (4.2f, offsetY, -20f);

		tankDisplay.SetActive (false);
		tankReady = false;
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
