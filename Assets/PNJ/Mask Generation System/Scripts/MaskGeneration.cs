using System.Collections.Generic;
using UnityEngine;

public class MaskGeneration : MonoBehaviour
{
public SpriteRenderer _rendererTop;
    
[SerializeField]
private List<Sprite> _maskTop;

public int MaskTopCount;

public SpriteRenderer _rendererMiddle;

[SerializeField]
private List<Sprite> _maskMiddle;

public int MaskMiddleCount;

public SpriteRenderer _rendererBottom;

[SerializeField]
private List<Sprite> _maskBottom;

public int MaskBottomCount;


private void GenerateMask()
{
    _rendererTop.sprite = _maskTop[MaskTopCount];
    _rendererMiddle.sprite = _maskMiddle[MaskMiddleCount];
    _rendererBottom.sprite = _maskBottom[MaskBottomCount];
}

[ContextMenu("Generate Mask")]
public void RandomizeMask()
{
    MaskTopCount = Random.Range(0, _maskTop.Count);
    MaskMiddleCount = Random.Range(0, _maskMiddle.Count);
    MaskBottomCount = Random.Range(0, _maskBottom.Count);
    GenerateMask();
}


 



 
 
}
