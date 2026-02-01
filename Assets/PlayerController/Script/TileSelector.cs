using UnityEngine;
using UnityEngine.InputSystem;


public class TileSelector : MonoBehaviour
{
    private float _minPos = 2
        ;
    private float _maxPos = -2;
    
    private Vector2 _startPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    private KillPNJ _killPNJ;
    
    private bool _isTalking = false;
    
    private void Awake()
    {
        // Position de départ = centre du carré 5x5
        _startPos = transform.localPosition;
    }
    
    public void SelectTile(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            _isTalking = true;
            Debug.Log("TileSelected");
            
            // Create raycast ray.
            Vector3 origin = transform.position;
            Vector3 destination = new Vector3(0,0, 1);
            
            
            
            RaycastHit2D hit = Physics2D.Raycast(origin, destination, 10);
            // Cast a raycast and check result.
            
            
            
            if(hit)
            {
                OpenDialogue openDialogue; 
                if (hit.collider.TryGetComponent<OpenDialogue>(out openDialogue))
                {
                    hit.collider.TryGetComponent<KillPNJ>(out _killPNJ);
                    
                    if (openDialogue._isActive == false)
                    {
                        openDialogue.StartDialogue();
                    }
                    else
                    {
                        openDialogue.StopDialogue();
                        _isTalking = false;
                    }
                }
                
            }
            else
            {
                Debug.Log("No target");
            }
        }
    }

    public void KillAction(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            _killPNJ.Kill();
        }
    }
    
    public void TileSelectorMove(InputAction.CallbackContext obj)
    {
        if (_isTalking)
            return;
        if (!obj.performed)
            return;

        Vector2 input = obj.ReadValue<Vector2>();

        Vector2 move = new Vector2(
            Mathf.RoundToInt(input.x),
            Mathf.RoundToInt(input.y)
        );

        // Nouvelle position
        Vector2 newPos = (Vector2)transform.localPosition + move;

        // Clamp autour de la position de départ (centre)
        newPos.x = Mathf.Clamp(newPos.x, _startPos.x - 2, _startPos.x + 2);
        newPos.y = Mathf.Clamp(newPos.y, _startPos.y - 2, _startPos.y + 2);

        transform.localPosition = newPos;

        Debug.Log("Position sélectionnée : " + newPos);
    }
    

}
