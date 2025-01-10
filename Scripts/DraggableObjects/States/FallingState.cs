using DraggableObjects.Areas;
using UnityEngine;

namespace DraggableObjects
{
    public class FallingState : DraggableObjectState
    {
        public override DraggableObjectState Update(DraggableObject draggableObject)
        {
            draggableObject.transform.position += Physics.gravity * Time.deltaTime;
            return null;
        }

        public override DraggableObjectState OnTriggerEnter(DraggableObject draggableObject, Collider2D other)
        {
            if (other.GetComponent<FreeFallPlacementZone>() != null)
            {
                return new LandedState();
            }
            return null;
        }
    }
}
