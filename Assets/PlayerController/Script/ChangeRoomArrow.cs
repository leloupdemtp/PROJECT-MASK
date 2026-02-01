using UnityEngine;

public class ChangeRoomArrow : MonoBehaviour
{
    [SerializeField]
    GameObject _target;
    [SerializeField]
    private Vector2 _direction = Vector2.up;
    [SerializeField]
    private float _moveDistance = 6.0f;


    public void ChangeRoom()
    {
        _target.transform.position += new Vector3(_direction.x * _moveDistance,
            _direction.y * _moveDistance, 0.0f);
    }
}
