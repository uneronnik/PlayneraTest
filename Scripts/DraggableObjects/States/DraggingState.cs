using UnityEngine;
using DraggableObjects.Areas;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

namespace DraggableObjects
{
    public class DraggingState : DraggableObjectState
    {
        
        public override DraggableObjectState Update(DraggableObject draggableObject)
        {
            TouchControl touch = Touchscreen.current.primaryTouch;
            if (touch.phase.ReadValue() == TouchPhase.Ended)
            {
                if (draggableObject.GetZoneUnderObjectByType(typeof(MagnetZone)) is not null)
                {
                    MagnetZone magnetZone = (MagnetZone)draggableObject.GetZoneUnderObjectByType(typeof(MagnetZone));
                    Vector2 nearestPoint = magnetZone.GetNearestMagnetZone(draggableObject.transform.position);
                    return new GoingToState(nearestPoint, .3f);
                }
                if (draggableObject.ZonesUnderObject.Count == 0)
                {
                    return new FallingState();
                }
                else
                {
                    return new LandedState();
                }
            }
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(touch.position.ReadValue());
            draggableObject.transform.position = new Vector2(mousePosition.x, mousePosition.y);
            return null;
        }
    }
}