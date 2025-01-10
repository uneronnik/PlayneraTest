
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;


namespace DraggableObjects
{
    public class LandedState : DraggableObjectState
    {
        public override DraggableObjectState Update(DraggableObject draggableObject)
        {
            TouchControl touch = Touchscreen.current.primaryTouch;
            if (touch != null)
            {
                if (touch.phase.ReadValue() == UnityEngine.InputSystem.TouchPhase.Began)
                {
                    int layerMask = 1 << LayerMask.NameToLayer("Object");
                    
                    Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position.ReadValue());
                    RaycastHit2D hit = Physics2D.Raycast(touchPosition, Vector2.zero, layerMask);
                    if (hit.collider is not null)
                    {
                        if (hit.collider.gameObject == draggableObject.gameObject)
                        {
                            return new DraggingState();
                        }
                    }
                }
            }

            return null;
        }
    }
}