using UnityEngine;
using System.Collections;

public class ZombieFactory : MonoBehaviour {

	public static GameObject plane;
	public static float start = 5f; 
	public static float width = 5f;

	public GameObject zombiePrefab;
	public float time = 1f;
	// Use this for initialization
	void Start () {
		InvokeRepeating("makeZombie", 2f, time);
		plane = GameObject.Find("Plane");
		start = start * plane.transform.localScale.z;
		width = width * plane.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	void makeZombie(){
		GameObject zombie = Instantiate( zombiePrefab ) as GameObject;

		zombie.transform.position = new Vector3(Random.Range(-width, width),1,-start);

	}

}
