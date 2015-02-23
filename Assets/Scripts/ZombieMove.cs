using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour {

	public static float bottom = 5f;
	public float speed = 2f;
	// Use this for initialization
	void Start () {
		speed = Random.Range (0.0f, 4.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 pos = transform.position;
		pos.z += speed * Time.deltaTime;
		transform.position = pos;

		if ( transform.position.z > bottom ) {
			Destroy( this.gameObject ); 			
		}




	}
}
