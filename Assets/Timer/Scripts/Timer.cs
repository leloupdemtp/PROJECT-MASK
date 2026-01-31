using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{
    [SerializeField]  private TextMeshProUGUI timerText;
    public float remainingtime;
    // Update is called once per frame
    void Update()
    {
        if (remainingtime > 0)
        {
            remainingtime -= Time.deltaTime;
        }
        else if (remainingtime < 0)
        {
            remainingtime = 0;
            timerText.color = Color.red;
        }
        int minutes = Mathf.FloorToInt(remainingtime / 60);
        int seconds = Mathf.FloorToInt(remainingtime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
}
