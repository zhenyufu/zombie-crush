using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {


	public GameObject carPrefab;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 if(Input.GetMouseButtonDown(0)){
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				Vector3 newPosition = hit.point;
				GameObject car=Instantiate( carPrefab ) as GameObject;
				car.transform.position=new Vector3(5f, 0f, newPosition.z);
			}
		}
	}
}
