using Unity.VisualScripting;
using UnityEngine;

namespace DraggableObjects
{
    public class DraggableObjectState
    {
        public virtual DraggableObjectState Update(DraggableObject draggableObject)
        {
            return null;
        }

        public virtual DraggableObjectState OnTriggerEnter(DraggableObject draggableObject, Collider2D other)
        {
            return null;
        }
        public virtual DraggableObjectState OnTriggerExit(DraggableObject draggableObject, Collider2D other)
        {
            return null;
        }

        public virtual DraggableObjectState Enter(DraggableObject draggableObject)
        {
            return null;
        }
        
    }
}
