using UnityEngine;
using System.Collections;       
using TMPro;
using UnityEngine.InputSystem;


public class OpenDialogue : MonoBehaviour
{
    public TextMeshProUGUI Dialoguetext;

    public Canvas DialogueBox;

    public string[] Dialoguelines;

    public float Textspeed;

    private int _index;

    public bool _isActive;


    private void Start()
    {
        DialogueBox.enabled = false;
    }
    
    
    [ContextMenu("Start Dialogue")]
    public void StartDialogue()
    {
        if (_isActive == false)
        {
            _isActive = true;
            Debug.Log("je fait qqc");
            DialogueBox.enabled = true;
            _index = 0;
            Dialoguetext.text = string.Empty;
            StartCoroutine(TypeLine());
        }
      
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in Dialoguelines[_index].ToCharArray())
        {
            Dialoguetext.text += c;
            yield return new WaitForSeconds(-Textspeed);
        }
        yield return new WaitForSeconds(0.1f);
        _isActive = false;
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
    public void SetDialogue(string text)
    {
        if (Dialoguetext != null)
        {
            // Remplace tout le tableau par ce dialogue unique
            Dialoguelines = new string[] { text };
            _index = 0;
            Dialoguetext.text = string.Empty; // reset affichage
        }
        else
        {
            Debug.LogWarning("OpenDialogue : Dialoguetext non assigné sur " + gameObject.name);
        }
    }

    public void StopDialogue()
    {
        if (Dialoguetext.text == Dialoguelines[_index])
        {
            // Collecte l'indice si c'est un dialogue du tueur
            RandomDialogueAssigner.Instance.CollectClue(Dialoguelines[_index]);

            NextLine();
        }
        else
        {
            StopAllCoroutines();
            Dialoguetext.text = Dialoguelines[_index];
        }
    }

}

