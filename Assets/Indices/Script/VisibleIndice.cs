using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class VisibleIndice : MonoBehaviour
{

    [SerializeField] public Canvas IndiceCanvas;
    [SerializeField] TextMeshProUGUI[] indiceTextArray;
    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    List<string> indiceList = new List<string> { "X", "Y", "C", "Q", "K", "O", "L","1","4","7" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowIndice();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowIndice()
    {
        indiceTextArray[0].text = indiceList[0];
        indiceTextArray[1].text = indiceList[1];
        indiceTextArray[2].text = indiceList[2];
        indiceTextArray[3].text = indiceList[3];
        indiceTextArray[4].text = indiceList[4];
        indiceTextArray[5].text = indiceList[5];
        indiceTextArray[6].text = indiceList[6];
        indiceTextArray[7].text = indiceList[7];
        indiceTextArray[8].text = indiceList[8];
        indiceTextArray[9].text = indiceList[9];
        indiceTextArray[10].text = indiceList[10];
    }

}
