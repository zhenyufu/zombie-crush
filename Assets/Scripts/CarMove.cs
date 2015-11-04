using UnityEngine;
using System.Collections;

public class CarMove : MonoBehaviour
{
	private ObjectPool objectPool;
/*
	public GameObject bang;
	public GameObject crispy;
	public GameObject blast;
	public GameObject alright;
	public GameObject sweet;*/
	public static GameObject plane;// = GameObject.Find("Plane");
	public float speed = 4f;
	public AudioClip crash;
	public int comboCounter=0;

	// Use this for initialization
	void Start ()
	{
		objectPool = GameObject.Find("MainCamera").GetComponent<ObjectPool>(); 
		plane = GameObject.Find ("Plane");
	}

	void OnEnable(){
		comboCounter=0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 pos = transform.position;
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;


		if (transform.position.x < -13f) {
			objectPool.putIn(this.gameObject); 			
		}
		/*
		if (collided) {
			if (Time.fixedTime % .5 < .2) {
				this.renderer.enabled = false;
			} else {
				this.renderer.enabled = true;
			}
		}*/
	}


	void OnCollisionEnter(Collision collision) {

		if (collision.gameObject.tag == "Zombie" ) {
  
			ZombieMove zmScript = collision.gameObject.GetComponent<ZombieMove> ();
			Tankfactory tankFactory = Camera.main.GetComponent<Tankfactory> ();

			//
			if(!zmScript.getCollided()){
				GameObject bangIns = objectPool.takeOut("bang");

				comboCounter++;
			if(comboCounter==1){
					GameObject crispy1 = objectPool.takeOut("Crispy");
					objectPool.putIn(crispy1,0.6f);
				}
			else if(comboCounter==2){
					GameObject blast1 = objectPool.takeOut("Blast");
					objectPool.putIn(blast1,0.6f);
				}
			else if(comboCounter==3){
					GameObject alright1 = objectPool.takeOut("Alright");
					objectPool.putIn(alright1,0.6f);
				}
			else{
					GameObject sweet1 = objectPool.takeOut("Sweet");
					objectPool.putIn(sweet1,0.6f);
				}

				tankFactory.addTank(comboCounter); 
			bangIns.transform.position = new Vector3 (collision.transform.position.x, 5f, collision.transform.position.z);
				//Destroy(bangIns,0.4f);
				objectPool.putIn(bangIns,0.6f);
				//set constraint

				objectPool.putIn(collision.gameObject, 1.3f);
			AudioSource.PlayClipAtPoint (crash, GetComponent<Collider>().transform.position, 1f);
			//Destroy(this.gameObject,0.5f);
			objectPool.putIn(this.gameObject, 0.5f);
			ScoreBoard.DestoyOneZombie ();
			}
			zmScript.afterCollide ();
		}
//		else if(collision.transform.parent.gameObject.tag == "Zombie"){
//			Destroy (collision.transform.parent.gameObject, 1.3f);   
//			ZombieMove zmScript = collision.transform.parent.gameObject.GetComponent<ZombieMove> ();
//			zmScript.afterCollide ();
//			//
//			AudioSource.PlayClipAtPoint (crash, collider.transform.position, 1f);
//			Destroy(this.gameObject,0.5f);
//			ScoreBoard.DestoyOneZombie ();
//		}


	}




//	void OnTriggerEnter (Collider other)
//	{
//		Debug.Log (other.gameObject.tag);
//		if (other.gameObject.tag == "Zombie") {
//			//disableCollider();
//			Debug.Log ("collide");
//			AudioSource.PlayClipAtPoint (crash, collider.transform.position, 1f);
//
//			//ZombieMove zmScript = other.GetComponent<ZombieMove> ();
//			//zmScript.afterCollide ();
//			//other.animation.CrossFade ("Dead", 0.2f);
//
//			//collided = true;
//			//InvokeRepeating ("CarBlink", 0f, 1f);
//			Destroy (other.gameObject, 1.3f);   
//			Destroy(this.gameObject,0.8f);
//			//yield return new WaitForSeconds (1f);
//
//			ScoreBoard.DestoyOneZombie ();
//
//			//print(ScoreBoard.CurrentScore());
//		}
//	}

	  IEnumerator CarBlink ()
	{
		GetComponent<Renderer>().enabled = false;
		yield return new WaitForSeconds (0.5f);
		GetComponent<Renderer>().enabled = true;
	}

	void disableCollider()
	{
		foreach (Collider c in GetComponents<Collider>())
		{
			c.enabled = false;
		}
	}
}
