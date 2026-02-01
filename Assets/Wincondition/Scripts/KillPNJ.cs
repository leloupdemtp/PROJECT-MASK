using UnityEngine;

public class KillPNJ : MonoBehaviour
{
 private KillerMaskGeneration killerMaskGeneration;
 private WinCondition winCondition;

 private void Start()
 {
   gameObject.GetComponent<KillerMaskGeneration>();
  winCondition = FindFirstObjectByType<WinCondition>();
 }

 public void Kill()
 {
     if (killerMaskGeneration != null)
     {
         winCondition.WinGame();
     }
     else
     {
         winCondition.LoseGame();
     }
 }
}
