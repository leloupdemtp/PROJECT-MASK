using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
    
        SceneManager.LoadScene("Mask-LD");
    }
    // Permet de lancer le jeu lorsque le bouton start est presser 

    public void QuitGame()
    {
        Application.Quit();
    }
}
