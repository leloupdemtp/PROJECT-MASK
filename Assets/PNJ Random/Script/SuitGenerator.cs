using System.Collections.Generic;
using UnityEngine;

public class SuitGenerator : MonoBehaviour
{
    public SpriteRenderer _rendererTop;

    [SerializeField]
    private List<Sprite> _suitTop;

    public int SuitTopCount;

    public SpriteRenderer _rendererMiddle;

    [SerializeField]
    private List<Sprite> _suitMiddle;

    public int SuitMiddleCount;

    public SpriteRenderer _rendererBottom;

    [SerializeField]
    private List<Sprite> _suitBottom;

    public int SuitBottomCount;


    private void GenerateSuit()
    {
        _rendererTop.sprite = _suitTop[SuitTopCount];
        _rendererMiddle.sprite = _suitMiddle[SuitMiddleCount];
        _rendererBottom.sprite = _suitBottom[SuitBottomCount];
    }

    [ContextMenu("Generate Suit")]
    public void RandomizeSuit()
    {
        SuitTopCount = Random.Range(0, _suitTop.Count);
        SuitMiddleCount = Random.Range(0, _suitMiddle.Count);
        SuitBottomCount = Random.Range(0, _suitBottom.Count);
        GenerateSuit();
    }








}