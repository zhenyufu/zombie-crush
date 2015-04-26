using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {
	
	public static int poolSize = 3;// amount of object pools
	public List<GameObject>[] pools = new List<GameObject>[poolSize];
	
	public GameObject[] prefabArray = new GameObject[poolSize];
	public int[] prefabAmount = new int[poolSize]; //amount to create of each object
	
	
	
	// Use this for initialization
	void Start () {
		
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
	
	public GameObject takeOut(string name){
		int i = getPosition (name);
		
		if(pools[i].Count > 0){
			GameObject temp = pools[i][0];
			pools[i].RemoveAt(0);
			temp.SetActive(true);
			return temp;	
		} 
		else{
			GameObject temp = Instantiate(prefabArray[i]) as GameObject;
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
