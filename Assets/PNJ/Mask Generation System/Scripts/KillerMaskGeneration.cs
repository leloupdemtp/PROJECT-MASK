using System.Collections.Generic;
using UnityEngine;

public class KillerMaskGeneration : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private MaskGeneration killerMask;

    [Header("Generated Clues")]
    public List<string> killerClues = new();

    private void Awake()
    {
        GenerateKillerMask();
    }

    [ContextMenu("Generate Killer Mask")]
    public void GenerateKillerMask()
    {
        if (killerMask == null)
        {
            Debug.LogError("KillerMaskGeneration : MaskGeneration reference is missing");
            return;
        }

        killerClues.Clear();

        // Génération du masque du tueur à partir des indices
        killerClues = killerMask.GenerateWithClues();
    }
}