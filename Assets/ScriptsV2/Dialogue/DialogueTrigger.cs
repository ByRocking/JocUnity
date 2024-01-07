using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Kevin"))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
