using UnityEngine;
using System.Collections;

public class TutorialAnimControl : MonoBehaviour {
	
	private Animator TAnim;
	private bool TOn = false;
	
	// Use this for initialization
	void Awake () {
		TAnim = GetComponent<Animator>();
		TAnim.SetBool("TFadeIn", false);
		TAnim.SetBool("TFadeOut", false);
		TFadeOut();
	}
	
	void start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void TFadeIn() {
		if (!TOn) {
			TAnim.SetBool("TFadeOut", false);
			TAnim.SetBool("TFadeIn", true);
			TOn = true;
		}
	}
	
	public void TFadeOut() {
		if (TOn) {
			TAnim.SetBool("TFadeIn", false);
			TAnim.SetBool("TFadeOut", true);
			TOn = false;
		}
	}
}