using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	//0-5 zombie 1 -6
	//6-7 car tank
	//8-12 bangcombo signs
	public static int poolSize = 13;// amount of object pools
	public List<GameObject>[] pools = new List<GameObject>[poolSize];
	
	public GameObject[] prefabArray = new GameObject[poolSize];
	public int[] prefabAmount = new int[poolSize]; //amount to create of each object
	
	
	
	// Use this for initialization
	void Awake () {
		
		for(int i = 0; i < poolSize; i++){
			pools[i] = new List<GameObject>(); 
			for ( int j = 0; j < prefabAmount[i] ; j++){
				GameObject temp = Instantiate(prefabArray[i]) as GameObject;
				temp.name = prefabArray[i].name;
				putIn(temp);
			}
		}
	}
	
	
	public void putIn(GameObject obj){
		obj.SetActive (false);
		obj.transform.parent = this.transform;
		pools[getPosition(obj.name)].Add(obj);
	}

	public void putIn(GameObject obj, float f){
		StartCoroutine(myWait (obj, f));

	}

	IEnumerator myWait(GameObject obj, float f) {
		//print(Time.time);
		yield return new WaitForSeconds(f);
		//print(Time.time);
		//print(obj.name);
		//zombieCheck (obj);
		obj.SetActive (false);
		obj.transform.parent = this.transform;
		pools[getPosition(obj.name)].Add(obj);
	}

	/*
	private void zombieCheck(GameObject obj){
		if(obj.name.Substring(0, 1) == "Z"){

			obj.rigidbody.constraints =  RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;

		}
	
	}*/

	public GameObject takeOut(string name){
		int i = getPosition (name);
		//print (name);
		if(pools[i].Count > 0){
			GameObject temp = pools[i][0];
			pools[i].RemoveAt(0);
			temp.SetActive(true);
			return temp;	
		} 
		else{
			GameObject temp = Instantiate(prefabArray[i]) as GameObject;
			temp.transform.parent = this.transform.parent;
			temp.name = prefabArray[i].name;
			return temp;
		}
		
	}
	
	
	
	private int getPosition(string name){
		for (int i = 0; i < prefabArray.Length; i++) {
			if(prefabArray[i].name == name){ return i;}
		}
		return -1;
	}
	
	
}
