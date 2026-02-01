using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCondition : MonoBehaviour
{
    [SerializeField] private Timer Timer;
    public Canvas WinUI;
    public Canvas LoseUI;
    private void Start()
    {
        WinUI.enabled = false;
        LoseUI.enabled = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timer.remainingtime <= 0f)
        {
            LoseGame();
            //Debug.Log("You Lose");
        }

    }

    public void LoseGame()
    {
        LoseUI.enabled = true;
        Time.timeScale = 0f;

    }

    public void WinGame()
    {
        WinUI.enabled = true;
    }
    

}
