using UnityEngine;
using System.Collections;       
using System.Collections.Generic;
using TMPro;
using UnityEngine.InputSystem;

public class OpenDialogue : MonoBehaviour
{
    public TextMeshProUGUI Dialoguetext;

    public Canvas DialogueBox;

    public string[] Dialoguelines;

    public float Textspeed;

    private int _index;


    private void Start()
    {
        DialogueBox.enabled = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Dialoguetext.text == Dialoguelines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                Dialoguetext.text = Dialoguelines[_index];
            }
        }
    }
    [ContextMenu("Start Dialogue")]
    public void StartDialogue()
    {
        DialogueBox.enabled = true;
        _index = 0;
        Dialoguetext.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in Dialoguelines[_index].ToCharArray())
        {
            Dialoguetext.text += c;
            yield return new WaitForSeconds(-Textspeed);
        }
    }

    private void NextLine()
    {
        if (_index < Dialoguelines.Length - 1)
        {
            _index++;
            Dialoguetext.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            DialogueBox.enabled = false;
        }
    }
}

