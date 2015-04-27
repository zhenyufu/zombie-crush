using UnityEngine;
using System.Collections;

public class LeaderBoardAnimControl : MonoBehaviour {
	
	private Animator LLAnim;
	private bool LLOn = false;
	
	// Use this for initialization
	void Awake () {
		LLAnim = GetComponent<Animator>();
		LLAnim.SetBool("LFadeIn", false);
		LLAnim.SetBool("LFadeOut", false);
		LLFadeOut();
	}
	
	void start() {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void LLFadeIn() {
		if (!LLOn) {
			LLAnim.SetBool("LFadeOut", false);
			LLAnim.SetBool("LFadeIn", true);
			LLOn = true;
		}
	}
	
	public void LLFadeOut() {
		if (LLOn) {
			LLAnim.SetBool("LFadeIn", false);
			LLAnim.SetBool("LFadeOut", true);
			LLOn = false;
		}
	}
}