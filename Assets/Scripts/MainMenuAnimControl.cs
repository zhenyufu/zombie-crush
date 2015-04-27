using UnityEngine;
using System.Collections;

public class MainMenuAnimControl : MonoBehaviour {

	private Animator MainMenuAnim;
	private bool MainMenuOn = false;

	// Use this for initialization
	void Awake () {
		MainMenuAnim = GetComponent<Animator>();
		MainMenuAnim.SetBool("FadeIn", false);
		MainMenuAnim.SetBool("FadeOut", false);
		MMFadeIn();
	}

	void start() {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void MMFadeIn() {
		if (!MainMenuOn) {
			MainMenuAnim.SetBool("FadeOut", false);
			MainMenuAnim.SetBool("FadeIn", true);
			MainMenuOn = true;
		}
	}

	public void MMFadeOut() {
		if (MainMenuOn) {
			MainMenuAnim.SetBool("FadeIn", false);
			MainMenuAnim.SetBool("FadeOut", true);
			MainMenuOn = false;
		}
	}
}
