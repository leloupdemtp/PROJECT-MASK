using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class KillerMaskGeneration : MonoBehaviour
{
    [SerializeField]
    private MaskGeneration _maskGeneration;
    
    [SerializeField]
    private List<MaskGeneration> _otherMaskGeneration = new List<MaskGeneration>();

    void Start()
    {
        GenerateKillerMask();
    }

    [ContextMenu("GenerateKillerMask")]
    void GenerateKillerMask()
    {
        for (int i = 0; i < _otherMaskGeneration.Count; i++)
        {
            VerifyMaskGeneration(i); 
        }
        _maskGeneration.RandomizeMask();
    }
    private void VerifyMaskGeneration(int i)
    {
        if (_otherMaskGeneration[i]._rendererTop.sprite == _maskGeneration._rendererTop.sprite &&
            _otherMaskGeneration[i]._rendererBottom.sprite == _maskGeneration._rendererBottom.sprite &&
            _otherMaskGeneration[i]._rendererMiddle.sprite == _maskGeneration._rendererMiddle.sprite)
        {
            _otherMaskGeneration[i].RandomizeMask();
            VerifyMaskGeneration(i);
        }
    }
    
    
    
}
