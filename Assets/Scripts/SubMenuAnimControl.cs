using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SubMenuAnimControl : MonoBehaviour {

	public Button BackButton;
	
	private Animator Anim;
	private bool On = false;
	
	// Use this for initialization
	void Awake () {
		Anim = GetComponent<Animator>();
		Anim.SetBool("FadeIn", false);
		Anim.SetBool("FadeOut", false);
		BackButton.active = false;
		FadeOut();
	}
	
	public void FadeIn() {
		if (!On) {
			Anim.SetBool("FadeOut", false);
			Anim.SetBool("FadeIn", true);
			On = true;
			BackButton.active = true;
		}
	}
	
	public void FadeOut() {
		if (On) {
			Anim.SetBool("FadeIn", false);
			Anim.SetBool("FadeOut", true);
			On = false;
			Invoke("DelayInacitveBackButton",1.0f);
		}
	}

	public void DelayInacitveBackButton() {
		BackButton.active = false;
	}
}
