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

    private bool _isOpen = false;

    private bool _isTyping;



    private void Start()
    {
        DialogueBox.enabled = false;
        _isOpen = false;
    }

    private void Update()
    {
        if (!_isOpen) return;

        if (Keyboard.current.enterKey.wasPressedThisFrame)
        {
            if (_isTyping)
            {
                // 1er appui : skip animation
                StopAllCoroutines();
                Dialoguetext.text = Dialoguelines[_index];
                _isTyping = false;
                _isActive = false;
             
            }
            else
            {
                // 2e appui : ligne suivante / fermeture
                StopDialogue();
            }
        }
    }




    [ContextMenu("Start Dialogue")]
    public void StartDialogue()
    {
        if (_isOpen) return;

        _isOpen = true;
        _isActive = true;
        _isTyping = false;
        DialogueBox.enabled = true;
        _index = 0;

        StopAllCoroutines();
        StartCoroutine(TypeLine());
    }


    private IEnumerator TypeLine()
    {
        _isTyping = true;
        Dialoguetext.text = string.Empty;

        foreach (char c in Dialoguelines[_index].ToCharArray())
        {
            Dialoguetext.text += c;
            yield return new WaitForSeconds(Textspeed);
        }

        _isTyping = false;
    }


    private void NextLine()
    {
        _index++;

        // Si toutes les lignes ont été lues, ferme la boîte de dialogue
        if (_index >= Dialoguelines.Length)
        {
            DialogueBox.enabled = false;
            _isActive = false;
            _index = 0; // réinitialiser pour pouvoir reparler au PNJ plus tard
            return;
        }

        // Sinon, passe à la ligne suivante
        Dialoguetext.text = string.Empty;
        StartCoroutine(TypeLine());
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
        // Si le texte est affiché entièrement
        if (Dialoguetext.text == Dialoguelines[_index])
        {
            // Collecte l'indice si nécessaire
            if (RandomDialogueAssigner.Instance != null)
            {
                RandomDialogueAssigner.Instance.CollectClue(Dialoguelines[_index]);
            }

            // Passe à la ligne suivante ou ferme si c'est la dernière
            _index++;
            if (_index >= Dialoguelines.Length)
            {
                DialogueBox.enabled = false;
                _isOpen = false;
                _isActive = false;
                _index = 0;
                Dialoguetext.text = string.Empty;
            }
            else
            {
                Dialoguetext.text = string.Empty;
                StartCoroutine(TypeLine());
            }
        }
        else
        {
            // Texte pas encore fini → afficher tout de suite
            StopAllCoroutines();
            Dialoguetext.text = Dialoguelines[_index];
        }
    }

}