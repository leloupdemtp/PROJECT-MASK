using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class PNJGenerationSystem : MonoBehaviour
{
    [SerializeField]
    private List<Vector2> _positionsPNJ;
    
    public List<Vector2> PnjToDelete;
    
    [SerializeField]
    private int _numberPNJ;
    
    [SerializeField]
    private GameObject _prefab;

    [ContextMenu("Generate")]
    public void GeneratePNJ()
    {
        for (int i = 0; i < _numberPNJ; i++)
        {
            int r = Random.Range(0, PnjToDelete.Count);
            GameObject s = Instantiate(_prefab, PnjToDelete[r], Quaternion.identity);
            _positionsPNJ.Add(PnjToDelete[r]);
            PnjToDelete.RemoveAt(r);
            s.GetComponent<MaskGeneration>().RandomizeMask();
        }
    } 

    [ContextMenu("GetPositionsPNJ")]
    public void GetPositionsPNJ()
    {
        PnjToDelete = _positionsPNJ;
    }
}


