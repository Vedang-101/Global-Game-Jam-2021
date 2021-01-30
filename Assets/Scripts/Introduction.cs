using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Introduction : MonoBehaviour
{
    public float speed = 0.1f;
    public Text textField;
    [HideInInspector]
    public Queue<string> sentences;

    [TextArea(3, 10)]
    public string[] dialogue_sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        sentences.Clear();

        foreach (string sentence in dialogue_sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            GotIntructions();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        textField.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            textField.text += letter;
            yield return new WaitForSeconds(speed);
        }
    }

    public void GotIntructions()
    {
        this.gameObject.SetActive(false);
        FindObjectOfType<PlayerController>().canMove = true;
    }
}
