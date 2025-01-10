using System.Collections.Generic;
using UnityEngine;

namespace DraggableObjects.Areas
{
    public class MagnetZone : PlacementZone
    {
        [SerializeField] private Transform _lineStartPoint;
        [SerializeField] private Transform _lineEndPoint;

        public Vector2 GetNearestMagnetZone(Vector2 position)
        {
            if (_lineStartPoint is null || _lineEndPoint is null)
            {
                throw new System.ArgumentException("There is no magnet line.");
            }
            
            Vector3 AB = _lineEndPoint.position - _lineStartPoint.position;
            Vector3 AP = position - new Vector2(_lineStartPoint.position.x, _lineStartPoint.position.z);
            
            float magnitudeAB2 = AB.sqrMagnitude;
            if (magnitudeAB2 == 0)
            {
                return _lineStartPoint.position;
            }
        
            // Параметр t на отрезке
            float t = Vector3.Dot(AP, AB) / magnitudeAB2;

            // Ограничиваем t в диапазоне [0, 1]
            t = Mathf.Clamp01(t);

            // Находим ближайшую точку
            return _lineStartPoint.position + t * AB;
        }
    }
}