using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
public class DialogueManager : MonoBehaviour {
	public float displayLetterTime = 0.5f;

    [SerializeField] private Text _dialogueText;
	private Dialogue _dialogue;
	public event Action OnEndDialogue;

	bool isTalking;

	/// <summary>
	/// setup Dialogue
	/// </summary>
	/// <param name="dialogue"></param>
	public void SetUpDialogue(Dialogue dialogue)
    {
		_dialogue = dialogue;
    }

	/// I will call this method via animation, so the text will not appear before the animation's end.
	public void StartDialogue ()
	{
		DisplayNextSentence();
	}

	/// <summary>
	/// 
	/// </summary>
	public void DisplayNextSentence ()
	{
		if (_dialogue.isEnd() && !isTalking)
		{
			EndDialogue();
			return;
		}

		StopAllCoroutines();
		if (!isTalking)
        {
			StartCoroutine(TypeSentence(_dialogue.Next()));
        }
        else
        {
			isTalking = false;
			_dialogueText.text = _dialogue.Current();
        }
	}

	IEnumerator TypeSentence (string sentence)
	{
		_dialogueText.text = "";
		isTalking = true;
		foreach (char letter in sentence.ToCharArray())
		{
			_dialogueText.text += letter;
			yield return new WaitForSeconds(displayLetterTime);
		}
		isTalking = false;
	}

	void EndDialogue()
	{
		_dialogueText.text = "";
        OnEndDialogue?.Invoke();
	}
}
