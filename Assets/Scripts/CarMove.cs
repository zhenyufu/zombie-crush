using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour {

	public static GameObject plane;// = GameObject.Find("Plane");
	public float speed = 4f;
	public AudioClip crash;
	// Use this for initialization
	void Start () {
		plane = GameObject.Find("Plane");
	}
	
	// Update is called once per frame
	void Update () {
		
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;


		if ( transform.position.x < -10f ) {
			Destroy( this.gameObject ); 			
		}
		
	}


	void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Zombie"){
			AudioSource.PlayClipAtPoint(crash, collider.transform.position, 1f);

			Destroy(other.gameObject);
			Destroy( this.gameObject );
			ScoreBoard.DestoyOneZombie();
			print(ScoreBoard.CurrentScore());
		}
	}





}
