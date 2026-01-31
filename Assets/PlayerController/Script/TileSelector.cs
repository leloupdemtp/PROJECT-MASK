using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.Events;


public class TileSelector : MonoBehaviour
{
    private const float _minPos = 0.5f;
    private const float _maxPos = 4.5f;

    private Vector3 _startPosition = new Vector3(0.5f, 0.5f, 1.0f);

    public UnityEvent OnSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = _startPosition;
    }

    public void SelectTile(InputAction.CallbackContext obj)
    {
        if (obj.performed)
        {
            Debug.Log("TileSelected");
            RaycastHit hitTarget;
            // Create raycast ray.
            Vector3 origin = new Vector3(transform.position.x, transform.position.y, 0.0f);
            Vector3 destination = new Vector3(transform.position.x, transform.position.y, -10.0f);

            // Cast a raycast and check result.
            if(Physics.Raycast(origin, destination, out hitTarget))
            {
                if (hitTarget.collider.GetComponent<IPNJ>() != null)
                {
                    OnSelected.Invoke();
                }
            }
            else
            {
                Debug.Log("No target");
            }
        
        }
    }

    public void TileSelectorMove(InputAction.CallbackContext obj)
    {
        Vector2 playerInput = obj.ReadValue<Vector2>();
        
        if (obj.performed)
        {
            // Move the selection
            transform.position += new Vector3(Mathf.Ceil(playerInput.x), Mathf.Ceil(playerInput.y), 0.0f);
            // Clamp selection's position
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minPos, _maxPos),
                Mathf.Clamp(transform.position.y, _minPos, _maxPos), 0.0f);
                
            Debug.Log("the selected position is: " + transform.position);
        }
    }
    

}
