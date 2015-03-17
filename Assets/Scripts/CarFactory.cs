﻿using UnityEngine;
using System.Collections;

public class CarFactory : MonoBehaviour {


	public GameObject carPrefab;
	public float z;

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
				//car.transform.position=new Vector3(10f, 0f, newPosition.z);
				if(newPosition.z<=20f && newPosition.z>10f){
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
				}
			}
		}
	}
}
