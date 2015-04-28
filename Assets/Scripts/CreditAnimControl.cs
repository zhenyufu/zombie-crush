using UnityEngine;
using System.Collections;

public class CreditAnimControl : MonoBehaviour {
	
	private Animator TAnim;
	private bool TOn = false;
	
	// Use this for initialization
	void Awake () {
		TAnim = GetComponent<Animator>();
		TAnim.SetBool("CFadeIn", false);
		TAnim.SetBool("CFadeOut", false);
		TFadeOut();
	}
	
	void start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void TFadeIn() {
		if (!TOn) {
			TAnim.SetBool("CFadeOut", false);
			TAnim.SetBool("CFadeIn", true);
			TOn = true;
		}
	}
	
	public void TFadeOut() {
		if (TOn) {
			TAnim.SetBool("CFadeIn", false);
			TAnim.SetBool("CFadeOut", true);
			TOn = false;
		}
	}
}
