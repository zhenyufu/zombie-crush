using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {

	public static GameObject plane;// = GameObject.Find("Plane");
	public float speed = 2f;
	// Use this for initialization
	void Start () {
		speed = Random.Range (1.0f, 4.0f);
		plane = GameObject.Find("Plane");
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;
		
		
	}
}
