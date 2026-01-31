using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class PNJGenerationSystem : MonoBehaviour
{
    [SerializeField]
    private List<Vector2> _positionsPNJ;
    
    public List<Vector2> _pnjToDelete;
    
    [SerializeField]
    private int _numberPNJ;
    
    [SerializeField]
    private GameObject _prefab;

    [ContextMenu("Generate")]
    public void GeneratePNJ()
    {
        for (int i = 0; i < _numberPNJ; i++)
        {
            int r = Random.Range(0, _pnjToDelete.Count);
            Instantiate(_prefab, _pnjToDelete[r], Quaternion.identity);
            _pnjToDelete.Remove(_pnjToDelete.ElementAt(r));
        }
    } 

    [ContextMenu("GetPositionsPNJ")]
    public void GetPositionsPNJ()
    {
        _pnjToDelete = _positionsPNJ;
    }
}
