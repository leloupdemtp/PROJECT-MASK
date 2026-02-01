using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class MaskGeneration : MonoBehaviour
{
public Image _rendererTop;
    
[SerializeField]
private List<Sprite> _maskTop;

public int MaskTopCount;

public Image _rendererMiddle;

[SerializeField]
private List<Sprite> _maskMiddle;

public int MaskMiddleCount;

public Image _rendererBottom;

[SerializeField]
private List<Sprite> _maskBottom;

public int MaskBottomCount;


private void Start()
{
    GenerateMask();
}

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
