using UnityEngine;
using System.Collections;

public class TankMove : MonoBehaviour {

	
	public static GameObject plane;// = GameObject.Find("Plane");
	public float speed = 4f;
	public AudioClip crash;
	//bool collided;
	
	// Use this for initialization
	void Start ()
	{
		plane = GameObject.Find ("Plane");
		//collided = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		Vector3 pos = transform.position;
		pos.z += speed * Time.deltaTime;
		transform.position = pos;

		
		if (transform.position.z > 20f) {
			Destroy (this.gameObject); 			
		}
		
		/*if (collided) {
			if (Time.fixedTime % .5 < .2) {
				renderer.enabled = false;
			} else {
				renderer.enabled = true;
			}
		}*/
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "Zombie") {
			AudioSource.PlayClipAtPoint (crash, collider.transform.position, 1f);
			
			ZombieMove zmScript = other.GetComponent<ZombieMove> ();
			zmScript.afterCollide ();
			other.animation.CrossFade ("Dead", 0.2f);
			
			//collided = true;
			//InvokeRepeating ("CarBlink", 0f, 1f);
			Destroy (other.gameObject, 1.3f);   
			//yield return new WaitForSeconds (1f);
			
			ScoreBoard.DestoyOneZombie ();
			
			//print(ScoreBoard.CurrentScore());
		}
	}

}
