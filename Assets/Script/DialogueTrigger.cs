using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public DialogueManager dialogueReference;
    public Dialogue dialogue;

    /// <summary>
    /// Setup and start the dialague.
    /// </summary>
    public void TriggerDialogue()
    {
        dialogueReference.SetUpDialogue(dialogue);
        dialogueReference.StartDialogue();
        //Destroy(gameObject);
    }
}
