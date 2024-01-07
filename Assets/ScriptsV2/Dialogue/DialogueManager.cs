using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;
    public AudioSource typeSound;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        typeSound = GetComponent<AudioSource>();
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        typeSound.Play();
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(.02f);
        }
        typeSound.Stop();
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
}
