using UnityEngine;

namespace DraggableObjects
{
    public class GoingToState : DraggableObjectState
    {
        private Vector2 _endPosition;
        private float _speed;

        public GoingToState(Vector2 endPosition, float speed)
        {
            _endPosition = endPosition;
            _speed = speed;
        }
        
        public override DraggableObjectState Update(DraggableObject draggableObject)
        {
            draggableObject.transform.position = Vector2.Lerp(draggableObject.transform.position, _endPosition, _speed);
            if (draggableObject.transform.position ==
                new Vector3(_endPosition.x, _endPosition.y, draggableObject.transform.position.z))
            {
                return new LandedState();
            }
            return null;
        }
    }
}