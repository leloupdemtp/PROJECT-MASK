using System;
using System.Collections.Generic;
using UnityEngine;

public class KillerMaskGeneration : MonoBehaviour
{
    [SerializeField]
    private MaskGeneration _maskGeneration;
    
    [SerializeField]
    private List<MaskGeneration> _otherMaskGeneration = new List<MaskGeneration>();

    private void Awake()
    {
        MaskGeneration[] Masks = FindObjectsOfType<MaskGeneration>();
        foreach (MaskGeneration Mask in Masks)
        {
            _otherMaskGeneration.Add(Mask);
        }
       
    }
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
        const int MAX_TRIES = 50;
        int tries = 0;

        while (tries < MAX_TRIES)
        {
            if (_otherMaskGeneration[i]._rendererTop.sprite != _maskGeneration._rendererTop.sprite ||
                _otherMaskGeneration[i]._rendererMiddle.sprite != _maskGeneration._rendererMiddle.sprite ||
                _otherMaskGeneration[i]._rendererBottom.sprite != _maskGeneration._rendererBottom.sprite)
            {
                return; // masque différent → OK
            }

            _otherMaskGeneration[i].RandomizeMask();
            tries++;
        }

        Debug.LogWarning($"PNJ {i} : masque toujours identique après {MAX_TRIES} essais");
    }
    
    
    
}
