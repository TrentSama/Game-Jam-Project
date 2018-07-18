using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

	public Text nameText;
	public Text dialogText;
	public Animator dialogBox;
	public Animator portrait;

	public bool active;
	private Queue<string> sentences;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		active = false;
		dialogBox.SetBool ("Active", false);
	}
	
	public void StartDialog (Dialog dialog) {
		nameText.text = dialog.name;
		if (dialog.name == "Protag") {
			portrait.SetInteger ("portrait", 0);
		} else if (dialog.name == "FishBoi") {
			portrait.SetInteger ("portrait", 1);
		}
		sentences.Clear ();

		foreach (string sentence in dialog.sentences) {
			sentences.Enqueue (sentence);
		}
		DisplayNextSentence ();

	}

	public void DisplayNextSentence () {
		if (sentences.Count == 0) {
			EndDialog ();
			return;
		}
		dialogBox.SetBool ("Active", true);
		active = true;

		string sentence = sentences.Dequeue ();
		StopAllCoroutines ();
		StartCoroutine (TypeSentence (sentence));
	}

	IEnumerator TypeSentence (string sentence) {
		dialogText.text = "";
		foreach (char letter in sentence.ToCharArray()) {
			dialogText.text += letter;
			yield return null;
		}
	}

	void EndDialog() {
		Debug.Log ("End of convo");
		dialogBox.SetBool ("Active", false);
		active = false;
	}
}
