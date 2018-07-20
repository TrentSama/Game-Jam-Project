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
	private AudioSource src;

	// Use this for initialization
	void Start () {
		sentences = new Queue<string> ();
		active = false;
		dialogBox.SetBool ("Active", false);
		src = GetComponent<AudioSource> ();
	}
	
	public void StartDialog (Dialog dialog) {
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
		src.Play ();

		string sentence = sentences.Dequeue ();
		string[] line = sentence.Split (':');
		dialogText.text = "";
		nameText.text = "";

		// change portrait
		if (line [0] == "Protag") {
			portrait.SetInteger ("portrait", 0);
		} else if (line [0] == "FishBoi") {
			portrait.SetInteger ("portrait", 1);
		}
		nameText.text = line [0];

		StopAllCoroutines ();
		StartCoroutine (TypeSentence (line[1]));
	}

	IEnumerator TypeSentence (string sentence) {
		yield return null;
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
