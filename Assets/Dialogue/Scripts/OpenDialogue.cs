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

    private AudioSource _talkingAudioSource;


    private void Start()
    {
        DialogueBox.enabled = false;
        _talkingAudioSource = transform.GetComponent<AudioSource>();
    }




    public void StopDialogue()
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
            _talkingAudioSource.Play();
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
}

