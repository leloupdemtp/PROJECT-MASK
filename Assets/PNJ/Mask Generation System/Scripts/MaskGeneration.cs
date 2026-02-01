using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MaskGeneration : MonoBehaviour
{
    [Header("Top")]
    public Image rendererTop;
    public List<MaskClue> topClues = new();

    [Header("Middle")]
    public Image rendererMiddle;
    public List<MaskClue> middleClues = new();

    [Header("Bottom")]
    public Image rendererBottom;
    public List<MaskClue> bottomClues = new();
    
    public List<string> GenerateWithClues()
    {
        List<string> clues = new();

        MaskClue top = PickRandom(topClues);
        MaskClue middle = PickRandom(middleClues);
        MaskClue bottom = PickRandom(bottomClues);

        ApplyMask(top.sprite, middle.sprite, bottom.sprite);

        clues.Add(top.clue);
        clues.Add(middle.clue);
        clues.Add(bottom.clue);

        return clues;
    }
    
    public void GenerateRandom()
    {
        MaskClue top = PickRandom(topClues);
        MaskClue middle = PickRandom(middleClues);
        MaskClue bottom = PickRandom(bottomClues);

        ApplyMask(top.sprite, middle.sprite, bottom.sprite);
    }

    private MaskClue PickRandom(List<MaskClue> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    private void ApplyMask(Sprite top, Sprite middle, Sprite bottom)
    {
        rendererTop.sprite = top;
        rendererMiddle.sprite = middle;
        rendererBottom.sprite = bottom;
    }
}
