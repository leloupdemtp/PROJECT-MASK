using System.Collections.Generic;
using UnityEngine;

public class RandomDialogueAssigner : MonoBehaviour
{
    public static RandomDialogueAssigner Instance;

    [Header("Liste de dialogues normaux")]
    public List<string> normalDialogues;

    [Header("Référence du tueur")]
    public KillerMaskGeneration killerMask;

    // Indices restants à distribuer aux PNJ
    private List<string> remainingClues = new List<string>();

    // Liste globale pour l'UI des indices collectés
    public List<string> collectedClues = new List<string>();

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    // Appelé au moment où un PNJ est instancié
    public string AssignDialogueToPNJ()
    {
        // Si les indices du tueur n'ont pas encore été copiés
        if (remainingClues.Count == 0 && killerMask != null)
            remainingClues = new List<string>(killerMask.killerClues);

        string selected;

        // 50% de chance d'utiliser un indice restant
        if (remainingClues.Count > 0 && Random.value > 0.5f)
        {
            int index = Random.Range(0, remainingClues.Count);
            selected = remainingClues[index];
            remainingClues.RemoveAt(index); // unique
        }
        else
        {
            selected = normalDialogues[Random.Range(0, normalDialogues.Count)];
        }

        return selected;
    }

    // Appelé quand le joueur parle à un PNJ
    public void CollectClue(string dialogue)
    {
        if (killerMask == null) return;

        // Si le dialogue est un indice du tueur et pas encore collecté
        if (killerMask.killerClues.Contains(dialogue) && !collectedClues.Contains(dialogue))
        {
            collectedClues.Add(dialogue);
            Debug.Log($"Indice collecté : {dialogue}");
        }
    }
}