using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public GameObject zombiePrefab;
	public float time = 1f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("makeZombie", 2f, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void makeZombie(){
		GameObject zombie = Instantiate( zombiePrefab ) as GameObject;

		zombie.transform.position = new Vector3(Random.Range(-5.0f, 5.0f),1,-5);

	}

}
