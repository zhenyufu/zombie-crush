using UnityEngine;
using System.Collections;

public class Spinning : MonoBehaviour {

	public float axis; // 0 for x
	private float speed = 80f;
	private Vector3 turnVec;
	// Use this for initialization
	void Start () {

		if (axis == 0f) { turnVec = new Vector3 (speed,0,0);}
		else if (axis == 1f){turnVec = new Vector3 (0,speed,0);}
		else if(axis == 2f){turnVec = new Vector3 (0,0,speed);}
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (turnVec * Time.deltaTime);
	}
}
