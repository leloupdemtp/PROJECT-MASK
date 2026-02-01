using UnityEngine;
using UnityEngine.Events;

public class KillPNJ : MonoBehaviour
{
 private KillerMaskGeneration killerMaskGeneration;
 private WinCondition winCondition;
 
 public UnityEvent OnKillEvent;

 private void Start()
 {
   gameObject.GetComponent<KillerMaskGeneration>();
  winCondition = FindFirstObjectByType<WinCondition>();
 }

 public void Kill()
 {
     OnKillEvent.Invoke();
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
