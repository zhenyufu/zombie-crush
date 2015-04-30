using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuAnimControl : MonoBehaviour {

	public Button PlayButton;
	public Button LeaderBoardButton;
	public Button TutorialButton;
	public Button CreditButton;

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
			PlayButton.enabled = true;
			LeaderBoardButton.enabled = true;
			TutorialButton.enabled = true;
			CreditButton.enabled = true;
		}
	}

	public void MMFadeOut() {
		if (MainMenuOn) {
			MainMenuAnim.SetBool("FadeIn", false);
			MainMenuAnim.SetBool("FadeOut", true);
			MainMenuOn = false;
			PlayButton.enabled = false;
			LeaderBoardButton.enabled = false;
			TutorialButton.enabled = false;
			CreditButton.enabled = false;
		}
	}
}
