
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class CameraController : MonoBehaviour
{
    private Vector2 _draggingOrigin;
    private bool _isDragging;
    
    private void Update()
    {
        TouchControl touch = Touchscreen.current.primaryTouch;
        if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began )
        {
            LayerMask mask = LayerMask.GetMask("Object");
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position.ReadValue());
            RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, mask);
            
            if (hit.collider is null)
            {
                if (_isDragging == false)
                {
                    _draggingOrigin = touchPosition;
                    _isDragging = true;
                }
            }
            
        }
        else if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Ended)
        {
            _isDragging = false;
        }

        if (_isDragging)
        {
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position.ReadValue());
            ChangeCameraPosition(touchPosition);
        }
    }

    private void ChangeCameraPosition(Vector2 newPosition)
    {
        Vector2 delta = _draggingOrigin - newPosition;
        gameObject.transform.position += new Vector3(delta.x, 0, 0);
    }
}
