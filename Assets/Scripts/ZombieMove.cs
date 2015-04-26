using UnityEngine;
using System.Collections;

public class ZombieMove : MonoBehaviour
{
	public static GameObject plane;// = GameObject.Find("Plane");
	public float speed = 2f;
	public bool collided;
	// Use this for initialization
	void Start ()
	{
		plane = GameObject.Find ("Plane");
		collided = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!collided) {
			Vector3 pos = transform.position;
			pos.z -= speed * Time.deltaTime;
			transform.position = pos;

			if (transform.position.z < -ZombieFactory.start) {
				Destroy (this.gameObject); 
				ScoreBoard.fire ();
			}
		}
	}

	public void afterCollide() {
		if (!collided) {
						collided = true;
						rigidbody.constraints = RigidbodyConstraints.None;
				}
	}

	public bool getCollided(){
		return collided;

	}

}
